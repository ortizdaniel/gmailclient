﻿using GmailClient;
using Google.Apis.Gmail.v1;
using Google.Apis.Gmail.v1.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Mail;
using System.Text;

// ...

public class MessageManager
{


    // ...

    /// <summary>
    /// List all message threads of the user's mailbox.
    /// </summary>
    /// <param name="service">Gmail API service instance.</param>
    /// <param name="userId">User's email address. The special value "me"
    /// can be used to indicate the authenticated user.</param>
    private static List<Thread> ListThreads(GmailService service, String userId, int numMessages)
    {        
        List<Thread> result = new List<Thread>();
        UsersResource.ThreadsResource.ListRequest request = service.Users.Threads.List(userId);
        request.MaxResults = numMessages;
        request.LabelIds = "INBOX";
        ListThreadsResponse response = request.Execute();
        result.AddRange(response.Threads);

        return result;
    }

    //Para decodificar de Base64 a string
    private static string Base64UrlEncode(string input)
    {
        var inputBytes = System.Text.Encoding.UTF8.GetBytes(input);
        // Special "url-safe" base64 encode.
        return Convert.ToBase64String(inputBytes)
          .Replace('+', '-')
          .Replace('/', '_')
          .Replace("=", "");
    }

    //Metodo para enviar mensajes
    public static void SendMessage(string userId, string destinatario, string mensaje, string asunto, GmailService s)
    {
        //Crear mensaje
        var msg = new AE.Net.Mail.MailMessage
        {
            Subject = asunto,
            Body = mensaje,
            From = new MailAddress(Usuario.GetProfile(s, userId).EmailAddress)
        };
        msg.To.Add(new MailAddress(destinatario));
        msg.ReplyTo.Add(msg.From); 
        var msgStr = new StringWriter();
        msg.Save(msgStr);
        //Enviarlo
        var result = s.Users.Messages.Send(new Message
        {
            Raw = Base64UrlEncode(msgStr.ToString())
        }, "me").Execute();
    }  


    /// <summary>
    /// Get a Thread with given ID.
    /// </summary>
    /// <param name="service">Gmail API service instance.</param>
    /// <param name="userId">User's email address. The special value "me"
    /// can be used to indicate the authenticated user.</param>
    /// <param name="threadId">ID of Thread to retrieve.</param>
    private static Thread GetThread(GmailService service, String userId, String threadId)
    {
        try
        {
            return service.Users.Threads.Get(userId, threadId).Execute();
        }
        catch (Exception e)
        {
            Console.WriteLine("An error occurred: " + e.Message);
        }

        return null;
    }

    /// <summary>
    /// Retrieve a Message by ID.
    /// </summary>
    /// <param name="service">Gmail API service instance.</param>
    /// <param name="userId">User's email address. The special value "me"
    /// can be used to indicate the authenticated user.</param>
    /// <param name="messageId">ID of Message to retrieve.</param>
    private static Message GetMessage(GmailService service, String userId, String messageId)
    {
        try
        {
            return service.Users.Messages.Get(userId, messageId).Execute();
        }
        catch (Exception e)
        {
            Console.WriteLine("An error occurred: " + e.Message);
        }

        return null;
    }

    //Obtiene una lista de mensajes, los cuales solo contienen la ID
    public static List<Message> ListMessages(GmailService service, String userId, int maxMessages, string[] labels = null)
    {
        List<Message> result = new List<Message>();
        UsersResource.MessagesResource.ListRequest request = service.Users.Messages.List(userId);
        if (request != null)
        {
            request.MaxResults = maxMessages;
            if (labels != null)
            {
                request.LabelIds = labels;
            }
            ListMessagesResponse response = request.Execute();
            if (response.Messages == null)
            {
                return null;
            }
            result.AddRange(response.Messages);
            return result;
        }
        return null;        
    }

    /**
     * Obtiene todos los mensajes de un usuario ya con el contenido (recibidos y enviados)
     * @return: lista de los mensajes
     * 
     */
    public static List<Mensaje> getMensajes(String userId, GmailService service, int maxMensajes, string[] labels = null)
    {
        List<Mensaje> mensajes = new List<Mensaje>();
        //Obtienes mensajes con solo la id
        List<Message> messages = ListMessages(service, userId, maxMensajes, labels);
        
        if(messages == null)
        {
            return null;
        }
        int i = 0;
        //Para cada id obtienes el mensaje con contenido
        foreach (Message ms in messages)
        {
            Mensaje msg = new Mensaje();
           
            Message m = service.Users.Messages.Get(userId, ms.Id).Execute();
            
            //Assignas las etiquetas correspondientes
            foreach (MessagePartHeader h in m.Payload.Headers)
            {
                if (h.Name == "Subject")
                {
                    msg.Subject = h.Value;
                }

                if (h.Name == "To")
                {
                    msg.To = h.Value;
                }

                if (h.Name == "From")
                {
                    msg.From = h.Value;
                }
            }

            foreach(String l in m.LabelIds)
            {
                if (l == "SPAM")
                {
                    msg.IsSpam = true;
                }
                if (l == "TRASH")
                {
                    msg.IsTrash = true;
                }
                if (l == "CATEGORY_SOCIAL")
                {
                    msg.IsSocial = true;
                }
                if (l == "CATEGORY_PROMOTIONS")
                {
                    msg.IsPromotional = true;
                }
                if (l == "INBOX")
                {
                    msg.IsInbox = true;
                }
                if (l == "UNREAD")
                {
                    msg.IsUnread = true;
                }
                if (l == "SENT")
                {
                    msg.IsSent = true;
                }
            }
            //Assignas el id unico       
            msg.MessageId = m.Id;
            
            //Assignas el contenido que viene dividido en el mensaje y codificado
            if (m.Payload.Parts != null)
            {
                foreach (MessagePart p in m.Payload.Parts)
                {                           
                        msg.Body += GetMimeString(p);     
                                         
                    
                }                            
                
            }                  
            
            mensajes.Add(msg);
        }
        
        return mensajes;
    }
    //Metodo para obtener el contenido del mensaje codificado y en partes
    public static String GetMimeString(MessagePart Parts)
    {
        String Body = "";

        if (Parts.Parts != null)
        {
            foreach (MessagePart part in Parts.Parts)
            {
                Body = String.Format("{0}\n{1}", Body, GetMimeString(part));
            }
        }
        else if (Parts.Body.Data != null && Parts.Body.AttachmentId == null && Parts.MimeType == "text/plain")
        {
            String codedBody = Parts.Body.Data.Replace("-", "+");
            codedBody = codedBody.Replace("_", "/");
            byte[] data = Convert.FromBase64String(codedBody);
            Body = Encoding.UTF8.GetString(data);
        }

        return Body;
    }

    //Mover mensaje a la basura
    public static void DeleteMessage(GmailService service, string userId, string messageId)
    {
        try
        {
            service.Users.Messages.Trash(userId, messageId).Execute();
        }
        catch (Exception e)
        {
            Console.WriteLine("Error " + e.Message);
        }
    }

    //Eliminar mensaje definitivamente
    public static void DeleteForeverMessage(GmailService service, string userId, string messageId)
    {
        try
        {
            service.Users.Messages.Delete(userId, messageId).Execute();
        }
        catch (Exception e)
        {
            Console.WriteLine("Error " + e.Message);
        }
    }


    /// <summary>
    /// Get and store attachment from Message with given ID.
    /// </summary>
    /// <param name="service">Gmail API service instance.</param>
    /// <param name="userId">User's email address. The special value "me"
    /// can be used to indicate the authenticated user.</param>
    /// <param name="messageId">ID of Message containing attachment.</param>
    public static string GetAttachments(GmailService service, String userId, Message message)
    {
        try
        {
            IList<MessagePart> parts = message.Payload.Parts;
            foreach (MessagePart part in parts)
            {
                if (!String.IsNullOrEmpty(part.Filename))
                {
                    String attId = part.Body.AttachmentId;
                    MessagePartBody attachPart = service.Users.Messages.Attachments.Get(userId, message.Id, attId).Execute();

                    // Converting from RFC 4648 base64 to base64url encoding
                    // see http://en.wikipedia.org/wiki/Base64#Implementations_and_history
                    String attachData = attachPart.Data.Replace('-', '+');
                    attachData = attachData.Replace('_', '/');

                    byte[] data = Convert.FromBase64String(attachData);
                    return System.Text.Encoding.Default.GetString(data);
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("An error occurred: " + e.Message);
            return null;
        }
        return null;
    }

    //Modificar mensaje, como los labels
    public static Message ModifyMessage(GmailService service, String userId,
      String messageId, List<String> labelsToAdd, List<String> labelsToRemove)
    {
        ModifyMessageRequest mods = new ModifyMessageRequest();
        mods.AddLabelIds = labelsToAdd;
        mods.RemoveLabelIds = labelsToRemove;

        try
        {
            return service.Users.Messages.Modify(mods, userId, messageId).Execute();
        }
        catch (Exception e)
        {
            Console.WriteLine("An error occurred: " + e.Message);
        }

        return null;
    }

}

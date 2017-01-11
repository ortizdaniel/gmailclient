using GmailClient;
using Google.Apis.Gmail.v1;
using Google.Apis.Gmail.v1.Data;
using System;
using System.Collections.Generic;
using System.IO;
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


    public static List<Message> ListMessages(GmailService service, String userId, int maxMessages, string query = null)
    {
        List<Message> result = new List<Message>();
        UsersResource.MessagesResource.ListRequest request = service.Users.Messages.List(userId);
        request.MaxResults = maxMessages;        
        ListMessagesResponse response = request.Execute();
        result.AddRange(response.Messages);               

        return result;
    }

    /**
     * Obtiene todos los mensajes de un usuario (recibidos y enviados)
     * @return: lista de los mensajes
     * 
     */
    public static List<Mensaje> getMensajes(String userId, GmailService service, int maxMensajes)
    {
        List<Mensaje> mensajes = new List<Mensaje>();

        List<Message> messages = ListMessages(service, userId, maxMensajes);

        int i = 0;
        foreach (Message ms in messages)
        {
            Mensaje msg = new Mensaje();
           
            Message m = service.Users.Messages.Get(userId, ms.Id).Execute();
            

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
                if (l == "INBOX")
                {
                    msg.IsInbox = true;
                }
                if (l == "UNREAD")
                {
                    msg.IsUnread = true;
                }

                if (l == "SPAM")
                {
                    msg.IsSpam = true;
                }
                if (l == "SENT")
                {
                    msg.IsSent = true;
                }
            }
                   
            msg.MessageId = m.Id;
            msg.Body = m.Snippet;
            
            mensajes.Add(msg);
        }
        
        return mensajes;
    }


    public static void DeleteMessage(GmailService service, string userId, string messageId)
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

}

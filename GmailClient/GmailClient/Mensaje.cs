﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GmailClient
{
    //Clase Mensaje donde se guarda el contenido que se recibe en la clase Message de la Api de Gmail
    public class Mensaje
    {
        public string MessageId { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public Boolean IsTrash { get; set; } = false;
        public Boolean IsUnread { get; set; } = false;
        public Boolean IsInbox { get; set; } = false;
        public Boolean IsSpam { get; set; } = false;
        public Boolean IsSent { get; set; } = false;
        public Boolean IsSocial { get; set; } = false;
        public Boolean IsPromotional { get; set; } = false;
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Google.Apis.Gmail.v1.Data;
using Google.Apis.Gmail.v1;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using Google.Apis.Services;
using Google.Apis.Requests;
using System.Net.Http;
using System.Net.Mail;

namespace GmailClient
{
    public class Usuario
    {
        public static Profile GetProfile(GmailService service, string userId)
        {
            Profile p = service.Users.GetProfile(userId).Execute();
            return p;
        }
    }
}

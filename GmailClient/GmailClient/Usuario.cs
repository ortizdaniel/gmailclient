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
using System.Windows.Forms;

namespace GmailClient
{
    public class Usuario
    {
        public static Profile GetProfile(GmailService service, string userId)
        {
            Profile p = null;
            try
            {
                p = service.Users.GetProfile(userId).Execute();
            } catch (HttpRequestException ex)
            {
                MessageBox.Show("Error al crear petición con internet. Deteniendo ejecución", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
            return p;
        }
    }
}

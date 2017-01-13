using Google.Apis.Auth.OAuth2;
using Google.Apis.Gmail.v1;
using Google.Apis.Gmail.v1.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GmailQuickstart
{
    class Login
    {
        // If modifying these scopes, delete your previously saved credentials
        // at ~/.credentials/gmail-dotnet-quickstart.json
        static string[] Scopes = { "https://mail.google.com/", "https://www.googleapis.com/auth/gmail.modify", "https://www.googleapis.com/auth/gmail.compose",
                                    "https://www.googleapis.com/auth/gmail.send"};
        static string ApplicationName = "Gmail API .NET Quickstart";

        /**
         * Metodo para logearse. Proporcionada por Gmail
         * @return: instancia de GmailService
         * 
         */
        public static GmailService DoLogin()
        {
            UserCredential credential;

            using (var stream =
                new FileStream("client_secret.json", FileMode.Open, FileAccess.Read))
            {
                string credPath = System.Environment.GetFolderPath(
                    System.Environment.SpecialFolder.Personal);
                credPath = Path.Combine(credPath, ".credentials/gmail-dotnet-quickstart.json");


                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.Load(stream).Secrets,
                    Scopes,
                    "user",
                    CancellationToken.None,
                    new FileDataStore(credPath, true)).Result;
                Console.WriteLine("Credential file saved to: " + credPath);
            }

            // Create Gmail API service.
            var service = new GmailService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = ApplicationName,
            });
            
            return service;
        }

        //Para mirar donde se ha guardado el .json
        private static string getTokenPath()
        {
            string credPath = System.Environment.GetFolderPath(
                    System.Environment.SpecialFolder.Personal);
            credPath = Path.Combine(credPath, ".credentials/gmail-dotnet-quickstart.json");
            credPath = Path.Combine(credPath, "Google.Apis.Auth.OAuth2.Responses.TokenResponse-user");
            return credPath;
        }

        /**
         * Comprueba si existe algun archivo de login
         * @return: Boolean
         * 
         */
        public static Boolean isLogged()
        {
            string credPath = getTokenPath();
            return File.Exists(credPath);
        }

        /**
         * Metodo para cerrar sesion, borra el archivo de login
         *
         * 
         */
        public static void DoLogout()
        {
            string credPath = getTokenPath();
            File.Delete(credPath);
        }
    }
}
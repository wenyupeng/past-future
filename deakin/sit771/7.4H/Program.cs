using System;
using SplashKitSDK;

namespace _7_4H
{
    public class Program
    {
        private static Dictionary<string, string> _userMap = new Dictionary<string, string>();
        public static void Main()
        {
            SplashKit.WriteLine("start the server...");

            WebServer server = SplashKit.StartWebServer();
            HttpRequest request;

            SplashKit.WriteLine("Waiting for a request - navigate to http://localhost:8080");
            SplashKit.WriteLine("To end - navigate to http://localhost:8080/quit");

            request = SplashKit.NextWebRequest(server);

            while (!SplashKit.IsGetRequestFor(request, "/quit"))
            {
                SplashKit.WriteLine("I got a request for " + SplashKit.RequestURI(request));

                if (SplashKit.IsGetRequestFor(request, "/login") || SplashKit.IsGetRequestFor(request, "/login.html"))
                {
                    SplashKit.SendResponse(request, "login.html");
                }
                else if (SplashKit.IsGetRequestFor(request, "/checkUser")){
                    
                }
                else if (SplashKit.IsGetRequestFor(request, "/register") || SplashKit.IsGetRequestFor(request, "/register.html"))
                {

                    SplashKit.SendResponse(request, "register successfully");
                }
                else if (SplashKit.IsGetRequestFor(request, "/addUser")){
                    
                }
                else if (SplashKit.IsGetRequestFor(request, "/contact") || SplashKit.IsGetRequestFor(request, "/contact.html"))
                {

                    SplashKit.SendResponse(request, "contact.html");
                }
                else if (SplashKit.IsGetRequestFor(request, "/about") || SplashKit.IsGetRequestFor(request, "/about.html"))
                {

                    SplashKit.SendResponse(request, "about.html");
                }
                else
                {
                    SplashKit.SendHtmlFileResponse(request, "index.html");
                }

                SplashKit.WriteLine("Waiting for a request - navigate to http://localhost:8080");
                SplashKit.WriteLine("To end - navigate to http://localhost:8080/quit");

                // Get the next request that the server has
                request = SplashKit.NextWebRequest(server);
            }

            SplashKit.WriteLine("About to stop the server...");
            SplashKit.StopWebServer(server);
        }
    }
}

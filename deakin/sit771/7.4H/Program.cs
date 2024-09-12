using System;
using System.Text.Json.Nodes;
using SplashKitSDK;

namespace _7_4H
{
    public class Program
    {
        private static Dictionary<string, string> _userMap = new Dictionary<string, string>();
        public static void Main()
        {

            WebServer server = SplashKit.StartWebServer();
            HttpRequest request;

            request = SplashKit.NextWebRequest(server);

            while (!SplashKit.IsGetRequestFor(request, "/quit"))
            {
                SplashKit.WriteLine("I got a request for " + SplashKit.RequestURI(request));

                if (SplashKit.IsGetRequestFor(request, "/login") || SplashKit.IsGetRequestFor(request, "/login.html"))
                {
                    SplashKit.SendHtmlFileResponse(request, "login.html");
                }
                else if (SplashKit.IsPostRequestFor(request, "/checkUser"))
                {
                    string userInfo = request.Body;
                    if (userInfo != null && userInfo != "")
                    {
                        string[] userArr = userInfo.Split("&");
                        if (userArr != null && userArr.Length > 1)
                        {
                            string username = (userArr[0].Split("="))[1];
                            string password = (userArr[1].Split("="))[1];
                            bool flag = _userMap.ContainsKey(username);
                            SplashKit.WriteLine(_userMap.GetValueOrDefault(username));
                            if (flag && _userMap.GetValueOrDefault(username) == password)
                            {
                                SplashKit.SendResponse(request, "login successfuly");
                            }
                        }
                    }
                    SplashKit.SendResponse(request, "login fail");
                }
                else if (SplashKit.IsGetRequestFor(request, "/register") || SplashKit.IsGetRequestFor(request, "/register.html"))
                {

                    SplashKit.SendHtmlFileResponse(request, "register.html");
                }
                else if (SplashKit.IsPostRequestFor(request, "/addUser"))
                {
                    string userInfo = request.Body;
                    if (userInfo != null && userInfo != "")
                    {
                        string[] userArr = userInfo.Split("&");
                        if (userArr != null && userArr.Length > 1)
                        {
                            string username = (userArr[0].Split("="))[1];
                            string password = (userArr[1].Split("="))[1];
                            _userMap.TryAdd(username, password);
                            SplashKit.SendResponse(request, "add user successfuly");
                        }
                    }
                    SplashKit.SendResponse(request, "add user fail");
                }
                else if (SplashKit.IsGetRequestFor(request, "/contact") || SplashKit.IsGetRequestFor(request, "/contact.html"))
                {

                    SplashKit.SendHtmlFileResponse(request, "contact.html");
                }
                else if (SplashKit.IsGetRequestFor(request, "/about") || SplashKit.IsGetRequestFor(request, "/about.html"))
                {

                    SplashKit.SendHtmlFileResponse(request, "about.html");
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

            SplashKit.StopWebServer(server);
        }
    }
}

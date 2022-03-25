using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace HTTPListenerSolution
{
    public class CustomListener
    {
        public static void Listen(string[] prefixes)
        {
            if (!HttpListener.IsSupported)
            {
                Console.WriteLine("HttpClient is required to use the HttpListener class.");
                return;
            }
            
            HttpListener listener = new HttpListener();
            
            foreach (string s in prefixes)
            {
                listener.Prefixes.Add(s);
            }

            while (true)
            {
                listener.Start();
                Console.WriteLine("Listening...");
                HttpListenerContext context = listener.GetContext();
                HttpListenerRequest request = context.Request;

                var absolutePath = request.Url.AbsolutePath;
                switch (absolutePath.Remove(0, 1))
                {
                    case "MyName":
                    {
                        var response = GetMyName(context);
                        break;
                    }
                    case "Information":
                    {
                        var response = InformationResponce(context);
                        break;
                    }
                    case "Success":
                    {
                        var response = SuccessResponce(context);
                        break;
                    }
                    case "Redirection":
                    {
                        var response = RedirectionResponce(context);
                        break;
                    }
                    case "ClientError":
                    {
                        var response = ClientErrorResponce(context);
                        break;
                    }
                    case "ServerError":
                    {
                        var response = ServerErrorResponce(context);
                        break;
                    }
                    case "GetMyNameByHeader":
                    {
                        var response = GetMyNameByHeader(context);
                        break;
                    }
                    case "MyNameByCookies":
                    {
                        var response = MyNameByCookies(context);
                        break;
                    }
                }
                listener.Stop();
            }
        }

        public static HttpListenerResponse GetMyName(HttpListenerContext context)
        {
            HttpListenerResponse response = context.Response;
           
            string responseString = "MyName";
            byte[] buffer = System.Text.Encoding.UTF8.GetBytes(responseString);
         
            response.ContentLength64 = buffer.Length;
            System.IO.Stream output = response.OutputStream;
            output.Write(buffer, 0, buffer.Length);
   
            output.Close();
            return response;
        }

        //Dmitry check this where status changed to 100
        public static HttpListenerResponse InformationResponce(HttpListenerContext context)
        {
            HttpListenerResponse response = context.Response;

            string responseString = "asd";
            response.StatusCode = 101;
            byte[] buffer = System.Text.Encoding.UTF8.GetBytes(responseString);

            response.ContentLength64 = buffer.Length;
            System.IO.Stream output = response.OutputStream;
            output.Write(buffer, 0, buffer.Length);

            output.Close();
            return response;
        }

        public static HttpListenerResponse SuccessResponce(HttpListenerContext context)
        {
            HttpListenerResponse response = context.Response;
       
            string responseString = "asd";
            response.StatusCode = (int) HttpStatusCode.Accepted;
            byte[] buffer = System.Text.Encoding.UTF8.GetBytes(responseString);
           
            response.ContentLength64 = buffer.Length;
            System.IO.Stream output = response.OutputStream;
            output.Write(buffer, 0, buffer.Length);
        
            output.Close();
            return response;
        }

        public static HttpListenerResponse RedirectionResponce(HttpListenerContext context)
        {
            HttpListenerResponse response = context.Response;
            
            string responseString = "asd";
            response.StatusCode = (int)HttpStatusCode.Ambiguous;
            byte[] buffer = System.Text.Encoding.UTF8.GetBytes(responseString);
            
            response.ContentLength64 = buffer.Length;
            System.IO.Stream output = response.OutputStream;
            output.Write(buffer, 0, buffer.Length);
            
            output.Close();
            return response;
        }

        public static HttpListenerResponse ClientErrorResponce(HttpListenerContext context)
        {
            HttpListenerResponse response = context.Response;
            
            string responseString = "asd";
            response.StatusCode = (int)HttpStatusCode.BadRequest;
            byte[] buffer = System.Text.Encoding.UTF8.GetBytes(responseString);
            
            response.ContentLength64 = buffer.Length;
            System.IO.Stream output = response.OutputStream;
            output.Write(buffer, 0, buffer.Length);
            
            output.Close();
            return response;
        }

        public static HttpListenerResponse ServerErrorResponce(HttpListenerContext context)
        {
            HttpListenerResponse response = context.Response;
            // Construct a response.
            string responseString = "501";
            response.StatusCode = 501;
            byte[] buffer = System.Text.Encoding.UTF8.GetBytes(responseString);
            // Get a response stream and write the response to it.
            response.ContentLength64 = buffer.Length;
            System.IO.Stream output = response.OutputStream;
            output.Write(buffer, 0, buffer.Length);
            // You must close the output stream.
            output.Close();
            return response;
        }

        public static HttpListenerResponse GetMyNameByHeader(HttpListenerContext context)
        {
            HttpListenerResponse response = context.Response;
            // Construct a response.
            response.AddHeader("X-MyName", "Ivan");
            string responseString = "Myname";
            byte[] buffer = System.Text.Encoding.UTF8.GetBytes(responseString);
            // Get a response stream and write the response to it.
            response.ContentLength64 = buffer.Length;
            System.IO.Stream output = response.OutputStream;
            output.Write(buffer, 0, buffer.Length);
            // You must close the output stream.
            output.Close();
            return response;
        }

        public static HttpListenerResponse MyNameByCookies(HttpListenerContext context)
        {
            HttpListenerResponse response = context.Response;
            // Construct a response.
            response.AppendCookie(new Cookie("MyName","Ivan"));
            string responseString = "Myname";
            byte[] buffer = System.Text.Encoding.UTF8.GetBytes(responseString);
            // Get a response stream and write the response to it.
            response.ContentLength64 = buffer.Length;
            System.IO.Stream output = response.OutputStream;
            output.Write(buffer, 0, buffer.Length);
            // You must close the output stream.
            output.Close();
            return response;
        }
    }
}

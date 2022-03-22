using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace HTTPClientSolution
{
    class Program
    {
        static readonly HttpClient client = new HttpClient();

        static async Task Main()
        {
            await MyNameRequest();
            await GetMyNameByHeaderRequest();
            await MyNameByCookies();
            await InformationRequest();
            await SuccessRequest();
            await RedirectionRequest();
            await ClientErrorRequest();
            await ServerErrorRequest();
        }

        static async Task MyNameRequest()
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync("http://localhost:8888/MyName");
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();

                Console.WriteLine(responseBody);
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
            }
        }

        static async Task InformationRequest()
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync("http://localhost:8888/Information");
                var responseStatusCode = response.StatusCode;
               
                Console.WriteLine(responseStatusCode);
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
            }
        }

        static async Task SuccessRequest()
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync("http://localhost:8888/Success");
                response.EnsureSuccessStatusCode();
                var responseStatusCode = response.StatusCode;

                Console.WriteLine(responseStatusCode);
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
            }
        }

        static async Task RedirectionRequest()
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync("http://localhost:8888/Redirection");
                response.EnsureSuccessStatusCode();
                var responseStatusCode = response.StatusCode;

                Console.WriteLine(responseStatusCode);
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Status :{0} ", e.Message);
            }
        }


        static async Task ClientErrorRequest()
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync("http://localhost:8888/ClientError");
                response.EnsureSuccessStatusCode();
                var responseStatusCode = response.StatusCode;

                Console.WriteLine(responseStatusCode);
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
            }
        }

        static async Task ServerErrorRequest()
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync("http://localhost:8888/ServerError");
                response.EnsureSuccessStatusCode();
                var responseStatusCode = response.StatusCode;

                Console.WriteLine(responseStatusCode);
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
            }
        }

        static async Task GetMyNameByHeaderRequest()
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync("http://localhost:8888/GetMyNameByHeader");
                response.EnsureSuccessStatusCode();
                string responseCustomHeader = response.Headers.GetValues("X-MyName").First();

                Console.WriteLine(responseCustomHeader);
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
            }
        }

        static async Task MyNameByCookies()
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync("http://localhost:8888/MyNameByCookies");
                response.EnsureSuccessStatusCode();
                var responceCookie = response.Headers.SingleOrDefault(header => header.Key == "Set-Cookie")
                    .Value.First().Split('=').Last();

                Console.WriteLine(responceCookie);
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
            }
        }

    }
}

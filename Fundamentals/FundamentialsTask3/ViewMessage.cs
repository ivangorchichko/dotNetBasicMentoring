using System;

namespace FundamentialsTask3
{
    public static class ViewMessage
    {
        public static string GetHelloString(string inputName)
        {
            return $"{DateTime.Now} Hello {inputName}!";
        }
    }
}

using Microsoft.AspNetCore.Hosting;

namespace USSDCSharp.Models
{
    public class UssdModel
    {
        private static string shortCode = AppSettings.ShortCode;
        public class UssdResponse
        {
            public string Message { get; set; }
            public string Type { get; set; }

        }

        public class UssdRequestData
        {
            public string Type { get; set; }
            public string Mobile { get; set; }
            public string SessionId { get; set; }
            public string ServiceCode { get; set; }
            public string Message { get; set; }
            public string Operator { get; set; }


            //public UssdRequestData()
            //{
            //    ServiceCode = shortCode;
            //}
        }
    }
}

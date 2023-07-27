using Microsoft.AspNetCore.Hosting;
using USSDCSharp.DBContext;

namespace USSDCSharp.Models
{
    public class UssdSession
    {
        public UssdSession()
        {
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;

        }
        public long Id { get; set; }
        public string Type { get; set; }
        public string SessionId { get; set; }

        public string Tag { get; set; }
        public string Mobile { get; set; }
        public string ServiceCode { get; set; }
        public string Message { get; set; }
        public string? MessageDescription { get; set; }
        public string Operator { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public static void SaveSession(string typeValue, string sessionValue, string msisdn, string network, string msg, string tag, string description = null)
        {
            using (var context = new UssdDBContext())
            {
                var dateTimeNow = DateTime.Now;

                var usd = new UssdSession()
                {
                    Type = typeValue,
                    SessionId = sessionValue,
                    Mobile = msisdn,
                    ServiceCode = AppSettings.ShortCode, // Make sure to replace AppSettings.ShortCode with your actual short code
                    Message = msg.ToString(),
                    MessageDescription = description,
                    Operator = network,
                    CreatedAt = dateTimeNow,
                    UpdatedAt = dateTimeNow,
                    Tag = tag,
                };

                context.UssdSessions.Add(usd);
                context.SaveChanges();
            }
        }
    }
}

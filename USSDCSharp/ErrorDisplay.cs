using Microsoft.AspNetCore.Hosting;
using System.Collections;
using static USSDCSharp.Models.UssdModel;

namespace USSDCSharp
{
    public class ErrorDisplay
    {
        ArrayList menuList = new ArrayList();

        public UssdResponse ussdStatusResponse()
        {
            var resp = new UssdResponse();

            resp.Message = AppSettings.DisableAppMsg.ToString();
            resp.Type = "Release";

            return resp;
        }

        public UssdResponse ussdTestResponse()
        {
            var resp = new UssdResponse();
            resp.Message = "Welcome to PHCCU USSD Mobile Service.\n Access Denied";
            resp.Type = "Release";
            return resp;
        }

        public UssdResponse ussdDebugResponse()
        {
            var resp = new UssdResponse();
            resp.Message = AppSettings.DebugMsg.ToString();
            resp.Type = "Release";
            return resp;
        }


        public UssdResponse ussdBlockedResponse()
        {
            var resp = new UssdResponse();

            resp.Message = "Sorry, You are unable to access Service. Kindly contact our Customer care Center. Thank you.";
            resp.Type = "Release";
            return resp;
        }


        public UssdResponse ussdErrorhandler_Response()
        {
            var resp = new UssdResponse();

            resp.Type = "Release";
            resp.Message = "Sorry, unable to process request. Kindly try again later.";
            return resp;
        }
    }
}

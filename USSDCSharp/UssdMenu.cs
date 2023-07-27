using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using System.Security.Principal;
using USSDCSharp.DBContext;
using USSDCSharp.Models;
using static USSDCSharp.Models.UssdModel;

namespace USSDCSharp
{
    public class UssdMenu
    {
        public async Task<UssdResponse> UssdResponseAsync(string msg, string network, string msisdn, string typeValue, string sessionValue)
        {
            var resp = new UssdResponse();
            string shortCode = AppSettings.ShortCode;

            DateTime dateTimeNow = DateTime.Now;
            var context = new UssdDBContext();

            //initial request
            //if (msg.Equals(shortCode) && typeValue.ToLower().Equals("initiation"))
            if (typeValue.ToLower().Equals("initiation"))
            {

                try
                {
                    //resp.Message = "Welcome to DUNTACCU Test ussd\n1.Continue\n2. Cancel";
                    resp.Message = "Welcome to our USSD Service\n";
                    resp.Message += "\n";
                    resp.Message += "1. Register\n";
                    resp.Message += "2. Deposit\n";
                    resp.Message += "3. Withdraw\n";
                    resp.Type = "Response";


                    UssdSession.SaveSession(typeValue , sessionValue, msisdn, network, msg, "initiation");
                        
                    return resp;

                }
                catch (Exception ex)
                {
                    resp.Message = "Sorry something went wrong";
                    resp.Type = "Response";
                }

            }
            else
            {
                var us_sessions = await context.UssdSessions
                .Where(s => s.SessionId == sessionValue)
                .OrderBy(d => d.CreatedAt)
                .ToListAsync();


                var last_session = us_sessions.Last();

                //Register menu
                if ((last_session.Tag.Equals("initiation")) && msg.ToString().Equals("1") && typeValue.ToLower() == "response"  )
                {
                        resp.Message = "Enter your first name\n";
                        resp.Type = "Response";

                        UssdSession.SaveSession(typeValue, sessionValue, msisdn, network, msg, "Register");
                    return resp;
                }

                //Deposit menu
                else if ((last_session.Tag.Equals("initiation")) && msg.ToString().Equals("2") && typeValue.ToLower() == "response")
                {

                    resp.Message = "Enter amount to deposit\n";
                    resp.Type = "Response";


                    UssdSession.SaveSession(typeValue, sessionValue, msisdn, network, msg, "Register");
                    return resp;
                }

                //Withdraw menu
                else if ((last_session.Tag.Equals("initiation")) && msg.ToString().Equals("3") && typeValue.ToLower() == "response")
                {

                    resp.Message = "Enter withdrawal amount\n";
                    resp.Type = "Response";

                    UssdSession.SaveSession(typeValue, sessionValue, msisdn, network, msg, "Withdraw");
                    return resp;
                }

                //REGISTER MENUS

                else if (last_session.Tag.Equals("Register") )
                {
                    resp.Message = "Enter your last name\n";
                    resp.Type = "Response";

                    UssdSession.SaveSession(typeValue, sessionValue, msisdn, network, msg, "Register.Firstname");
                    return resp;
                }
                else if (last_session.Tag.Equals("Register.Firstname"))
                {
                    var firstname = us_sessions.Where(s => s.Tag.Equals("Register.Firstname"))
                        .FirstOrDefault();
                    string lastname = msg.ToString(); 

                    resp.Message = "Confirm details\n";
                    resp.Message+= $"Firstname: {firstname.Message.ToString()}\n";
                    resp.Message += $"Lastname: {msg.ToString()}\n";
                    resp.Message += $"1: Confirm\n";
                    resp.Type = "Response";

                    UssdSession.SaveSession(typeValue, sessionValue, msisdn, network, msg, "Register.Lastname");
                    return resp;
                }
                else if (last_session.Tag.Equals("Register.Lastname"))
                {
                    var firstname = us_sessions.Where(s => s.Tag.Equals("Register.Firstname"))
                        .FirstOrDefault();
                    var lastname = us_sessions.Where(s => s.Tag.Equals("Register.Lastname"))
                        .FirstOrDefault();

                    //Post user details to API

                    resp.Message = "Registration successful\n";
                    resp.Type = "Release";

                    UssdSession.SaveSession(typeValue, sessionValue, msisdn, network, msg, "Register.Complete");
                    return resp;
                }

                //END REGISTER MENUS



            }

            return resp;
        }

    }
}

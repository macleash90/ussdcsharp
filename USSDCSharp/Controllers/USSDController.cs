using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Web.Http;

using Microsoft.AspNetCore.Http;
//using Smsgh.UssdFramework.Stores;
using Microsoft.AspNetCore.Hosting;
using static USSDCSharp.Models.UssdModel;
using USSDCSharp.DBContext;

namespace USSDCSharp.Controllers
{
    [System.Web.Http.Route("api/[controller]")]
    [ApiController]
    public class USSDController : ControllerBase
    {

        //[Microsoft.AspNetCore.Mvc.HttpPost]
        [Microsoft.AspNetCore.Mvc.HttpPost("api/Ussd")]
        public async Task<ActionResult> Index(UssdRequestData ussdRequest)
        {
            try
            {

                //return Ok(await Ussd.Process(new RedisStore("localhost"), request, "Main", "Start"));
                //return Ok( new { message = "Welcome" });

                    var DisplayResult = new Models.UssdModel.UssdResponse();
                    //var modelState = new UssdFunctions();
                    //var ussdFunction = new UssdFunctions();
                    var respStatusError = new ErrorDisplay();
                var respStatus = new UssdMenu();


                    //string AppMode = Startup.AppMode;
                    //string AppStatus = Startup.AppStatus;
                    //string AllowedMsisdn = Startup.AllowedMsisdn;
                    //string BlockMsisdn = Startup.BlockMsisdn;
                    DateTime dateTimeNow = DateTime.Now;

                    try
                    {

                        // Fetch Allowed Msisdn
                        //string[] openMsisdn = AllowedMsisdn.Split(',');
                        //List<string> accessMsisdn = new List<string>(openMsisdn);


                        // Fetch Blocked Msisdn from Config
                        //string[] BMsisdn = BlockMsisdn.Split(',');
                        //List<string> blackKistMsisdn = new List<string>(BMsisdn);


                        //Check is App is Disabled
                        //if (AppStatus.Equals("DISABLE"))
                        //{
                        //    //return Ok((UssdRequestData.Mobile, respStatusError.ussdStatusResponse()));
                        //    return Ok((UssdRequestData.Mobile, respStatusError.ussdStatusResponse()));
                        //}

                        //Check if Msisdn is Blocked
                        var context = new UssdDBContext();
                        //get the list of blacklist numbers that are not tagged as deleted
                        
                        //if (blackKistMsisdn.Contains(UssdRequestData.Mobile))
                        //{
                        //    //return Ok((UssdRequestData.Mobile, respStatusError.ussdBlockedResponse()));
                        //    return Ok(respStatusError.ussdBlockedResponse());
                        //}

                        // Check Application Mode and Number has been whitelisted
                        /*
                        if (AppMode.Equals("TEST") && !accessMsisdn.Contains(UssdRequestData.Mobile))
                        {
                            return Ok((UssdRequestData.Mobile, respStatusError.ussdTestResponse()));
                        }

                        // in Maintanance Mode ..only whitelisted msisdn can access it 
                        if (AppMode.Equals("DEBUG") && !accessMsisdn.Contains(UssdRequestData.Mobile))
                        {
                            return Ok((UssdRequestData.Mobile, respStatusError.ussdDebugResponse()));
                        }
                        */

                        try
                        {

                            //JObject json = JObject.Parse(state.getSession(msisdn));

                            //DisplayResult = respStatus.UssdResponse(msg, network, msisdn, state.getSession("state"));
                            //if(UssdRequestData.firstName != null && UssdRequestData.Type != "initiation")
                            //{
                            //var objResp2 = respStatus.UssdResponse(UssdRequestData.Message, UssdRequestData.Operator, UssdRequestData.Mobile, UssdRequestData.Type);
                            //return Ok(objResp2);  
                            //}

                            var objResp = await respStatus.UssdResponseAsync(ussdRequest.Message, ussdRequest.Operator, ussdRequest.Mobile, ussdRequest.Type, ussdRequest.SessionId);

                            return Ok(objResp);

                        }
                        catch (Exception e)
                        {

                            //Console.WriteLine(":::Error occured ::::" + e.StackTrace);
                            //Log.Error(e, $"Error, Phone: {UssdRequestData.Mobile} , " +
                            //            $" Session: {UssdRequestData.SessionId}, Time: {dateTimeNow} ");
                            return Ok((ussdRequest.Mobile, respStatusError.ussdErrorhandler_Response()));
                        }


                    }
                    catch (Exception e)
                    {
                        //Console.WriteLine(":::Error occured ::::" + e.StackTrace);
                        //Log.Error(e, $"Error, Phone: {ussdRequest.Mobile} , " +
                        //                $" Session: {ussdRequest.SessionId}, Time: {dateTimeNow} ");
                        return Ok((ussdRequest.Mobile, respStatusError.ussdErrorhandler_Response()));
                    }

                
            }
            catch(NotSupportedException ex)
            {

                return BadRequest(ex);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
    }
}

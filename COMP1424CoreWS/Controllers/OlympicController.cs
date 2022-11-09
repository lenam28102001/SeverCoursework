using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;

namespace COMP1424CoreWS.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OlympicController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public OlympicResponse Post([FromForm]string jsonpayload)
        {

            try
            {
                OlympicRequest request = JsonSerializer.Deserialize<OlympicRequest>(jsonpayload);

                try
                {
                    return new OlympicResponse
                    {
                        uploadResponseCode = "SUCCESS",
                        eventName = request.eventName,
                        winnerName = request.detailList.First(w => w.medalColour == "gold").athleteName,
                        message = "well done - successfully uploaded"
                    };
                }
                catch (Exception)
                {

                    return new OlympicResponse
                    {
                        uploadResponseCode = "PARTIAL SUCCESS",
                        eventName = request.eventName,
                        winnerName = "No gold winner specified",
                        message = "The gold winner was missing"
                    };
                }




            }
            catch (Exception)
            {
                return new OlympicResponse
                {
                    uploadResponseCode = "FAILURE",
                    eventName = "",
                    winnerName = "",
                    message = "Error - The JSON payload was not in the expected format"
                };

            }

        }


        [HttpGet]
        public OlympicResponse Get(string jsonPayload)
        {
            /*return new OlympicResponse
            {
                uploadResponseCode = "SUCCESS",
                eventName = jsonPayload,
                winnerName = "bolg",
                message = "well done - successfully uploaded"
            };*/

            string returnMessage = "";


            try
            {
                OlympicRequest request = JsonSerializer.Deserialize<OlympicRequest>(jsonPayload);
                returnMessage = "well done - successfully uploaded";
            }
            catch (Exception)
            {
                returnMessage = "Error - The JSON payload was not in the expected format";
            }

            return new OlympicResponse
            {
                uploadResponseCode = "SUCCESS",
                eventName = "bla",
                winnerName = "bolg",
                message = returnMessage
            };
        }

    }
}

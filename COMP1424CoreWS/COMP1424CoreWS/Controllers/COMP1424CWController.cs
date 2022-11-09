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
    public class COMP1424CWController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public CWResponse Post([FromForm] string jsonpayload)
        {
            string namesString = "";
            try
            {
                CWRequest request = JsonSerializer.Deserialize<CWRequest>(jsonpayload);

                if (request.detailList != null && request.userId != null)
                {
                    for (int i = 0; i < request.detailList.Count; i++)
                    {
                        if (i > 0)
                        {
                            namesString += ", ";
                        }
                        namesString += request.detailList[i].name;
                    }

                    return new CWResponse
                    {
                        uploadResponseCode = "SUCCESS",
                        userId = request.userId,
                        number = request.detailList.Count,
                        names = namesString,
                        message = "successful upload – all done!"

                    };
                }
                else if(request.userId == null)
                {
                    return new CWResponse
                    {
                        uploadResponseCode = "FAILURE",
                        userId = "",
                        number = 0,
                        names = namesString,
                        message = "the userId is missing or incorrect"
                    };
                }
                else
                {
                    return new CWResponse
                    {
                        uploadResponseCode = "FAILURE",
                        userId = request.userId,
                        number = 0,
                        names = namesString,
                        message = "the detailList is missing or incorrect"
                    };
                    
                }
                    

            }
            catch (Exception)
            {
                return new CWResponse
                {
                    uploadResponseCode = "FAILURE",
                    userId = "",
                    number = 0,
                    names = namesString,
                    message = "the JSON string is in the incorrect format"
                };

            }


        }

        [HttpGet]
        public CWResponse Get(string jsonPayload)
        {
            return new CWResponse
            {
                uploadResponseCode = "FAILURE",
                message = "This web service should be called via POST"

            };

        }
    }
}

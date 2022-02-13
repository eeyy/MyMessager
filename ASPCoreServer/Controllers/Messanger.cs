using Microsoft.AspNetCore.Mvc;
using MyMessager;
using System.Collections.Generic;
using Newtonsoft.Json;
using System;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ASPCoreServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Messanger : ControllerBase
    {
        static List<Message> ListOfMesseges = new List<Message>();
        // GET api/<Messanger>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            string outputString = "Not found";
            if ((id < ListOfMesseges.Count) && (id >= 0))
            {
                outputString = JsonConvert.SerializeObject(ListOfMesseges[id]);
            }
            outputString = String.Format("Запрошено сообщение № {0} : {1}", id, outputString);
            Console.WriteLine(outputString);
            return outputString;
        }

        // POST api/<Messanger>
        [HttpPost]
        public IActionResult SendMessage([FromBody] Message msg)
        {
            if(msg == null)
            {
                return BadRequest();
            }

            ListOfMesseges.Add(msg);
            Console.WriteLine(String.Format("Всего сообщений: {0}. Посланное сообщение: {1}", ListOfMesseges.Count, msg));
            return new OkResult();
        }
    }
}

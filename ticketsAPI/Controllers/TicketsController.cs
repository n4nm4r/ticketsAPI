using Azure.Storage.Queues;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices.Marshalling;
using System.Text.Json;

namespace ticketsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketsController : ControllerBase
    {
        private readonly ILogger<TicketsController> _logger;

        private readonly IConfiguration _configuration;


        public TicketsController (ILogger<TicketsController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        [HttpGet]

        public IActionResult Get() {
            return Ok("Returned Ok (Get)");
        }


        [HttpPost]
        public async Task<IActionResult> Post(Ticket ticket) {
            //Validation

            if (ModelState.IsValid == false) { return BadRequest(ModelState); }

            //send to azure

            string queueName = "tickethub";
            // Get connection string from secrets.json
            string? connectionString = _configuration["AzureStorageConnectionString"];

            if (string.IsNullOrEmpty(connectionString))
            {
                return BadRequest("An error was encountered");
            }


            QueueClient queueClient = new QueueClient(connectionString, queueName);

            // serialize an object to json
            string message = JsonSerializer.Serialize(ticket);
           

            // send string message to queue
            await queueClient.SendMessageAsync(message);

            return Ok("Returned Ok (Post)\n" + ticket.Quantity + " tickets for " + ticket.Name);
        }



    }
}

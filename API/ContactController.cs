using AssesementWebAPI.Domain.Models;
using AssesementWebAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.Net;
using System.Net.WebSockets;

namespace AssesementWebAPI.API
{

    [Route("api/[controller]")]
    [ApiController]
    [Authorize]

    public class ContactController : ControllerBase
    {
        private readonly IContactCommand _contactCommandService;
        private readonly IContactQuery _contactQueryService;
        private readonly ILogger<ContactController> _logger;
        public ContactController(IContactCommand contactCommand, IContactQuery contactQuery, ILogger<ContactController> logger)
        {
            _contactCommandService = contactCommand;
            _contactQueryService = contactQuery;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<List<Contact>>> GetAllContact()
        {
            try
            {
                _logger.LogInformation("Get All Contact Method Called");
                var results =  await _contactQueryService.GetAllContact();
                Response response = new Response
                {
                    Status = "Success",
                    Message = "",
                    Data = results
                };
                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message);
                string message = ex.Message;
                Response response = new Response
                {
                    Status = "Failed",
                    Message = message,
                    Data = null
                };
                return Ok(response);
            }

        }


        [HttpGet("{id}")]
        public async Task<ActionResult<List<Contact>>> GetContactById(int id)
        {
            try
            {
                _logger.LogInformation("Get  Contact by id Method Called");
                var results = await _contactQueryService.GetContactById(id);
                Response response = new Response
                {
                    Status = "Success",
                    Message = "",
                    Data = results
                };
                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Get All Contact Method Called");
                string message = ex.Message;
                Response response = new Response
                {
                    Status = "Failed",
                    Message = message,
                    Data = null
                };
                return Ok(response);
            }

        }



        [HttpPost]
        public async Task<ActionResult<List<Contact>>> AddContact(Contact contact)
        {
            try
            {
                _logger.LogInformation("Add Contact Method Called");
                var results = await _contactCommandService.AddContact(contact);
                Response response = new Response
                {
                    Status = "Success",
                    Message = "",
                    Data = results
                };
                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message);
                string message = ex.Message;
                Response response = new Response
                {
                    Status = "Failed",
                    Message = message,
                    Data = null
                };
                return Ok(response);
            }

        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<Contact>>> UpdateContact(int id,Contact contact)
        {
            try
            {
                _logger.LogInformation("Update Contact Method Called");
                var results = await _contactCommandService.UpdateContact(id,contact);
                Response response = new Response
                {
                    Status = "Success",
                    Message = "",
                    Data = results
                };
                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message);
                string message = ex.Message;
                Response response = new Response
                {
                    Status = "Failed",
                    Message = message,
                    Data = null
                };
                return Ok(response);
            }

        }
    }
}

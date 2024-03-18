using AssesementWebAPI.Domain.Models;
using AssesementWebAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AssesementWebAPI.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly IContactCommand _contactCommandService;
        private readonly IContactQuery _contactQueryService;
        private readonly ITokenQuery _tokenQueryService;
        private readonly ILogger<ContactController> _logger;

        public TokenController(IContactCommand contactCommandService, IContactQuery contactQueryService, ILogger<ContactController> logger,
            ITokenQuery tokenQueryService)
        {
            _contactCommandService = contactCommandService; 
            _contactQueryService = contactQueryService;
            _tokenQueryService = tokenQueryService;
            _logger = logger;
        }

        [HttpGet]
        //public Task<ActionResult<Response>> GetToken()
        //{
        //    try
        //    {
        //        _logger.LogInformation("Get Token Method Called");
        //        var results =  _tokenQueryService.GetToken();
        //        Response response = new Response
        //        {
        //            Status = "Success",
        //            Message = "",
        //            Data = results
        //        };
        //        return Ok(response);
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogInformation(ex.Message);
        //        string message = ex.Message;
        //        Response response = new Response
        //        {
        //            Status = "Failed",
        //            Message = message,
        //            Data = null
        //        };
        //        return Ok(response);
        //    }

        //}

        public async Task<ActionResult<Response>> GetToken()
        {
            try
            {
                _logger.LogInformation("Get Token Method Called");
                var results = await _tokenQueryService.GetToken();
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

using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using Customer.Information.Query.Requests;

namespace CustomerInformation.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerInformationController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CustomerInformationController( IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("updatecustomerinformation")]
        public async Task<IActionResult> UpdateCustomerInformation([FromBody] Customer.Command.CustomerInformation.Update.UpdateRequest command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }


        [HttpPost("createcustomerinformation")]
        public async Task<IActionResult> CreateCustomerInformation([FromBody] Customer.Command.CustomerInformation.Create.CreateRequest command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpPost("deletecustomerinformation")]
        public async Task<IActionResult> DeleteCustomerInformation([FromBody] Customer.Command.CustomerInformation.Delete.DeleteRequest command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpGet("getcustomerinformation/{customerRef}")]
        public async Task<IActionResult> GetCustomerInformation(int customerRef)
        {
            var response = await _mediator.Send(new GetCustomerInformationQueryRequest { CustomerRef = customerRef });
            return Ok(response);
        }

        [HttpPost("listcustomerinformation")]
        public async Task<IActionResult> ListCustomerInformation([FromBody]  ListCustomerInformationRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }


    }
}

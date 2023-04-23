
using Customer.Information.CommandHandler;
using CustomerInformation.Core.CQRS.Domain;
using CustomerInformation.Core.CQRS.Handlers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerInformation.API.Customer.Command.CustomerInformation.Update
{

    public class RequestHandler : CommandHandlerBaseAsync<UpdateRequest>
    {

        private readonly CommandContext _commandContext;

        public RequestHandler(CommandContext commandContext)
        {

            _commandContext = commandContext;

        }

        protected override async Task<CommandResult> HandleCore(UpdateRequest command)
        {
            var returnValue = new CommandResult() { IsSuccess = false };
            
            try
            {
                var resp = await (from pi in _commandContext.tb_CustomerInformation

                                  where pi.CustomerRef == command.CustomerRef
                                  select pi
                                        ).FirstOrDefaultAsync();


                resp.FirstName = command.FirstName;
                resp.LastName = command.LastName;
                resp.IdentificationNumber = command.IdentificationNumber;
                resp.DateOfBirth = command.DateOfBirth;

                KPSServiceReference.KPSPublicSoapClient client = new KPSServiceReference.KPSPublicSoapClient(new KPSServiceReference.KPSPublicSoapClient.EndpointConfiguration());

                var result = await client.TCKimlikNoDogrulaAsync(resp.IdentificationNumber, resp.FirstName, resp.LastName, resp.DateOfBirth.Year);

                if (result.Body.TCKimlikNoDogrulaResult)
                {
                    _commandContext.Add(resp);
                    _commandContext.SaveChanges();
                    returnValue.Message = "";
                    returnValue.IsSuccess = true;
                }
                else
                {
                    returnValue.Message = "Identification number could not be verified.";
                    returnValue.IsSuccess = false;
                }
            }
            catch (Exception ex)
            {
                returnValue.Message = ex.Message;
                returnValue.IsSuccess = false;
            }
            return returnValue;
        }
    }
}

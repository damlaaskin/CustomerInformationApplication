using Customer.Information.Data.Access.Tables;
using CustomerInformation.API.Customer.Command.CustomerInformation.Create;
using CustomerInformation.Core.CQRS.Domain;
using CustomerInformation.Core.CQRS.Handlers;
using System;
using System.Threading.Tasks;

namespace Customer.Information.CommandHandler.CustomerInformation.Create
{

    public class RequestHandler : CommandHandlerBaseAsync<CreateRequest>
    {

        private readonly CommandContext _commandContext;

        public RequestHandler(CommandContext commandContext)
        {

            _commandContext = commandContext;

        }

        protected override async Task<CommandResult> HandleCore(CreateRequest command)
        {
            var returnValue = new CommandResult() { IsSuccess = false };

            try
            {
                var resp = new tb_CustomerInformation()
                {
                    FirstName = command.FirstName,
                    LastName = command.LastName,
                    IdentificationNumber = command.IdentificationNumber,
                    DateOfBirth = command.DateOfBirth
                };


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

                return returnValue;
            }

            return returnValue;
        }
    }
}

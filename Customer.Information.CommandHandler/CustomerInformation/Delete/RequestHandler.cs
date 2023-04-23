using Customer.Information.CommandHandler;
using CustomerInformation.Core.CQRS.Domain;
using CustomerInformation.Core.CQRS.Handlers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerInformation.API.Customer.Command.CustomerInformation.Delete
{
    public class RequestHandler : CommandHandlerBaseAsync<DeleteRequest>
    {

        private readonly CommandContext _commandContext;

        public RequestHandler(CommandContext commandContext)
        {

            _commandContext = commandContext;

        }

        protected override async Task<CommandResult> HandleCore(DeleteRequest command)
        {
           
            var returnValue = new CommandResult() { IsSuccess = false };
            try
            {

                var resp = await (from ci in _commandContext.tb_CustomerInformation

                                  where ci.CustomerRef == command.CustomerRef
                                  select ci
                                         ).FirstOrDefaultAsync();

                resp.IsDeleted = true;
                resp.ModifiedDate = DateTime.Now;
                _commandContext.Update(resp);
                await _commandContext.SaveChangesAsync();
                returnValue.Message = "";
                returnValue.IsSuccess = true;
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

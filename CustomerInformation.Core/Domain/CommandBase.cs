
using System;
using System.Collections.Generic;
using System.Text;
using CustomerInformation.Core.CQRS.Contracts;
using MediatR;

namespace HR.Harmony.Core.CQRS.Domain
{
    public abstract class CommandBase : ICommand
    {
        public DateTime Timestamp => DateTime.Now;
    }
}
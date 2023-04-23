
using CustomerInformation.Core.CQRS.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerInformation.Core.CQRS.Domain
{
    public abstract class QueryBase<TResponse> : IQuery<TResponse>
    {
    }
}
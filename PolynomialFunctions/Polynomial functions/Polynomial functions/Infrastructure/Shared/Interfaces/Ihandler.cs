using Polynomial.Infrastructure.Shared.Processes;
using System;
using System.Collections.Generic;
using System.Text;


namespace Polynomial.Infrastructure.Shared.Interfaces
{
    public interface IHandler
    {
        IHandler SetNext(IHandler handler);
        ContextHandler Handle(ContextHandler request);
    }
}

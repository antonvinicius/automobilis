using Automobilis.Domain.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automobilis.Domain.Handlers
{
    public interface IHandler<T>
    {
        Task<GenericResult> Handle(T command);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Extensions.DependencyInjection;

internal sealed class ErrorHandlingOptions<T>
{
    public void Map<TInException, TOutException>(Func<TInException, TOutException> mapping, Func<TInException, bool> predicate) 
        where TInException : Exception
        where TOutException : Exception
    {

    }

}

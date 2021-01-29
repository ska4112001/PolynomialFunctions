using System;
using System.Collections.Generic;
using System.Text;

namespace Polynomial.Infrastructure.Shared.Processes
{
    public class CheckIfSolutionHandler : BaseHandler
    {
        public override ContextHandler Handle(ContextHandler request)
        {
            if (request.AugmentedMatrix.Array[request.AugmentedMatrix.NumberOfRows - 1, request.AugmentedMatrix.NumberOfColums - 1] == 0)
            {
                bool all_zeros = true;
                for (int currentColumn = 0; currentColumn <= request.AugmentedMatrix.NumberOfColums + 1; currentColumn++)
                {
                    if (request.AugmentedMatrix.Array[request.AugmentedMatrix.NumberOfRows - 1, currentColumn] != 0)
                    {
                        all_zeros = false;
                        break;
                    }
                }
                if (all_zeros)
                {
                    request.Errors = true;
                    request.Result = "Invalid Solution";
                }
                else
                {
                    request.Errors = true;
                    request.Result = "No Solution";
                }
            }
            return base.Handle(request);
        }
    }
}

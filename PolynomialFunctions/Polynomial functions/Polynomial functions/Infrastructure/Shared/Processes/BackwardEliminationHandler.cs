using System;
using System.Collections.Generic;
using System.Text;

namespace Polynomial.Infrastructure.Shared.Processes
{
    public class BackwardEliminationHandler : BaseHandler
    {
        public override ContextHandler Handle(ContextHandler request)
        {
            if (!request.Errors)
            {
                
                for (int currentRow = request.AugmentedMatrix.NumberOfRows - 1; currentRow >= 0; currentRow--)
                {
                    double temp = request.AugmentedMatrix.Array[currentRow, request.AugmentedMatrix.NumberOfColums];
                    for (int nextRow = currentRow + 1; nextRow < request.AugmentedMatrix.NumberOfRows; nextRow++)
                    {
                        temp -= request.AugmentedMatrix.Array[currentRow, nextRow] * request.AugmentedMatrix.Array[nextRow, request.AugmentedMatrix.NumberOfColums + 1];
                    }
                    request.AugmentedMatrix.Array[currentRow, request.AugmentedMatrix.NumberOfColums + 1] = temp / request.AugmentedMatrix.Array[currentRow, currentRow];
                }
            }
            return base.Handle(request);
        }
    }
}

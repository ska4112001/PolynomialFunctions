using System;
using System.Collections.Generic;
using System.Text;

namespace Polynomial.Infrastructure.Shared.Processes
{

    public class FowardEliminationHandler : BaseHandler
    {
        public override ContextHandler Handle(ContextHandler request)
        {


            for (int currentRow = 0; currentRow < request.AugmentedMatrix.NumberOfRows - 1; currentRow++)
            {
                if (Math.Abs(request.AugmentedMatrix.Array[currentRow, currentRow]) <= 0)
                {
                    for (int nextRow = currentRow + 1; nextRow < request.AugmentedMatrix.NumberOfRows; nextRow++)
                    {
                        if (Math.Abs(request.AugmentedMatrix.Array[nextRow, currentRow]) > 0)
                        {
                            for (int curentColumn = 0; curentColumn <= request.AugmentedMatrix.NumberOfColums; curentColumn++)
                            {
                                var temp = request.AugmentedMatrix.Array[currentRow, curentColumn];
                                request.AugmentedMatrix.Array[currentRow, curentColumn] = request.AugmentedMatrix.Array[nextRow, curentColumn];
                                request.AugmentedMatrix.Array[nextRow, curentColumn] = temp;
                            }
                            break;
                        }
                    }
                }


                if (Math.Abs(request.AugmentedMatrix.Array[currentRow, currentRow]) > 0)
                {
                    for (int nextRow = currentRow + 1; nextRow < request.AugmentedMatrix.NumberOfRows; nextRow++)
                    {
                        double factor = -request.AugmentedMatrix.Array[nextRow, currentRow] / request.AugmentedMatrix.Array[currentRow, currentRow];
                        for (int currentColumn = currentRow; currentColumn <= request.AugmentedMatrix.NumberOfColums; currentColumn++)
                        {
                            request.AugmentedMatrix.Array[nextRow, currentColumn] = request.AugmentedMatrix.Array[nextRow, currentColumn] + factor * request.AugmentedMatrix.Array[currentRow, currentColumn];
                        }
                    }
                }
            }
            return base.Handle(request);
        }
    }


}

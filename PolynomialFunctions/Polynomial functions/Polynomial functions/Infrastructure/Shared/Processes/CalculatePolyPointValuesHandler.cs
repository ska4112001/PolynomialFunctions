using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Polynomial.Infrastructure.Shared.Processes
{
    public class CalculatePolyPointValuesHandler : BaseHandler
    {
        public override ContextHandler Handle(ContextHandler request)
        {
            request.poly1 = Calculate(request, -1);
            request.poly2 = Calculate(request, 0);
            request.poly3 = Calculate(request, 1);
            return base.Handle(request);
        }

        private double Calculate(ContextHandler request ,int value)
        {
            double answer = 0;
            var counter =request.AugmentedMatrix.NumberOfRows -1;
             for (int currentRow = 0; currentRow < request.AugmentedMatrix.NumberOfRows; currentRow++)
              {
                answer += request.AugmentedMatrix.Array[currentRow, request.AugmentedMatrix.NumberOfColums + 1] * (Math.Pow(value, counter));
                counter--; 
            }
            return Math.Round(answer,5);
        }
    }
}
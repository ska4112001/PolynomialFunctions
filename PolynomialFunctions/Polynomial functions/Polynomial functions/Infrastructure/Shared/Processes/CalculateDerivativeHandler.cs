using System;
using System.Collections.Generic;
using System.Text;

namespace Polynomial.Infrastructure.Shared.Processes
{
    public class CalculateDerivativeHandler : BaseHandler
    {
        public override ContextHandler Handle(ContextHandler request)
        {
            request.Derivative = new List<double>();
            var factor = request.AugmentedMatrix.NumberOfRows - 2;
            for (int currentRow =0; currentRow <= request.AugmentedMatrix.NumberOfRows - 2;  currentRow++)
            {
                var num = request.AugmentedMatrix.Array[currentRow, request.AugmentedMatrix.NumberOfColums + 1];
                var derivative = num * (1 + factor);
                request.Derivative.Add(Math.Round(derivative,5));
                factor--;
            }

                return base.Handle(request);
        }
    }
}

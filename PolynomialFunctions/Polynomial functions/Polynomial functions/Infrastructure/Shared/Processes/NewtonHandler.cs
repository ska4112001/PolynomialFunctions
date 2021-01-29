using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Polynomial.Infrastructure.Shared.Processes
{
    public class NewtonHandler : BaseHandler
    {
        public override ContextHandler Handle(ContextHandler request)
        {
            Random rand = new Random();
            request.InitialGuess = rand.Next(1,10);
            request.Root = Calculate(request, request.InitialGuess);
            return base.Handle(request);
        }

        private double PolyFunction(ContextHandler request, double initialGuess)
        {
            double answer = 0;
            var counter = request.AugmentedMatrix.NumberOfRows - 1;
            for (int currentRow = 0; currentRow < request.AugmentedMatrix.NumberOfRows; currentRow++)
            {
                if (counter > 0)
                {
                    answer += request.AugmentedMatrix.Array[currentRow, request.AugmentedMatrix.NumberOfColums + 1] * (Math.Pow(initialGuess, counter));
                }
                else
                {
                    answer += request.AugmentedMatrix.Array[currentRow, request.AugmentedMatrix.NumberOfColums + 1];
                }
                counter--;
            }
            return Math.Round(answer, 5);
        }

        private double DerivativeFunction(ContextHandler request, double initialGuess)
        {
            double answer = 0;
            var counter = request.Derivative.Count() - 1;
            for (int currentRow = 0; currentRow < request.Derivative.Count(); currentRow++)
            {
                if (counter > 0)
                {
                    answer += request.Derivative[currentRow] * (Math.Pow(initialGuess, counter));
                }
                else
                {
                    answer += request.Derivative[currentRow];
                }
                counter--;
            }
            return Math.Round(answer, 5);
        }

        private double Calculate(ContextHandler request, double initialGuess)
        {
            double answer = PolyFunction(request, initialGuess) / DerivativeFunction(request, initialGuess);
            const float constant = 0.001F;
            while (Math.Abs(answer) >= constant)
            {
                answer = PolyFunction(request, initialGuess) / DerivativeFunction(request, initialGuess);
                initialGuess = initialGuess - answer;
            }

            return Math.Round(initialGuess,5);
        }
    }
}

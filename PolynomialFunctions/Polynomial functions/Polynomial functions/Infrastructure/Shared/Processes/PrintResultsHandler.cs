using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Polynomial.Infrastructure.Shared.Processes
{
    public class PrintResultsHandler : BaseHandler
    {
        public override ContextHandler Handle(ContextHandler request)
        {
            if (!request.Errors)
            {

                request.Result += Environment.NewLine;
                request.Result += Environment.NewLine;
                request.Result += $"Calculated Polynomial {Environment.NewLine}";
                request.Result += "f(x) = ";
                var counter = request.AugmentedMatrix.NumberOfRows - 1;
                for (int currentRow = 0; currentRow < request.AugmentedMatrix.NumberOfRows; currentRow++)
                {
                    if (currentRow == 0)
                    {
                        request.Result += $"{Math.Round(request.AugmentedMatrix.Array[currentRow, request.AugmentedMatrix.NumberOfColums + 1], 5).ToString()}x^{counter}";
                    }
                    else
                    {
                        var sign = "";
                        var xvalue = "";
                        xvalue = counter > 0 ? $"x^{counter}" : "";
                        sign = request.AugmentedMatrix.Array[currentRow, request.AugmentedMatrix.NumberOfColums + 1] > 0 ? " + " : " ";
                        request.Result += $"{sign}{Math.Round(request.AugmentedMatrix.Array[currentRow, request.AugmentedMatrix.NumberOfColums + 1], 5).ToString()} {xvalue}";
                    }
                    counter--;
                }

                PrintPolynomialValues(request);
                PrintDerivativeValues(request);
                PrintRoot(request);
            }

            Console.WriteLine(request.Result);
            return base.Handle(request);
        }

        private  void PrintPolynomialValues(ContextHandler request)
        {
            request.Result += Environment.NewLine;
            request.Result += $"f(-1) = {request.poly1} {Environment.NewLine}";
            request.Result += $"f(0) = {request.poly2} {Environment.NewLine}";
            request.Result += $"f(1) = {request.poly3} {Environment.NewLine}";
        }
        private  void PrintDerivativeValues(ContextHandler request)
        {
           
            
            request.Result += Environment.NewLine;
            request.Result += $"Derivative {Environment.NewLine}";
            request.Result += "f'(x) = ";
            var counter = request.Derivative.Count() - 1;
            for (int i = 0; i < request.Derivative.Count();i++)
            {
                var sign = "";
                var xvalue = "";
                xvalue = counter > 0 ? $"x^{counter}" : "";
                if (i == 0)
                {
                    request.Result += $"{(request.Derivative[i]).ToString()} {xvalue}";
                }
                else
                {
                    sign = request.Derivative[i] > 0 ? " + " : " ";
                    request.Result += $"{sign}{(request.Derivative[i]).ToString()} {xvalue}";
                }
                counter--;
            }
        }

        private void PrintRoot(ContextHandler request)
        {
            request.Result += Environment.NewLine;
            request.Result += $"Looking for Root with Guess {request.InitialGuess} {Environment.NewLine}";
            request.Result += $"Root Found for x is {request.Root}";

        }
    }
}

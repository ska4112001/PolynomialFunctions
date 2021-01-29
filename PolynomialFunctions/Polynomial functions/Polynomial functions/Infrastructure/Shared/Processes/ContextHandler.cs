using Polynomial.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Polynomial.Infrastructure.Shared.Processes

{
    public class ContextHandler
    {
        public Matrix AugmentedMatrix { get; set; }
        public double poly1 { get; set; }
        public double poly2 { get; set; }
        public double poly3 { get; set; }
        public List<double> Derivative { get; set; }
        public bool Errors { get; set; }
        public string Result { get; set; }
        public double Root { get; set; }
        public double InitialGuess { get; set; }
    }
}

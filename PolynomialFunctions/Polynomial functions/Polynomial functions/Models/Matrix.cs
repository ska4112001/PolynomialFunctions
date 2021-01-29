using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Polynomial.Models
{
    public class Matrix
    {
        public  double[,] Array { get;  set; }
        public int NumberOfRows { get;  set; }
        public int NumberOfColums { get;  set; }
       
        public  static Matrix Matrice { get; set; } = new Matrix();


        public static Matrix CreateAugmentedMAtrix(string coefficients, string constants)
        {

            string[] constantsArray, coefficientsArray;
            if (!CreateArrayAndValidate(coefficients, constants, out constantsArray, out coefficientsArray))
            {
                return null;
            }
            if (coefficientsArray == null) return null;
            var firstRow = coefficientsArray[0].Split(" ", StringSplitOptions.RemoveEmptyEntries);
            if (!SetMaxtrixNoRowsAndColumns(constantsArray, coefficientsArray))
            {
                Console.WriteLine("Number of equations is not equal to the number of variables");
                return null;
            }
            Matrice.Array = new double[Matrice.NumberOfRows, Matrice.NumberOfColums + 2];

            for (int rowNum = 0; rowNum < Matrice.NumberOfRows; rowNum++)
            {
                firstRow = coefficientsArray[rowNum].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                for (int columnNumber = 0; columnNumber < Matrice.NumberOfColums; columnNumber++)
                {
                     Matrice.Array[rowNum, columnNumber] = double.Parse(firstRow[columnNumber]);
                }
                Matrice.Array[rowNum, Matrice.NumberOfColums] = double.Parse(constantsArray[rowNum]);
            }
            return Matrice;
        }

        private static bool SetMaxtrixNoRowsAndColumns(string[] constantsArray, string[] coefficientsArray)
        {
            Matrice.NumberOfRows = coefficientsArray.GetUpperBound(0) + 1;
            Matrice.NumberOfColums = constantsArray.GetUpperBound(0) + 1;
            if (Matrice.NumberOfColums != Matrice.NumberOfRows)
            {
                return false;
            }
            return true;
        }

        private static bool CreateArrayAndValidate(string coefficients, string constants, out string[] constantsArray, out string[] coefficientsArray)
        {
            constantsArray = constants?.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
            coefficientsArray = coefficients?.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
            return true;
        }


    }
}

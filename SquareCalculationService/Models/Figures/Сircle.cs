using SquareCalculationService.Exceptions;
using System;
using System.Linq;

namespace SquareCalculationService.Models.Figures
{
    /// <summary>
    /// Круг
    /// </summary>
    public class Circle : IFigure
    {
        /// <summary>
        /// 1 параметр - радиус
        /// </summary>
        public int ParamsNumber => 1;

        /// <summary>
        /// Расчет площади круга
        /// </summary>
        /// <param name="parameters">1 параметр - радиус</param>
        /// <returns>Величина площади круга</returns>
        public double CalculateFigureSquare(params double[] parameters)
        {
            if (parameters == null || !parameters.Any())
                throw new ArgumentNullException(nameof(parameters));

            if (parameters.Length != ParamsNumber)
                throw new ParamsWrongNumberException(parameters.Length, ParamsNumber);

            return Math.PI * Math.Pow(parameters.FirstOrDefault(), 2); 

        }
    }
}

using SquareCalculationService.Exceptions;
using SquareCalculationService.Models;
using System;
using System.Linq;

namespace SquareCalculationService.Tests.Models.Figures
{
    /// <summary>
    /// Трапеция
    /// </summary>
    public class Trapeze : IFigure
    {
        /// <summary>
        /// 3 Параметра: длины двух оснований и длина высоты
        /// </summary>
        public int ParamsNumber => 3;

        /// <summary>
        /// Расчитать площадь трапеции
        /// </summary>
        /// <param name="parameters">3 Параметра: длины двух оснований и длина высоты</param>
        /// <returns>Площадь трапеции</returns>
        public double CalculateFigureSquare(params double[] parameters)
        {
            if (parameters == null || !parameters.Any())
                throw new ArgumentNullException(nameof(parameters));

            if (parameters.Length != ParamsNumber)
                throw new ParamsWrongNumberException(parameters.Length, ParamsNumber);

            return ((parameters[0] + parameters[1])/2 ) * parameters[2];
        }
    }
}

using System;
using System.Linq;
using SquareCalculationService.Exceptions;

namespace SquareCalculationService.Models.Figures
{
    /// <summary>
    /// Треугольник
    /// </summary>
    public class Triangle : IFigure
    {
        /// <summary>
        /// Кол-во параметров, необходимых для работы с фигурой
        /// </summary>
        public int ParamsNumber => 3;

        /// <summary>
        /// Расчет площади
        /// </summary>
        /// <param name="parameters">Принимает 3 параметра - длины сторон треугольника</param>
        /// <returns>Площадь</returns>
        public double CalculateFigureSquare(params double[] parameters)
        {
            CheckForException(parameters);
            var halfPerimeter = GetHalfPerimeter(parameters);
            return Math.Sqrt(GetRootExpression(halfPerimeter, parameters));
        }

        /// <summary>
        /// Является ли треугольник прямоугольным?
        /// </summary>
        /// <param name="parameters">Принимает 3 параметра - длины сторон треугольника</param>
        /// <returns>Является ли треугольник прямоугольным?</returns>
        public bool IsRight(params double[] parameters)
        {
            CheckForException(parameters);
            var hypotenuse = parameters.Max();
            var cathetOne = parameters.Min();
            var cathetTwo = parameters.Except(new double[] { hypotenuse, cathetOne })?.FirstOrDefault();
            return cathetTwo.HasValue ?
                Math.Pow(hypotenuse, 2) == Math.Pow(cathetOne, 2) + Math.Pow(cathetTwo.Value, 2) :
                Math.Pow(hypotenuse, 2) == 2 * Math.Pow(cathetOne, 2);
        }

        #region Private members

        /// <summary>
        /// Проверка параметров
        /// </summary>
        /// <param name="parameters">Принимает 3 параметра - длины сторон треугольника</param>
        private void CheckForException(double[] parameters)
        {
            if (parameters == null || !parameters.Any())
                throw new ArgumentNullException(nameof(parameters));

            if (parameters.Length != ParamsNumber)
                throw new ParamsWrongNumberException(parameters.Length, ParamsNumber);
        }

        /// <summary>
        /// Получение полупериметра
        /// </summary>
        /// <param name="parameters">Принимает 3 параметра - длины сторон треугольника</param>
        /// <returns>Величина полупериметра</returns>
        private double GetHalfPerimeter(params double[] parameters)
        {
            return parameters.Sum() / 2;
        }

        /// <summary>
        /// Расчитать результат подкоренного выражения
        /// </summary>
        /// <param name="halfPerimeter">Величина полупериметра</param>
        /// <param name="parameters">Принимает 3 параметра - длины сторон треугольника</param>
        /// <returns>Результат подкоренного выражения</returns>
        private double GetRootExpression(double halfPerimeter, double[] parameters)
        {
            var result = halfPerimeter;
            foreach (var parameter in parameters)
            {
                result *= halfPerimeter - parameter;
            }
            return result;
        }

        #endregion Private members
    }
}

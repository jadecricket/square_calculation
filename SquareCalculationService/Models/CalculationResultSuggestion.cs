using System;

namespace SquareCalculationService.Models
{
    /// <summary>
    /// Предположение о площади фигуры
    /// </summary>
    public class CalculationResultSuggestion
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="type">Тип фигуры</param>
        /// <param name="square"></param>
        public CalculationResultSuggestion(IFigure figure, params double[] parameters)
        {
            var type = figure.GetType();
            Type = type;
            Name = type.Name;
            Square = figure.CalculateFigureSquare(parameters);
        }

        public string Name { get; }

        public double Square { get;}
        public Type Type { get; }
    }
}

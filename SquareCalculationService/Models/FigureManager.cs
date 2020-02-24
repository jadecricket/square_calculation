using SquareCalculationService.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using SquareCalculationService.Extensions;

namespace SquareCalculationService.Models
{
    /// <summary>
    /// Менеджер по работе с фигурами
    /// </summary>
    public class FigureManager
    {
        private readonly IEnumerable<IFigure> _figures;
        
        private FigureManager()
        {
            _figures = SquareCalculationExtension.GetAllFigures();
        }

        private static readonly Lazy<FigureManager> _instance = 
            new Lazy<FigureManager>(() => new FigureManager());

        /// <summary>
        /// Экземпляр менеджера
        /// </summary>
        public static FigureManager Instance => _instance.Value;

        /// <summary>
        /// Сформулировать предположение о площади фигуры
        /// </summary>
        /// <param name="parameters">Параметры для расчета</param>
        /// <returns>Список предположений о площади фигуры</returns>
        public IEnumerable<CalculationResultSuggestion> CalculateFigureSquare(params double[] parameters)
        {
            if (parameters == null || !parameters.Any())
                throw new ArgumentNullException(nameof(parameters));

            if (_figures == null || !_figures.Any())
                throw new SquareCalculationException(
                    $"Не найдены реализации интерфейса {nameof(IFigure)}");

            var selectedFigures =
                _figures?.Where(type => type.ParamsNumber == parameters.Length);

            return selectedFigures?.Select(s => 
                new CalculationResultSuggestion(s, parameters));
        }
    }

    /// <summary>
    /// Менеджер по работе с фигурами
    /// </summary>
    /// <typeparam name="T">Тип фигуры</typeparam>
    public class FigureManager<T>  where T : class, IFigure, new()
    {
        private FigureManager() 
        {
        }

        private static readonly Lazy<T> _instance = new Lazy<T>(() => new T());

        /// <summary>
        /// Экземпляр фигуры
        /// </summary>
        public static T Instance => _instance.Value;
    }
}

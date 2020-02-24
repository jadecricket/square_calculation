using SquareCalculationService.Exceptions;
using SquareCalculationService.Models;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace SquareCalculationService.Tests
{
    /// <summary>
    /// Общий тест для всех реализаций интерфейса IFigure
    /// </summary>
    public class GlobalTest
    {
        /// <summary>
        /// Проверка на существование реализаций интерфейса IFigure
        /// </summary>
        [Fact]
        public void TestForIFigureImplsExistance()
        {
            var figures = 
                UnitSquareCalculationExtension
                .GetAllFigures();

            Assert.NotNull(figures);
            Assert.NotEmpty(figures);
        }

        /// <summary>
        /// Проверить, что в реализациях метода GetInitialiationParams 
        /// вызывается исключение в случае, 
        /// если число переданных параметров не соответсвует ожидаемому
        /// </summary>
        [Fact]
        public void TestAllImplsForSquareCalculationEx()
        {
            var figures = 
                UnitSquareCalculationExtension
                .GetAllFigures();
            
            var initializationParams = GetInitialiationParams(figures).ToArray();
            foreach (var figure in figures)
            {
                Assert.Throws<ParamsWrongNumberException>(() => 
                    figure.CalculateFigureSquare(initializationParams));
            }
        }

        /// <summary>
        /// Сгенерировать список параметров
        /// </summary>
        /// <param name="figures">Список фигур</param>
        /// <returns>список параметров</returns>
        private static IEnumerable<double> GetInitialiationParams (IEnumerable<IFigure> figures)
        {
            var parameters = new List<double>();
            var maxParamsNumber = figures.Select(s => s.ParamsNumber).Max();
            parameters = new List<double>();

            do parameters.Add(1);
            while (parameters.Count <= maxParamsNumber);

            return parameters;
        }
    }
}

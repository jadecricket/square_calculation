using SquareCalculationService.Models;
using SquareCalculationService.Models.Figures;
using SquareCalculationService.Tests.Models.Figures;
using Xunit;

namespace SquareCalculationService.Tests
{
    /// <summary>
    /// Проверка работы менеджера
    /// </summary>
    public class ManagerTest
    {
        /// <summary>
        /// Проверка на то, что экземпляры классов, 
        /// создаваемые менеджерами, 
        /// ссылаются на один объект в памяти
        /// </summary>
        [Fact]
        public void SameInstanceTest()
        {
            var expected = FigureManager.Instance;
            var actual = FigureManager.Instance;
            Assert.Same(expected, actual);

            var expectedGeneric = FigureManager<Circle>.Instance;
            var actualGeneric = FigureManager<Circle>.Instance;
            Assert.Same(expectedGeneric, actualGeneric);
        }

        /// <summary>
        /// Проверка того, что менеджер и экземпляр 
        /// фигуры расчитывают площади одинаково
        /// </summary>
        [Fact]
        public void CorrectResultTest()
        {
            var expected = FigureManager<Trapeze>.Instance.CalculateFigureSquare(5,2,1);
            var actual = new Trapeze().CalculateFigureSquare(5,2,1);

            Assert.Equal(expected, actual);
        }
    }
}

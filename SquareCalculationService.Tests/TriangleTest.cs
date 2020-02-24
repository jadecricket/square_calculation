using SquareCalculationService.Exceptions;
using SquareCalculationService.Models.Figures;
using Xunit;

namespace SquareCalculationService.Tests
{
    /// <summary>
    /// ����� ��� ������������
    /// </summary>
    public class TriangleTest
    {
        /// <summary>
        /// ���� ����������������� �������� ������� ������ Triangle
        /// </summary>
        [Fact]
        public void TriangleTravelPropertyTest()
        {
            var triangle = new Triangle();

            var expectedSquareResult = triangle.CalculateFigureSquare(3, 4, 5);
            var squareResult = triangle.CalculateFigureSquare(4, 5, 3);
            Assert.Equal(expectedSquareResult, squareResult);

            var expectedIsRightResult = triangle.IsRight(3, 4, 5);
            var isRightResult = triangle.IsRight(4, 3, 5);
            Assert.Equal(expectedIsRightResult, isRightResult);
        }

        /// <summary>
        /// ��������, ��� ����� IsRight �������� ����������, 
        /// ���� �������� ������������ ���-�� ���������
        /// </summary>
        [Fact]
        public void SquareCalculationExceptionTest() 
        {
            var triangle = new Triangle();
            Assert.Throws<ParamsWrongNumberException>(() => triangle.IsRight(1));
        }
    }
}

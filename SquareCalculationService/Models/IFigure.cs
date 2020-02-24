namespace SquareCalculationService.Models
{
    /// <summary>
    /// Фигура
    /// </summary>
    public interface IFigure
    {
        /// <summary>
        /// Кол-во параметров для работы с фигурой
        /// </summary>
        int ParamsNumber { get; }

        /// <summary>
        /// Расчитать площадь фигуры
        /// </summary>
        /// <param name="parameters">Параметры для расчтеа площади фигуры</param>
        /// <returns>Площадь фигуры</returns>
        double CalculateFigureSquare(params double[] parameters);
    }
}

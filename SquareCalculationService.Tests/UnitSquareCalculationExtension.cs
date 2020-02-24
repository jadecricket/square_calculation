using SquareCalculationService.Extensions;
using SquareCalculationService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SquareCalculationService.Tests
{
    public abstract class UnitSquareCalculationExtension : SquareCalculationExtension
    {
        /// <summary>
        /// Получить экземпляры всех реализации инфтерфейса IFigure
        /// Костыль для unit-тестов
        /// Позволяет избежать ошибки Could not load file or assembly Microsoft.IntelliTrace.Core
        /// </summary>
        /// <returns>Коллекция объектов, классы которых реализуют IFigure</returns>
        public new static IEnumerable<IFigure> GetAllFigures() =>
            AppDomain.CurrentDomain.GetAssemblies()
            .Where(w => !w.FullName.StartsWith("Microsoft"))
                .SelectMany(
                    assemblies =>
                    assemblies.GetTypes())
                ?.Where(x => x.ContainsGenericParameters == false &&
                    typeof(IFigure).IsAssignableFrom(x) && !x.IsInterface)
                ?.Select(s => Activator.CreateInstance(s) as IFigure);
    }
}

using SquareCalculationService.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SquareCalculationService.Extensions
{
    public abstract class SquareCalculationExtension
    {
        /// <summary>
        /// Получить экземпляры всех реализации инфтерфейса IFigure
        /// </summary>
        /// <returns>Коллекция объектов, классы которых реализуют IFigure</returns>
        public static IEnumerable<IFigure> GetAllFigures() => 
            AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(
                    assemblies =>
                    assemblies.GetTypes())
                ?.Where(x => x.ContainsGenericParameters == false &&
                    typeof(IFigure).IsAssignableFrom(x) && !x.IsInterface)
                ?.Select(s => Activator.CreateInstance(s) as IFigure);

        
    }
}

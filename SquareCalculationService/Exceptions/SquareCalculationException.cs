using System;
using System.Runtime.Serialization;

namespace SquareCalculationService.Exceptions
{
    /// <summary>
    /// Родительский тип исключения для библиотеки
    /// </summary>
    public class SquareCalculationException : Exception
    {
        public SquareCalculationException()
        {
        }

        public SquareCalculationException(string message) : base(message)
        {
        }

        public SquareCalculationException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected SquareCalculationException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}

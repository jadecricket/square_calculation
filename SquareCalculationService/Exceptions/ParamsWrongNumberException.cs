using System;
using System.Runtime.Serialization;

namespace SquareCalculationService.Exceptions
{
    /// <summary>
    /// Исключение при передаче в методы классов, реализующих интерфейс IFigure
    /// </summary>
    public class ParamsWrongNumberException : SquareCalculationException
    {
        public ParamsWrongNumberException()
        {
        }

        /// <summary>
        /// Конструктор для формировании сообщения об ошибке по-умолчанию
        /// </summary>
        /// <param name="actualNumber">Кол-во параметров, переданных в метод</param>
        /// <param name="expectedNumber">Кол-во параметров, которые должен принимать метод</param>
        public ParamsWrongNumberException(int actualNumber, int expectedNumber) => 
            new ParamsWrongNumberException($"Кол-во входных параметров: {actualNumber}" +
                    $"не соответствует требуемому: {expectedNumber}");

        public ParamsWrongNumberException(string message) : base(message)
        {
        }

        public ParamsWrongNumberException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ParamsWrongNumberException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}

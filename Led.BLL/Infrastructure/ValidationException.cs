using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Led.BLL.Infrastructure
{
    public class ValidationException : Exception
    {
        public string Property { get; protected set; }
        public ValidationException(string message, string prop) : base(message)
        {
            Property = prop;
        }

    }

    public static class ValidationExceptionMessage
    {
        public const string OWNER_NO_SET_ID = "Собственник, не установлено id.";
        public const string OWNER_NOT_FOUND = "Собственник не найден.";

        public const string ADDRESS_NO_SET_ID = "Адрес, не установлено id.";
        public const string ADDRESS_NOT_FOUND = "Адрес не найден.";

        public const string CITY_NO_SET_ID = "Город, не установлено id.";
        public const string CITY_NOT_FOUND = "Город не найден.";

        public const string DISPLAY_NO_SET_ID = "Экран, не установлено id.";
        public const string DISPLAY_NOT_FOUND = "Экран не найден.";
    }
}

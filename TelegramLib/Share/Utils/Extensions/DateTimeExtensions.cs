using System;

namespace TelegramLib.Share.Utils.Extensions
{
    public static class DateTimeExtensions
    {
        public static string DateTimeFormatSql(this DateTime date)
        {
            return date.ToString("yyyy-MM-dd HH:mm:ss");
        }
    }
}

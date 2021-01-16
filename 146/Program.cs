using System;
using System.Linq;

namespace _146 {
    class Program {
        static void Main(string[] args) {
            var dt = new DateTime(2020, 8, 10, 16, 32, 20);

            Console.WriteLine("jst:{0}", dt.ToString(@"yyyy/MM/dd HH:mm:ss"));
            Console.WriteLine("utc:{0}", dt.ToUniversalTime().ToString(@"yyyy/MM/dd HH:mm:ss"));

            var singaporTimeZone = TimeZoneInfo.GetSystemTimeZones().Where(item => item.DisplayName.Contains("シンガポール")).FirstOrDefault();
            if (singaporTimeZone != null) {
                Console.WriteLine("singapor:{0}", TimeZoneInfo.ConvertTime(dt.ToUniversalTime(), singaporTimeZone).ToString(@"yyyy/MM/dd HH:mm:ss"));
            }
        }
    }
}

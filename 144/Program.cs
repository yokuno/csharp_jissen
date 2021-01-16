using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace _144 {
    class Program {
        static void Main(string[] args) {
            MainAsync().Wait();
        }

        private static async Task MainAsync() {
            var client = new HttpClient();
            var res = await client.GetAsync("https://www.teppi.com/");
            using (var writer = new FileStream("out.html", FileMode.Create, FileAccess.Write)) {
                await res.Content.CopyToAsync(writer);
            }
        }
    }
}

using System;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Cw1
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            //int? tmp = null; // = 1
            //bool alfa = true;
            //Console.WriteLine($"{tmp} {alfa}");

            //Console.WriteLine("Hello World!");

            var newPerson = new Person {FirstName = "Daniel"};

            var url = args.Length > 0 ? args[0] : "http://www.pja.edu.pl";
      

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(url))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var htmlContent = await response.Content.ReadAsStringAsync();
                        var regex = new Regex("[a-z]+[a-z0-9]*@[a-z0-9]+\\.[a-z]+", RegexOptions.IgnoreCase);

                        var matches = regex.Matches(htmlContent);

                        foreach (var match in matches)
                        {
                            Console.WriteLine(match.ToString());
                        }
                    }

                }
            }

            // w wiekoszosci przypadkow tam gdzie mamy Async to musimy dac przed 'await'

            // oczekujemy dwiescie cos
           
            //zadanie 4 dom

        }
    }
}

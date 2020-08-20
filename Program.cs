using System;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace waves
{
    class Program
    {
        static HttpClient client = new HttpClient();
        
        static async Task Main(string[] args)
        {
            client.Timeout = TimeSpan.FromMinutes(1);
            var page = 1;
            var perPage = 2;

            if(args.Length == 2)
            {
                var ok = int.TryParse(args[0], out page);
                if (!ok) {
                    Console.WriteLine("page_number must be an integer");
                    return;
                }

                ok = int.TryParse(args[1], out perPage);
                if (!ok) {
                    Console.WriteLine("results_per_page must be an integer");
                    return;
                }
            }
            
            var url = $"https://reqres.in/api/example?per_page={perPage}&page={page}";
            Console.WriteLine("Attempting request to {0}", url);

            var body = await TryFetch(url);

            var apiData = TryDeserialize<ApiMetaData>(body);
            
            Func<ColorMetaData, int> determineGroup = color => {
                var pv = color.PantoneValue;
                var prefix = int.Parse(pv.Split('-').ToList().First());
                
                if (prefix % 3 == 0) return 1;
                if (prefix % 2 == 0) return 2;
                return 3;
            };

            Action<ColorMetaData> print = clr => 
                Console.WriteLine($"{clr.Name} ({clr.PantoneValue})");
            
            for (int i = 1; i < 4; i++)
            {
                Console.WriteLine("== Group {0} ==", i);
                apiData.Colors
                    .Where(clr => determineGroup(clr) == i)
                    .ToList()
                    .ForEach(print);
            }
        }

        static T TryDeserialize<T>(string json)
        {
            try 
            {
                return JsonSerializer.Deserialize<T>(json);
            }
            catch(JsonException ex)
            {
                Console.WriteLine("JSON invalid, check type definitions");
                Console.WriteLine("Message: {0}", ex.Message);
                throw ex;
            }
        }

        static async Task<string> TryFetch(string url)
        {
            try 
            {
                return await client.GetStringAsync(url);
            }
            catch(HttpRequestException ex)
            {
                Console.WriteLine("Failed to fetch data");
                Console.WriteLine("Message: {0}", ex.Message);
                throw ex;
            }
        }
    }
}

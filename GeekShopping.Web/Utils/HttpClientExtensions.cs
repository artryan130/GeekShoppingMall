using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace GeekShopping.Web.Utils
{
    public static class HttpClientExtensions
    {
        private static MediaTypeHeaderValue contentType = new MediaTypeHeaderValue("application/json");

        //GET
        public static async Task<T> ReadContentAs<T>(this HttpResponseMessage response)
        {
            if(!response.IsSuccessStatusCode)
            {
                throw new ApplicationException($"Something that wrong when calling the API: {response.ReasonPhrase}");
            }

            var dataAsString = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            return JsonSerializer.Deserialize<T>(dataAsString, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

        //POST
        public static async Task<HttpResponseMessage> PostAsJson<T>(this HttpClient httpClient, string URL, T data)
        {
            var dataAsString = JsonSerializer.Serialize(data);
            var content = new StringContent(dataAsString, Encoding.UTF8, "application/json");

            // Verificar a URL e os dados antes de enviar
            Console.WriteLine($"Sending POST request to {URL} with data: {dataAsString}");

            try
            {
                var response = await httpClient.PostAsync(URL, content);  // Esperar a resposta assíncrona
                if (!response.IsSuccessStatusCode)
                {
                    Console.WriteLine($"Request failed with status code: {response.StatusCode}");
                }
                return response;
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Request failed: {ex.Message}");
                throw;
            }
        }


        //PUT
        public static Task<HttpResponseMessage> PutAsJson<T>(this HttpClient httpClient, string URL, T data)
        {
            var dataAsString = JsonSerializer.Serialize(data);
            var content = new StringContent(dataAsString);
            content.Headers.ContentType = contentType;
            return httpClient.PutAsync(URL, content);
        }
    }
}

using JSON64_Unidad_2.Model;
using JsonBase64.Helpers;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace JSON64_Unidad_2.Services
{
    public class UsuarioService
    {
        HttpClient client;
        private readonly string API_USUARIOS = "usuario";
        public UsuarioService()
        {
#if DEBUG
            var handler = new BypassSslValidationClientHandler();
            client = new HttpClient(handler);
#else
            client = new HttpClient();
#endif
        }
        public async Task<string> Register(Usuario usuario)
        {
            var handler = new HttpClientHandler();

            handler.ServerCertificateCustomValidationCallback +=
                            (sender, certificate, chain, errors) =>
                            {
                                return true;
                            };
            var client = new HttpClient(handler);

            string result = string.Empty;
            if (usuario != null && !string.IsNullOrEmpty(usuario.Username) && !string.IsNullOrEmpty(usuario.Password))
            {
                result = JsonSerializer.Serialize(usuario);

                StringContent content = new StringContent(result, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PostAsync(AppResources.APIResources.APIHOST + API_USUARIOS, content);
                if (response.IsSuccessStatusCode)
                {
                    var contenido = response.Content;
                    result = await contenido.ReadAsStringAsync();
                }
            }
            return result;
        }
    }
}

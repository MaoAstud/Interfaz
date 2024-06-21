namespace Interfaz.Services
{
    using System.Net.Http;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Interfaz.Models;

    public class ApiService
    {
        private readonly HttpClient _httpClient;

        public ApiService(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("BusDataClient");
        }

        public async Task<List<Usuario>> GetAllUsersAsync()
        {
            var response = await _httpClient.GetAsync("/usuarios");
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<Usuario>>(json);
        }

        public async Task<Usuario> GetUserByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync($"/usuarios/{id}");
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Usuario>(json);
        }

        public async Task CreateUserAsync(Usuario user)
        {
            var json = JsonConvert.SerializeObject(user);
            var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("/usuarios", content);
            response.EnsureSuccessStatusCode();
        }

        public async Task UpdateUserAsync(int id, Usuario user)
        {
            var json = JsonConvert.SerializeObject(user);
            var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

            var response = await _httpClient.PutAsync($"/usuarios/{id}", content);
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteUserAsync(int id, string origen)
        {
            var response = await _httpClient.DeleteAsync($"/usuarios/{id}/{origen}");
            response.EnsureSuccessStatusCode();
        }

        public async Task<List<Producto>> GetAllProductosAsync()
        {
            var response = await _httpClient.GetAsync("/productos");
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<Producto>>(json);
        }

        public async Task<Producto> GetProductoByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync($"/productos/{id}");
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Producto>(json);
        }

        public async Task CreateProductoAsync(Producto producto)
        {
            var json = JsonConvert.SerializeObject(producto);
            var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("/productos", content);
            response.EnsureSuccessStatusCode();
        }

        public async Task UpdateProductoAsync(int id, Producto producto)
        {
            var json = JsonConvert.SerializeObject(producto);
            var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

            var response = await _httpClient.PutAsync($"/productos/{id}", content);
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteProductoAsync(int id, string origen)
        {
            var response = await _httpClient.DeleteAsync($"/productos/{id}/{origen}");
            response.EnsureSuccessStatusCode();
        }

        public async Task<List<Carrito>> GetAllCarritosAsync()
        {
            var response = await _httpClient.GetAsync("/carrito");
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<Carrito>>(json);
        }

        public async Task<Carrito> GetCarritoByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync($"/carrito/{id}");
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Carrito>(json);
        }

        public async Task CreateCarritoAsync(Carrito carrito)
        {
            var json = JsonConvert.SerializeObject(carrito);
            var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("/carrito", content);
            response.EnsureSuccessStatusCode();
        }

        public async Task UpdateCarritoAsync(int id, Carrito carrito)
        {
            var json = JsonConvert.SerializeObject(carrito);
            var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

            var response = await _httpClient.PutAsync($"/carrito/{id}", content);
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteCarritoAsync(int id, string origen)
        {
            var response = await _httpClient.DeleteAsync($"/carrito/{id}/{origen}");
            response.EnsureSuccessStatusCode();
        }

        public async Task<List<Comentario>> GetAllComentariosAsync()
        {
            var response = await _httpClient.GetAsync("/comentarios");
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<Comentario>>(json);
        }

        public async Task<Comentario> GetComentarioByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync($"/comentarios/{id}");
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Comentario>(json);
        }

        public async Task CreateComentarioAsync(Comentario comentario)
        {
            var json = JsonConvert.SerializeObject(comentario);
            var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("/comentarios", content);
            response.EnsureSuccessStatusCode();
        }

        public async Task UpdateComentarioAsync(int id, Comentario comentario)
        {
            var json = JsonConvert.SerializeObject(comentario);
            var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

            var response = await _httpClient.PutAsync($"/comentarios/{id}", content);
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteComentarioAsync(int id, string origen)
        {
            var response = await _httpClient.DeleteAsync($"/comentarios/{id}/{origen}");
            response.EnsureSuccessStatusCode();
        }

        public async Task<List<Categoria>> GetAllCategoriasAsync()
        {
            var response = await _httpClient.GetAsync("/categorias");
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<Categoria>>(json);
        }

        public async Task<Categoria> GetCategoriaByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync($"/categorias/{id}");
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Categoria>(json);
        }

        public async Task CreateCategoriaAsync(Categoria categoria)
        {
            var json = JsonConvert.SerializeObject(categoria);
            var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("/categorias", content);
            response.EnsureSuccessStatusCode();
        }

        public async Task UpdateCategoriaAsync(int id, Categoria categoria)
        {
            var json = JsonConvert.SerializeObject(categoria);
            var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

            var response = await _httpClient.PutAsync($"/categorias/{id}", content);
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteCategoriaAsync(int id, string origen)
        {
            var response = await _httpClient.DeleteAsync($"/categorias/{id}/{origen}");
            response.EnsureSuccessStatusCode();
        }

        public async Task<List<DetalleCarrito>> GetAllDetalleCarritoAsync()
        {
            var response = await _httpClient.GetAsync("/detalle");
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<DetalleCarrito>>(json);
        }

        public async Task<DetalleCarrito> GetDetalleCarritoByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync($"/detalle/{id}");
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<DetalleCarrito>(json);
        }

        public async Task CreateDetalleCarritoAsync(DetalleCarrito detalleCarrito)
        {
            var json = JsonConvert.SerializeObject(detalleCarrito);
            var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("/detalle", content);
            response.EnsureSuccessStatusCode();
        }

        public async Task UpdateDetalleCarritoAsync(int id, DetalleCarrito detalleCarrito)
        {
            var json = JsonConvert.SerializeObject(detalleCarrito);
            var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

            var response = await _httpClient.PutAsync($"/detalle/{id}", content);
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteDetalleCarritoAsync(int id, string origen)
        {
            var response = await _httpClient.DeleteAsync($"/detalle/{id}/{origen}");
            response.EnsureSuccessStatusCode();
        }
    }

}

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Interfaz.Services;
using Interfaz.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Interfaz.Pages
{
    public class TiendasModel : PageModel
    {
        private readonly ApiService _apiService;

        public TiendasModel(ApiService apiService)
        {
            _apiService = apiService;
        }

        public List<Producto> Productos { get; set; }

        public async Task OnGetAsync()
        {
            Productos = await _apiService.GetAllProductosAsync();
        }
    }
}


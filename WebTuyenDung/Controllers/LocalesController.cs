using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebTuyenDung.Services;
using WebTuyenDung.ViewModels;

namespace WebTuyenDung.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LocalesController : ControllerBase
    {
        private readonly LocaleService localeService;

        public LocalesController(LocaleService localeService)
        {
            this.localeService = localeService;
        }

        [Route("{parent?}")]
        public Task<List<LocaleViewModel>> GetLocales(int? parent)
        {
            return localeService.GetLocales(parent);
        }
    }
}

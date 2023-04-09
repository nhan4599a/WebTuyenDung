using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using WebTuyenDung.Data;
using WebTuyenDung.ViewModels.Api;

namespace WebTuyenDung.ApiControllers
{
    public class LocalesController : BaseApiController
    {
        public LocalesController(RecruimentDbContext dbContext) : base(dbContext)
        {
        }

        [Route("{parent?}")]
        public IAsyncEnumerable<LocaleViewModel> GetLocales(int? parent)
        {
            return DbContext.Locales
                            .Where(e => e.Parent == parent)
                            .Select(e => new LocaleViewModel
                            {
                                Id = e.Id,
                                Name = e.Name
                            })
                            .AsAsyncEnumerable();
        }
    }
}

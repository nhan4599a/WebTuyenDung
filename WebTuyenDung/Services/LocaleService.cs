using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebTuyenDung.Data;
using WebTuyenDung.ViewModels;

namespace WebTuyenDung.Services
{
    public class LocaleService
    {
        private readonly RecruimentDbContext dbContext;

        public LocaleService(RecruimentDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public Task<List<LocaleViewModel>> GetLocales(int? parent)
        {
            return dbContext.Locales
                            .Where(e => e.Parent == parent)
                            .Select(e => new LocaleViewModel
                            {
                                Id = e.Id,
                                Name = e.Name
                            }).ToListAsync();
        }
    }
}

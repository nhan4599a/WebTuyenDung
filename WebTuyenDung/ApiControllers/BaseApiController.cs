using Microsoft.AspNetCore.Mvc;
using WebTuyenDung.Data;

namespace WebTuyenDung.ApiControllers
{
    [ApiController]
    [Route("api/{controller}")]
    public class BaseApiController : ControllerBase
    {
        protected RecruimentDbContext DbContext { get; }

        protected BaseApiController(RecruimentDbContext dbContext)
        {
            DbContext = dbContext;
        }
    }
}

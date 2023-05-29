using Microsoft.AspNetCore.Mvc;

namespace WebTuyenDung.Controllers
{
    public class PaymentController : ControllerBase
    {
        public IActionResult Info()
        {
            return File("~/payment-info.txt", "text/plain", "payment-info.txt");
        }
    }
}

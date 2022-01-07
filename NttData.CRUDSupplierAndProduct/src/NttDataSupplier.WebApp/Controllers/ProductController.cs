using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NttDataSupplier.Domain.Interfaces;
using NttDataSupplier.WebApp.Extensions;
using System.Threading.Tasks;

namespace NttDataSupplier.WebApp.Controllers
{
    [Route("produtos")]
    public class ProductController : MainController
    {
        public ProductController(INotificationService notificationService, IMapper mapper) : base(notificationService, mapper)
        {
        }

        [AllowAnonymous]
        [HttpGet("todos-os-produtos")]        
        public async Task<IActionResult> Index(int pageSize = 10, int pageIndex = 1, string query = null)
        {
            return View();
        }
    }
}

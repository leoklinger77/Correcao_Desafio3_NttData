using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NttDataSupplier.Domain.Interfaces;
using NttDataSupplier.WebApp.Extensions;
using NttDataSupplier.WebApp.Models;

namespace NttDataSupplier.WebApp.Controllers
{
    public class HomeController : MainController
    {
        public HomeController(INotificationService notificationService, IMapper mapper) : base(notificationService, mapper)
        {
        }

        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet("erro/{id:length(3,3)}")]
        [AllowAnonymous]
        public IActionResult Error(int id)
        {
            var modelErro = new ErrorViewModel();

            if (id == 500)
            {
                modelErro.Message = "Ocorreu um erro! Tente novamente mais tarde ou contate nosso suporte.";
                modelErro.Title = "Ocorreu um erro!";
                modelErro.ErroCode = id;
            }
            else if (id == 404)
            {
                modelErro.Message = "Parece que você pegou o caminho errado. Não se preocupe ... isso acontece com o melhor de nós.";
                modelErro.Title = "Página não encontrada.";
                modelErro.ErroCode = id;

            }
            else if (id == 403)
            {
                modelErro.Message = "Você não tem permissão para fazer isto.";
                modelErro.Title = "Acesso negado!";
                modelErro.ErroCode = id;
            }
            else
            {
                return StatusCode(404);
            }

            return View("Error", modelErro);
        }
    }
}

using ConfigureRedditService.Services;
using ConfigureRedditService.Models;
using Microsoft.AspNetCore.Mvc;

namespace ConfigureRedditService.Controllers
{
    public class redirecturiController : Controller
    {
        private readonly IOAuthClientService oAuthClientService;
        private readonly IConfiguration configuration;

        public redirecturiController(IOAuthClientService oAuthClientService, IConfiguration configuration)
        {
            this.oAuthClientService = oAuthClientService;
            this.configuration = configuration;
        }

        [HttpGet]
        public async Task<IActionResult> Index(string error,string code, string state)
        {

            if (!string.IsNullOrEmpty(error))
            {
                return RedirectToAction("Error", "Home"); // Redirect to an error page
            }

            if (string.IsNullOrEmpty(code))
            {
                return RedirectToAction("Error", "Home"); // Redirect to an error page
            }

            oAuthClientService.Code = code;

            return RedirectToAction("Index", "Home");
        }
    }
}

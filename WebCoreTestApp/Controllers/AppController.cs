using Microsoft.AspNetCore.Mvc;
using WebCoreTestApp.Data;
using WebCoreTestApp.Services;
using WebCoreTestApp.ViewModels;

namespace WebCoreTestApp.Controllers
{
    public class AppController : Controller
    {
        private readonly IWebCoreRepository _repository;
        private readonly IMailService _mailService;

        public AppController(IWebCoreRepository repository, IMailService mailService)
        {
            _repository = repository;
            _mailService = mailService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("contact")]
        public IActionResult Contact()
        {
            return View();
        }

        [HttpPost("contact")]
        public IActionResult Contact(ContactViewModel model)
        {
            if (ModelState.IsValid)
            {
                _mailService.SendMessage(model.Subject, model.Name, model.Message);
                ModelState.Clear();
                ViewBag.UserMessage = $"Message to {model.Name} has been sent";
            }

            return View();
        }

        [HttpGet("about")]
        public IActionResult About()
        {
            return View();
        }

        public IActionResult Shop()
        {
            var results = _repository.GetAllProducts();

            return View(results);
        }
    }
}

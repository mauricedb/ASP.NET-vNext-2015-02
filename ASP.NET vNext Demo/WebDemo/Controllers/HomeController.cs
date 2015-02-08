using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using WebDemo.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace WebDemo.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBooksRepository _repo;

        public HomeController(IBooksRepository repo)
        {
            _repo = repo;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        public async Task< IActionResult> Books()
        {
            //using (var repo = new BooksRepository())
            //{
                return View(await _repo.GetBooks());

            //}
        }
    }
}

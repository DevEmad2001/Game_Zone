

namespace GameZone.Controllers
{
    public class GamesController : Controller
    {
        private readonly ApplicationDbContext? _context;
        public GamesController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create() 
        {
           // var categories=_context.Categories.ToList();// selection all categories inside database
            CreateGameViewModel viewModel = new()
            {
                //table 1
                Categories=_context.Categories 
                    .Select(c=>new SelectListItem {Value=c.Id.ToString() ,Text=c.Name })
                    .OrderBy(c=>c.Text)
                    .ToList(),// projection operation  and initialize of tow properites value and text 
                    //table 2
                Devices=_context.Devices
                    .Select(d => new SelectListItem { Value = d.Id.ToString(), Text = d.Name })
                    .OrderBy(d => d.Text)
                    .ToList()
            };
            return View(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken] //Http 400 Bad requst Error
        public IActionResult Create(CreateGameViewModel model) 
        {
        return View(model);
        }
    }
}

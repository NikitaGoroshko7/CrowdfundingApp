namespace CrowdFundingApplication.Controllers;

public class ProjectController : Controller
{
    private readonly ApplicationContext _db;
    private readonly IWebHostEnvironment _webHostEnvironment;
    private readonly UserManager<User> _userManager;

    public ProjectController(ApplicationContext db, IWebHostEnvironment webHostEnvironment, UserManager<User> userManager)
    {
        _db = db;
        _webHostEnvironment = webHostEnvironment;
        _userManager = userManager;
    }

    [HttpGet]
    public IActionResult Index() => View();

    [HttpPost]
    public IActionResult Index(bool check) => RedirectToAction("CreateProject", "Project");

    [HttpGet]
    public IActionResult CreateProject() => View();

    [HttpPost]
    public IActionResult CreateProject(CreateProjectViewModel model)
    {
        if (ModelState.IsValid)
        {
            var date = DateTime.Parse(model.Date);
            if (date < DateTime.Now)
            {
                ModelState.AddModelError("Date", "Ошибка! Дата окончания проекта должна быть больше текущей!");
            }
            else if (model.Image is null)
            {
                ModelState.AddModelError("Image", "Ошибка! Для создание проекта необходима обложка!");
            }
            else
            {
                model.Date = DateTime.Parse(model.Date).ToShortDateString();
                model.ImageName = UploadedFileService.UploadedFile(model.Image, _webHostEnvironment, "ProjectImages");

                var obj = GetCreateProject(model);
                _db.Add(obj);
                _db.SaveChanges();

                return RedirectToAction("CreateProjectInDetails", "Project");
            }
        }
        return View(model);
    }

    [HttpGet]
    public IActionResult CreateProjectInDetails() => View();

    [HttpGet]
    public IActionResult Organization() => View();

    private CreateProject GetCreateProject(CreateProjectViewModel model)//convert CreateProjectViewModel in CreateProject for record in the database
    {
        var project = new CreateProject
        {
            Id = Guid.NewGuid(),
            NameOfProject = model.NameOfProject,
            ImageName = model.ImageName,
            Description = model.Description,
            Category = model.Category.ToString(),
            Sum = model.Sum,
            Date = model.Date
        };
        return project;
    }
}
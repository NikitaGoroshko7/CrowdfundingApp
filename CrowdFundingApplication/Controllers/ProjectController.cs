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
    public async Task<IActionResult> CreateProject(EditProjectViewModel model)
    {
        if (ModelState.IsValid)
        {
            if (model.Date < DateTime.Now)
            {
                ModelState.AddModelError("Date", "Ошибка! Дата окончания проекта должна быть больше текущей!");
            }
            else if (model.Image is null)
            {
                ModelState.AddModelError("Image", "Ошибка! Для создание проекта необходима обложка!");
            }
            else
            {
                model.ImageName = UploadedFileService.UploadedFile(model.Image, _webHostEnvironment, "ProjectImages");

                var obj = GetCreateProject(model);
                await _db.AddAsync(obj);
                await _db.SaveChangesAsync();

                return RedirectToAction("CreateProjectInDetails", "Project");
            }
        }
        return View(model);
    }

    private CreateProject GetCreateProject(EditProjectViewModel model)//convert CreateProjectViewModel in CreateProject for record in the database
    {
        var project = new CreateProject
        {
            NameOfProject = model.NameOfProject,
            ImageName = model.ImageName,
            Description = model.Description,
            Category = model.Category,
            Sum = model.Sum,
            Date = model.Date,
            FullDescription = model.FullDescription
        };
        return project;
    }
}
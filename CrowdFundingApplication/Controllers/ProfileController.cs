namespace CrowdFundingApplication.Controllers;

public class ProfileController : Controller
{
    private readonly UserManager<User> _userManager;
    private readonly IWebHostEnvironment _webHostEnvironment;

    public ProfileController(UserManager<User> userManager, IWebHostEnvironment webHostEnvironment)
    {
        _userManager = userManager;
        _webHostEnvironment = webHostEnvironment;
    }

    public async Task<IActionResult> Index()
    {
        var user = await _userManager.FindByNameAsync(HttpContext.User.Identity.Name);
        return View(user);
    }

    [HttpGet]
    public IActionResult Settings() => View();

    [HttpPost]
    public async Task<IActionResult> Settings(EditProfileViewModel model, IFormFile Image)
    {
        if (ModelState.IsValid)
        {
            var user = await _userManager.FindByNameAsync(HttpContext.User.Identity.Name);
            if (user is null)
            {
                return View(model);
            }

            //update dates for user
            if (model.Age is not null) user.Age = (int)model.Age;
            if (model.Email is not null) user.Email = model.Email;
            if (model.NumberOfPhone is not null) user.PhoneNumber = model.NumberOfPhone;
            if (model.Sex is not null) user.Sex = model.Sex;
            if (model.Country is not null) user.Country = model.Country;
            if (model.City is not null) user.City = model.City;
            if (model.Description is not null) user.Description = model.Description;
            if (Image is not null) user.Avatar = UploadedFile(Image);

            if (model.NewPassword is not null)//update password for user
            {
                var _passwordValidator = HttpContext.RequestServices.GetService(typeof(IPasswordValidator<User>)) as IPasswordValidator<User>;
                var _passwordHasher = HttpContext.RequestServices.GetService(typeof(IPasswordHasher<User>)) as IPasswordHasher<User>;
                IdentityResult result = await _passwordValidator.ValidateAsync(_userManager, user, model.NewPassword);

                if (result.Succeeded)
                {
                    user.PasswordHash = _passwordHasher.HashPassword(user, model.NewPassword);
                }
            }

            await _userManager.UpdateAsync(user);
            return RedirectToAction("Index","Profile");
        }
        return View();
    }

    private string UploadedFile(IFormFile image)
    {
        string uniqueFileName = null;

        if (image is not null)
        {
            string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "Avatars");
            uniqueFileName = Guid.NewGuid().ToString() + "_" + image.FileName;
            string filePath = Path.Combine(uploadsFolder, uniqueFileName);
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                image.CopyTo(fileStream);
            }
        }
        return uniqueFileName;
    } 

    public async Task<IActionResult> DeleteProfile()
    {
        var user = await _userManager.FindByNameAsync(HttpContext.User.Identity.Name);
        await _userManager.DeleteAsync(user);
        return RedirectToAction("MainPage", "Home");
    }

    public IActionResult CreatedProjects() => View();

    [HttpGet]
    public async Task<IActionResult> Balance()
    {
        var user = await _userManager.FindByNameAsync(HttpContext.User.Identity.Name);
        return View(user);
    }
}

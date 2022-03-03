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
        var user = await _userManager.FindByNameAsync(User.Identity.Name);
        return View(GetUserViewModel(user));
    }

    [HttpGet]
    public IActionResult Settings() => View();

    [HttpPost]
    public async Task<IActionResult> Settings(EditProfileViewModel model)
    {
        if (ModelState.IsValid)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            if (user is null)
            {
                return View(model);
            }

            //update dates for user
            if (model.Age is not null) user.Age = (int)model.Age;
            if (model.Email is not null)
            {
                user.Email = model.Email;
                user.NormalizedEmail = model.Email.ToUpper();
            }
            if (model.Sex is not null)
            {
                if (model.Sex.Value.ToString() == "Male") user.Sex = "Мужской";
                else user.Sex = "Женский";
            }
            if (model.NumberOfPhone is not null) user.PhoneNumber = model.NumberOfPhone;
            if (model.Country is not null) user.Country = model.Country;
            if (model.City is not null) user.City = model.City;
            if (model.Description is not null) user.Description = model.Description;
            if (model.Image is not null) user.AvatarFileName = UploadedFileService.UploadedFile(model.Image, _webHostEnvironment, "Avatars");

            //update password for user
            if (model.OldPassword is not null
                && model.NewPassword is not null
                && model.ConfirmPassword is not null)
            {
                await _userManager.ChangePasswordAsync(user, model.OldPassword, model.NewPassword);
            }

            await _userManager.UpdateAsync(user);
            return RedirectToAction("Index", "Profile");
        }
        return View();
    }

    public async Task<IActionResult> DeleteProfile()
    {
        var user = await _userManager.FindByNameAsync(User.Identity.Name);
        await _userManager.DeleteAsync(user);//delete user from database
        return RedirectToAction("MainPage", "Home");//doing redirect after deleting user profile
    }

    public IActionResult CreatedProjects() => View();

    [HttpGet]
    public async Task<IActionResult> Balance()
    {
        var user = await _userManager.FindByNameAsync(User.Identity.Name);
        return View(GetUserViewModel(user));
    }

    [HttpPost]
    public async Task<IActionResult> Balance(int sum)
    {   
        var user = await _userManager.FindByNameAsync(User.Identity.Name);
        if(sum > 0)
        {
            return RedirectToAction("Payment", "Pay", new { userId = user.Id, sum = sum });
        }
        else
        {
            ModelState.AddModelError("","Ошибка!");
        }

        return View();
    }

    private UserViewModel GetUserViewModel(User user)
    {
        var userViewModel = new UserViewModel
        {
            UserName = user.UserName,
            AvatarFileName = user.AvatarFileName,
            PhoneNumber = user.PhoneNumber,
            Email = user.Email,
            Sex = user.Sex == "Мужской" ? Sex.Male : Sex.Female,
            Age = user.Age,
            Balance = user.Balance,
            City = user.City,
            Country = user.Country,
            Description = user.Description
        };
        return userViewModel;
    }
}

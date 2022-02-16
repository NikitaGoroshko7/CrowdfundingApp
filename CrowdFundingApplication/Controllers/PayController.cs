namespace CrowdFundingApplication.Controllers;

public class PayController : Controller
{
    private readonly UserManager<User> _userManager;

    public PayController(UserManager<User> userManager)
    {
        _userManager = userManager;
    }

    [HttpGet]
    public IActionResult Payment([FromQuery(Name = "userId")] string userId, [FromQuery(Name = "Sum")] int Sum)
    {
        var model = new PayViewModel { Sum = Sum };//seting sum in model for display 

        return userId is null ? RedirectToAction("Balance","Profile") : View(model); //check if user entered in url ~/Pay/Payment
    }

    [HttpPost]
    public async Task<IActionResult> Payment(PayViewModel model)
    {
        if (ModelState.IsValid)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            user.Balance += model.Sum;//update balance for user
            await _userManager.UpdateAsync(user);

            return View("PaymentSuccessful");
        }

        return View("SessionTimeOut");
    }
}
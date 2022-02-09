namespace CrowdFundingApplication.Controllers;

public class PayController : Controller
{
    private readonly UserManager<User> _userManager;

    public PayController(UserManager<User> userManager)
    {
        _userManager = userManager;
    }

    [HttpGet]
    public IActionResult Payment([FromQuery(Name = "userId")] string userId)
    {
        ViewBag.Sum = Request.Cookies["Sum"];//seting sum in ViewBag for display 
        return userId is null ? RedirectToAction("Balance","Profile") : View(); //check if user entered in url ~/Pay/Payment
    }

    [HttpPost]
    public async Task<IActionResult> Payment(PayViewModel model)
    {
        if (ModelState.IsValid)
        {
            var sum = Request.Cookies["Sum"];
            if (sum is null)//if cookie sum is null we return SessionTimeOut
            {
                return View("SessionTimeOut");
            }

            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            user.Balance += Convert.ToDecimal(sum);//update balance for user
            await _userManager.UpdateAsync(user);

            Response.Cookies.Delete("Sum");//when we updated balance for user we're deleting cookie file 
            return View("PaymentSuccessful");
        }

        return View(model);
    }
}
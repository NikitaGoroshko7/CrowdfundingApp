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
        var model = new PayViewModel { Sum = Sum.ToString() };//seting sum in ViewBag for display 

        return userId is null ? RedirectToAction("Balance","Profile") : View(model); //check if user entered in url ~/Pay/Payment
    }

    [HttpPost]
    public async Task<IActionResult> Payment(PayViewModel model)
    {
        if (ModelState.IsValid)
        {
            var getModelSum = model.Sum.Split(" ");//geting sum from model
            var sum = getModelSum[2];//seting sum
            if (sum is null)//if sum is null we return SessionTimeOut
            {
                return View("SessionTimeOut");
            }

            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            user.Balance += Convert.ToDecimal(sum);//update balance for user
            await _userManager.UpdateAsync(user);

            return View("PaymentSuccessful");
        }

        return View("SessionTimeOut");
    }
}
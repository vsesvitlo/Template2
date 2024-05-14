using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Template2.Models;
using System.Text.RegularExpressions;

namespace Template2.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    public IActionResult SendInformation()
    {
        return View();
    }

    [HttpPost]
    public IActionResult SendInformation(EnteringInformationModel dates)
    { 
        return View("ResultsForChoose");
    }


    public IActionResult LoginPage()
    {
        return View();
    }

    [HttpPost]
    public IActionResult LoginPage(LoginInformationModel datesLogin)
    {
        if(string.IsNullOrEmpty(datesLogin.FirstName))
        {
            ModelState.AddModelError(nameof(datesLogin.FirstName), "Enter your first name, please");

        }

        if(string.IsNullOrEmpty(datesLogin.LastName))
        {
            ModelState.AddModelError(nameof(datesLogin.LastName), "Enter your last name, please");

        }
        if (string.IsNullOrEmpty(datesLogin.Email) && !Regex.IsMatch(datesLogin.Email, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase))
       
        {
            ModelState.AddModelError(nameof(datesLogin.Login), "Enter your email, please");

        }
        if (string.IsNullOrEmpty(datesLogin.Login) || (datesLogin.Login.Length <= 3) || (datesLogin.Login.Length > 50))
        {
            ModelState.AddModelError(nameof(datesLogin.Login), "Enter your login, correctly, please. No less than 3 symbols, no more than 50 symbols");

        }

        if (string.IsNullOrEmpty(datesLogin.Password) || (datesLogin.Password.Length <= 3))
        {
            ModelState.AddModelError(nameof(datesLogin.Password), "Enter your password, correctly, please. No less than 3 symbols.");

        }
      
        if (datesLogin.PasswordConfirm != datesLogin.Password )
        {
            ModelState.AddModelError(nameof(datesLogin.PasswordConfirm), "Check your passwords, please");

        }

        if (ModelState.IsValid)
        {
            return View("ResultLogin");
        }
        else{
            return View(datesLogin);
        }
    }

    public IActionResult SendCountryCodes()
    {
        List<PhoneBaseModel> CodesForCountries = new List<PhoneBaseModel>();
        CodesForCountries.Add(new PhoneBaseModel() { CodeCountry = +380, Country = "Ukraine" });
        CodesForCountries.Add(new PhoneBaseModel() { CodeCountry = +420, Country = "Chech Republic" });
        CodesForCountries.Add(new PhoneBaseModel() { CodeCountry = +44, Country = "Great Britain" });
        return View(CodesForCountries);
    }
}


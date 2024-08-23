using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Template2.Models;
using System.Text.RegularExpressions;
using System;

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
        EnteringInformationModel limits = new EnteringInformationModel();
        limits.MinDate = DateTime.Now.AddYears(-7);
        limits.MaxDate = DateTime.Now.AddDays(-1);
         return View(limits);
        
    }
    //<!--@model Tuple<EnteringInformationModel, DateRegulateModel>;-->

    [HttpPost]
    public IActionResult SendInformation(EnteringInformationModel dates)
    {
        TimeSpan age = DateTime.Now - dates.dateBirth;

        int ageCalc = (int)(age.TotalDays / 30.4);
        for (; ; ageCalc--)
        {
            if (Table.sleepTable.ContainsKey(ageCalc))
            {
                break;
            }
        }
        

        Params correspondingAge = Table.sleepTable[ageCalc];
        int minCorrespondingSleeps = correspondingAge.minDaySleeps;
        double minNightGoToBed = correspondingAge.minNightSleep;
        TimeOnly minLongSleep = dates.timeWakeUp.AddHours(-minNightGoToBed);
        double minNotSleep = 24 - minNightGoToBed - correspondingAge.minDayTimeSleepPeriod;
        double minPeriod = minNotSleep / (minCorrespondingSleeps + 1);
        double minPeriodSleepDay = correspondingAge.minDayTimeSleepPeriod / minCorrespondingSleeps;
        TimeOnly wakeUpFirst = dates.timeWakeUp;
        TimeOnly[] startMinSleeps = new TimeOnly[correspondingAge.minDayTimeSleepPeriod];
        TimeOnly[] endMinSleeps = new TimeOnly[correspondingAge.minDayTimeSleepPeriod];

        int maxCorrespondingSleeps = correspondingAge.maxDaySleeps;
        double maxNightGoToBed = correspondingAge.maxNightSleep;
        TimeOnly maxLongSleep = dates.timeWakeUp.AddHours(-maxNightGoToBed);
        double maxNotSleep = 24 - maxNightGoToBed - correspondingAge.maxDayTimeSleepPeriod;
        double maxPeriod = maxNotSleep / (maxCorrespondingSleeps + 1);
        double maxPeriodSleepDay = correspondingAge.maxDayTimeSleepPeriod / maxCorrespondingSleeps;
        TimeOnly[] startMaxSleeps = new TimeOnly[correspondingAge.maxDayTimeSleepPeriod];
        TimeOnly[] endMaxSleeps = new TimeOnly[correspondingAge.maxDayTimeSleepPeriod];

        for (int i = 0; i < correspondingAge.minDayTimeSleepPeriod; i++)
            {
                if (i == 0)
                startMinSleeps[i] = wakeUpFirst.AddHours(minPeriod);
                else
                startMinSleeps[i] = endMinSleeps[i - 1].AddHours(minPeriod);

            endMinSleeps[i] = startMinSleeps[i].AddHours(minPeriodSleepDay);
            }

        for (int i = 0; i < correspondingAge.maxDayTimeSleepPeriod; i++)
        {
            if (i == 0)
                startMaxSleeps[i] = wakeUpFirst.AddHours(maxPeriod);
            else
                startMaxSleeps[i] = endMaxSleeps[i - 1].AddHours(maxPeriod);

            endMaxSleeps[i] = startMaxSleeps[i].AddHours(maxPeriodSleepDay);
        }

        TimeOnly minTimeToGoToBedDay = dates.timeWakeUp.AddHours(minPeriod);
        TimeOnly maxTimeToGoToBedDay = dates.timeWakeUp.AddHours(maxPeriod);

        TimeOnly minTimeToGoToBedNight = dates.timeWakeUp.AddHours(minNightGoToBed);
        TimeOnly maxTimeToGoToBedNight = dates.timeWakeUp.AddHours(maxNightGoToBed);

        List<ActivitiesModel> ActivitiesPersonalMin = new List<ActivitiesModel>();

        ActivitiesPersonalMin.Add(new ActivitiesModel() { Activity = "Wake up", Time = wakeUpFirst });
        for (int i = 0; i < startMinSleeps.Length; i++)
        {
            ActivitiesPersonalMin.Add(new ActivitiesModel() { Activity = "Day time sleeping", Time = startMinSleeps[i] });
            ActivitiesPersonalMin.Add(new ActivitiesModel() { Activity = "Activity after daytime sleeping", Time = endMinSleeps[i] });

        }

        ActivitiesPersonalMin.Add(new ActivitiesModel() { Activity = "Night time sleeping", Time = minLongSleep });


        List<ActivitiesModel> ActivitiesPersonalMax = new List<ActivitiesModel>();

        ActivitiesPersonalMax.Add(new ActivitiesModel() { Activity = "Wake up", Time = wakeUpFirst });
        for (int i = 0; i < startMaxSleeps.Length; i++)
        {
            ActivitiesPersonalMax.Add(new ActivitiesModel() { Activity = "Day time sleeping", Time = startMaxSleeps[i] });
            ActivitiesPersonalMax.Add(new ActivitiesModel() { Activity = "Activity after daytime sleeping", Time = endMaxSleeps[i] });

        }

        ActivitiesPersonalMax.Add(new ActivitiesModel() { Activity = "Night time sleeping", Time = maxLongSleep });


        List<ActivitiesModel>[] results = new List<ActivitiesModel>[] { ActivitiesPersonalMin, ActivitiesPersonalMax };

        return View("ResultsForChoose", results);
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

    [HttpPost]
    public IActionResult PreFinalPage(List <ActivitiesModel> ChooseActivities)
    {
        Console.WriteLine(ChooseActivities.Count);
        return View(ChooseActivities);
    }
}


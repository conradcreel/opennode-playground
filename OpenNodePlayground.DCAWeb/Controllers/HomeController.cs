using System.ComponentModel;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using OpenNodePlayground.DCA.Domain.Entity;
using OpenNodePlayground.DCA.Domain.Service;
using OpenNodePlayground.DCAWeb.Models;

namespace OpenNodePlayground.DCAWeb.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IDCASettingsRepository _SettingsRepo;
    private readonly IPurchasesRepository _PurchasesRepo;

    public HomeController(ILogger<HomeController> logger, IDCASettingsRepository settingsRepo, IPurchasesRepository purchasesRepo)
    {
        _logger = logger;
        _SettingsRepo = settingsRepo;
        _PurchasesRepo = purchasesRepo;
    }

    public async Task<IActionResult> Index()
    {
        var settings = await _SettingsRepo.GetSettings();

        if (settings != default)
        {
            return View(new SettingsViewModel
            {
                Amount = settings.Amount,
                RecurrenceMinutes = settings.RecurrenceMinutes,
                IsSetup = true
            });
        }

        return View(new SettingsViewModel());
    }

    public async Task<IActionResult> SaveSettings(SettingsViewModel viewModel)
    {
        var settings = new DCASettings
        {
            Amount = viewModel.Amount,
            RecurrenceMinutes = viewModel.RecurrenceMinutes
        };

        settings = await _SettingsRepo.SetSettings(settings);

        viewModel.SettingsUpdated = true;

        return RedirectToAction("Index", viewModel);
    }

    public async Task<IActionResult> GetLastPurchase()
    {
        var lastPurchase = await _PurchasesRepo.GetLastBitcoinPurchase();

        return Json(lastPurchase);
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
}

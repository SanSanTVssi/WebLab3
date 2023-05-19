﻿using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Backend.Models;

namespace Backend.Controllers;

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

    public IActionResult About()
    {
        return View();
    }

    public IActionResult WritePost()
    {
        return View();
    }

    public IActionResult SignIn()
    {
        return View();
    }
    
    public IActionResult SignUp()
    {
        return View();
    }
    
    public IActionResult Profile()
    {
        var userCookie = Request.Cookies["User"];
        var isUserLoggedIn = !string.IsNullOrEmpty(userCookie);
        if (!isUserLoggedIn)
        {
            return RedirectToAction("Index", "Home");
        }
        return View();
    }

    [HttpPost]
    public IActionResult RemoveCookie()
    {
        if (Request.Cookies["User"] != null)
        {
            Response.Cookies.Delete("User");
        }

        return RedirectToAction("Index");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
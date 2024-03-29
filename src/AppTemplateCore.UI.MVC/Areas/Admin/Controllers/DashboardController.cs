﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using AppTemplateCore.CrossCutting.Shared;

namespace AppTemplateCore.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(policy: ClaimName.ADMIN)]
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

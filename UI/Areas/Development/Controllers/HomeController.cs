﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UI.Areas.Development.Controllers
{
    public class HomeController : Controller
    {
        // GET: Development/Home
        public ActionResult Index()
        {
            return View();
        }
    }
}
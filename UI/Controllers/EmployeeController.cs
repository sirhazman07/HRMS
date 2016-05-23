﻿using Services.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UI.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _serviceTest;

        public EmployeeController(IEmployeeService serviceTest)
        {
            _serviceTest = serviceTest;
        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Update()
        {         
            return View();
        }

        public ActionResult Delete()
        {
            return View();
        }
    }
}
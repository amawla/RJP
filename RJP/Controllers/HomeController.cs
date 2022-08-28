using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using DAL;
using Microsoft.AspNetCore.Mvc;
using RJP.Models;

namespace RJP.Controllers
{
    [Route("api/[controller]")]
    public class HomeController : Controller
    {
        private IUnitOfWork _unitOfWork;
        public HomeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [Route("Index")]
        public IActionResult Index()
        {
            var model = new OpenAccountViewModel
            {
                Customers = _unitOfWork.Customers.GetAllCustomers().ToList()
            };
            return View(model);
        }
    }
}

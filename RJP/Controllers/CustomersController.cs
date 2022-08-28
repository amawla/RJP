using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL;
using DAL.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RJP.Controllers
{
    [Route("api/[controller]")]
    public class CustomersController : Controller
    {
        private IUnitOfWork _unitOfWork;
        public CustomersController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [Route("CustomersList")]
        public ActionResult Index()
        {
            List<CustomersGridViewModel> model = new List<CustomersGridViewModel>();
            var allCustomers = _unitOfWork.Customers.GetAllCustomers();
            return View(allCustomers);
        }
        [Route("SearchCustomers")]
        [HttpPost]
        public ActionResult SearchCustomers()
        {
            return Json(JsonConvert.SerializeObject(new { status="error", id = 1}));
        }
    }
}

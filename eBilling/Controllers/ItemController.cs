using eBilling.DAL;
using eBilling.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eBilling.Controllers
{
    public class ItemController : Controller
    {
        private readonly Items_DAL _DAL;

        public ItemController(Items_DAL dAL)
        {
            _DAL = dAL;
        }

        public IActionResult Index()
        {
            List<Items> lst = new List<Items>();

            try
            {
                lst = _DAL.GetItems();
            }
            catch(Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message.ToString();
            }
            
            return View(lst);
        }
    }
}

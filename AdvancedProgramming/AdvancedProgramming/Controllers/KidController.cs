using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using AdvancedProgramming.Enums;
using AdvancedProgramming.Interfaces;
using AdvancedProgramming.Models;

namespace AdvancedProgramming.Controllers
{
    public class KidController : Controller
    {
        private IServiceKid _kidService;

        public KidController(IServiceKid kidService)
        {
            _kidService = kidService;
        }

        // GET: Kid
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(string firstName, string lastName, int age, SchoolType schoolType, string nameClass, double pocketMonetValue)
        {
            if (ModelState.IsValid)
            {
                await _kidService.CreateKid(firstName, lastName, age, schoolType, nameClass, pocketMonetValue);
                return RedirectToAction("Display");
            }
            else
            {
                return View(firstName, lastName, age);
            }
        }
        
        [HttpGet]
        public ActionResult Display()
        {
            return View(_kidService.DisplayKids());
        }

        [HttpGet]
        public async Task<ActionResult> Edit(Guid id)
        {
            var kid = await _kidService.DetailsKid(id);
            return View(kid);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(Kid kid)
        {
            if (ModelState.IsValid)
            {
                await _kidService.EditKid(kid);

                return RedirectToAction("Display");
            }
            else
            {
                return View(kid);
            }
        }

        [HttpGet]
        public async Task<ActionResult> Details(Guid id)
        {
            var kid = await _kidService.DetailsKid(id);
            return View(kid);
        }

        [HttpGet]
        public async Task<ActionResult> Delete(Guid id)
        {
            var kid = await _kidService.DetailsKid(id);
            return View(kid);
        }

        [HttpPost]
        public async Task<ActionResult> Delete(Kid kid)
        {
            if (ModelState.IsValid)
            {
                await _kidService.DeleteKid(kid.Id);

                return RedirectToAction("Display");
            }
            return View(_kidService.DetailsKid(kid.Id));
        }
    }
}
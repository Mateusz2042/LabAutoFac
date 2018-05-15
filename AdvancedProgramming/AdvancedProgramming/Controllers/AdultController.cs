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
    public class AdultController : Controller
    {
        private IServiceAdult _adultService;

        public AdultController(IServiceAdult adultService)
        {
            _adultService = adultService;
        }

        // GET: Adult
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(string firstName, string lastName, int age, string job, Singiel singiel, double salary)
        {
            if (ModelState.IsValid)
            {
                await _adultService.CreateAdult(firstName, lastName, age, job, singiel, salary);
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
            return View(_adultService.DisplayAdults());
        }

        [HttpGet]
        public async Task<ActionResult> Edit(Guid id)
        {
            var adult = await _adultService.DetailsAdult(id);
            return View(adult);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(Adult adult)
        {
            if (ModelState.IsValid)
            {
                await _adultService.EditAdult(adult);

                return RedirectToAction("Display");
            }
            else
            {
                return View(adult);
            }
        }

        [HttpGet]
        public async Task<ActionResult> Details(Guid id)
        {
            var adult = await _adultService.DetailsAdult(id);
            return View(adult);
        }

        [HttpGet]
        public async Task<ActionResult> Delete(Guid id)
        {
            var adult = await _adultService.DetailsAdult(id);
            return View(adult);
        }

        [HttpPost]
        public async Task<ActionResult> Delete(Adult adult)
        {
            if (ModelState.IsValid)
            {
                await _adultService.DeleteAdult(adult.Id);

                return RedirectToAction("Display");
            }
            return View(_adultService.DetailsAdult(adult.Id));
        }
    }
}
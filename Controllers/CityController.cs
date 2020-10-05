using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Sina_CSC_Project.Data;
using Sina_CSC_Project.Models;
using Sina_CSC_Project.Service;

namespace Sina_CSC_Project.Controllers
{
    public class CityController : Controller
    {
        private readonly ICityRepository _cityRepository;

        private readonly IMapper _mapper;

        private readonly ApplicationDbContext _context;

        private readonly ICountryRepository _countryRepository;

        private readonly IStateRepository _stateRepository;

        public CityController(ICityRepository cityRepository, IMapper mapper, ApplicationDbContext context, ICountryRepository countryRepository, IStateRepository stateRepository)
        {
            _cityRepository = cityRepository;
            _mapper = mapper;
            _context = context;
            _countryRepository = countryRepository;
            _stateRepository = stateRepository;
        }


        // GET: CityController
        public ActionResult Index()
        {
            var city = _cityRepository.FindAll().ToList();
            var model = _mapper.Map<List<City>, List<CityDetailViewModel>>(city);

            return View(model);
        }

        // GET: CityController/Details/5
        public ActionResult Details(int id)
        {
            if (!_cityRepository.isExists(id))
            {
                return NotFound();
            }

            var city = _cityRepository.FindById(id);
            var model = _mapper.Map<CityDetailViewModel>(city);

            return View(model);
        }

        // GET: CityController/Create
        public ActionResult Create()
        {
            ViewData["CountryId"] = new SelectList(_countryRepository.FindAll(), "CountryId", "CountryName");
            ViewData["StateId"] = new SelectList(_cityRepository.FindAll(), "StateId", "StateName");


            return View();
        }

        // POST: CityController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CityCreateViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }

                var city = _mapper.Map<City>(model);
                var isSuccess = _cityRepository.Create(city);
                if (!isSuccess)
                {
                    ModelState.AddModelError("", "در ثبت اطلاعات مشکلی بوجود آمده است");
                    return View(model);
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ModelState.AddModelError("", "در ثبت اطلاعات مشکلی بوجود آمده است");
                return View(model);
            }
        }

        [HttpGet("LoadStates")]
        public IActionResult LoadStates(int countryID)
        {
            ViewData["StateId"] = new SelectList(_stateRepository.LoadStates(countryID), "StateId", "StateName");

            return View();
        }

        // GET: CityController/Edit/5
        public ActionResult Edit(int id)
        {
            if (!_cityRepository.isExists(id))
            {
                return NotFound();
            }

            var city = _cityRepository.FindById(id);
            var model = _mapper.Map<CityDetailViewModel>(city);

            return View(model);
        }

        // POST: CityController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, CityDetailViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }

                var city = _mapper.Map<City>(model);
                var isSuccess = _cityRepository.Update(city);
                if (!isSuccess)
                {
                    ModelState.AddModelError("", "در ویرایش اطلاعات مشکلی بوجود آمده است");
                    return View(model);
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ModelState.AddModelError("", "در ویرایش اطلاعات مشکلی بوجود آمده است");
                return View(model);
            }
        }

        // GET: CityController/Delete/5
        public ActionResult Delete(int id)
        {
            var city = _cityRepository.FindById(id);
            var isSuccess = _cityRepository.Delete(city);
            if (!isSuccess)
            {
                return BadRequest();
            }

            return RedirectToAction(nameof(Index));
        }

        // POST: CityController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

    }
}

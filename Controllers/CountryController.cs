using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sina_CSC_Project.Data;
using Sina_CSC_Project.Models;
using Sina_CSC_Project.Service;

namespace Sina_CSC_Project.Controllers
{
    public class CountryController : Controller
    {
        private readonly ICountryRepository _repo;

        private readonly IMapper _mapper;

        public CountryController(ICountryRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        // GET: CountryController
        public ActionResult Index()
        {
            var country = _repo.FindAll().ToList();
            var model = _mapper.Map<List<Country>, List<CountryDetailViewModel>>(country);

            return View(model);
        }

        // GET: CountryController/Details/5
        public ActionResult Details(int id)
        {
            if (!_repo.isExists(id))
            {
                return NotFound();
            }

            var country = _repo.FindById(id);
            var model = _mapper.Map<CountryDetailViewModel>(country);

            return View(model);
        }

        // GET: CountryController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CountryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CountryCreateViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }

                var country = _mapper.Map<Country>(model);
                var isSuccess = _repo.Create(country);
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

        // GET: CountryController/Edit/5
        public ActionResult Edit(int id)
        {
            if (!_repo.isExists(id))
            {
                return NotFound();
            }

            var country = _repo.FindById(id);
            var model = _mapper.Map<CountryDetailViewModel>(country);

            return View(model);
        }

        // POST: CountryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, CountryDetailViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }

                var country = _mapper.Map<Country>(model);
                var isSuccess = _repo.Update(country);
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

        // GET: CountryController/Delete/5
        public ActionResult Delete(int id)
        {
            var country = _repo.FindById(id);
            var isSuccess = _repo.Delete(country);
            if (!isSuccess)
            {
                return BadRequest();
            }

            return RedirectToAction(nameof(Index));
        }

        //// POST: CountryController/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}

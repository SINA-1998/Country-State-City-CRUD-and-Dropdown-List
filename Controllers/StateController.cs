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
    public class StateController : Controller
    {
        private readonly ApplicationDbContext _context;

        private readonly IStateRepository _repo;

        private readonly IMapper _mapper;

        public StateController(ApplicationDbContext context, IStateRepository repo, IMapper mapper)
        {
            _context = context;
            _repo = repo;
            _mapper = mapper;
        }

        // GET: StateController
        public ActionResult Index()
        {
            var state = _repo.FindAll().ToList();
            var model = _mapper.Map<List<State>, List<StateDetailViewModel>>(state);

            return View(model);
        }

        // GET: StateController/Details/5
        public ActionResult Details(int id)
        {
            if (!_repo.isExists(id))
            {
                return NotFound();
            }

            var region = _repo.FindById(id);
            var model = _mapper.Map<StateDetailViewModel>(region);

            return View(model);
        }

        // GET: StateController/Create
        public ActionResult Create()
        {
            ViewData["CountryId"] = new SelectList(_context.Countries, "CountryId", "CountryName");
            return View();
        }

        // POST: StateController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(StateCreateViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }

                var state = _mapper.Map<State>(model);
                var isSuccess = _repo.Create(state);
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

        // GET: StateController/Edit/5
        public ActionResult Edit(int id)
        {
            if (!_repo.isExists(id))
            {
                return NotFound();
            }

            var state = _repo.FindById(id);
            var model = _mapper.Map<StateDetailViewModel>(state);

            return View(model);
        }

        // POST: StateController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, StateDetailViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }

                var state = _mapper.Map<State>(model);
                var isSuccess = _repo.Update(state);
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

        // GET: StateController/Delete/5
        public ActionResult Delete(int id)
        {
            var region = _repo.FindById(id);
            var isSuccess = _repo.Delete(region);
            if (!isSuccess)
            {
                return BadRequest();
            }

            return RedirectToAction(nameof(Index));
        }

        //// POST: StateController/Delete/5
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

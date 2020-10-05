using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Sina_CSC_Project.Data;
using Sina_CSC_Project.Models;
using Sina_CSC_Project.Service;

namespace Sina_CSC_Project.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly ICityRepository _repo;

        private readonly IMapper _mapper;

        public HomeController(ILogger<HomeController> logger, ICityRepository repo, IMapper mapper)
        {
            _logger = logger;
            _repo = repo;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var city = _repo.FindAll().ToList();
            var model = _mapper.Map<List<City>, List<CityDetailViewModel>>(city);

            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

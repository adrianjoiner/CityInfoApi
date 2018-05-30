using CityInfo.API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityInfo.API.Controllers
{

	// As soon as DummyController is instantiated then an instance of CityInfoContext is created and hence our db
    public class DummyController :Controller
    {
		private CityInfoContext _ctx;
		public DummyController(CityInfoContext ctx)
		{
			_ctx = ctx;
		}

		// so we can check db created / connected
		[HttpGet]
		[Route("api/testdatabase")]
		public IActionResult TestDatabase()
		{
			return Ok();
		}

    }
}

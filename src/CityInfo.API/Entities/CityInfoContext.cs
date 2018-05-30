using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityInfo.API.Entities
{
    public class CityInfoContext : DbContext 
    {
		public CityInfoContext(DbContextOptions<CityInfoContext> options) : base(options)
		{
			// check for database and create if not there
			// Note this is just registering the db and not physically creating it
			Database.EnsureCreated();
		}
		public DbSet<City> Cities { get; set; }
		public DbSet<PointOfInterest> PointsOfInterest { get; set; }
    }
}

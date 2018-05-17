using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CityInfo.API.Models
{
	public class PointOfInterestForCreationDto
	{
		[Required(ErrorMessage ="Name value needs to be supplied")] // custom error message
		[MaxLength(50)]
		public string Name { get; set; }

		[MaxLength(200)] // default too long message if >200
		public string Description { get; set; }
	}
}

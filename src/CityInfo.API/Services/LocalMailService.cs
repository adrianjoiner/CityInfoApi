using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace CityInfo.API.Services
{
    public class LocalMailService : IMailService
    {
		private string _mailTo = "admin@my.company.com";
		private string _mailFrom = "noreply@my.company.com";

		public void Send(string subject, string message)
		{
			// send mail - output to debug window, no real implimentation
			Debug.WriteLine($"Mail from {_mailFrom}, to {_mailTo}, with LocalMailService");
			Debug.WriteLine($"Subject: {subject}");
			Debug.WriteLine($"Message: {message}");
		}
    }
}

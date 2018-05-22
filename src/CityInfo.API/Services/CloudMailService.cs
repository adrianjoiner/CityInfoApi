using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace CityInfo.API.Services
{
    public class CloudMailService : IMailService
    {
		public void Send(string subject, string message)
		{
			// send mail - output to debug window, no real implimentation
			Debug.WriteLine($"Mail from {_mailFrom}, to {_mailTo}, with CloudMailService");
			Debug.WriteLine($"Subject: {subject}");
			Debug.WriteLine($"Message: {message}");
		}
    }
}

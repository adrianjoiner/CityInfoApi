using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace CityInfo.API.Services
{
    public class CloudMailService : IMailService
    {
		// Use the configs in our added appSettings.json
		private string _mailTo = Startup.Configuration["mailSettings:mailToAddress"];
		private string _mailFrom = Startup.Configuration["mailSettigns:mailFromAddress"];

		public void Send(string subject, string message)
		{
			// send mail - output to debug window, no real implementation
			Debug.WriteLine($"Mail from {_mailFrom}, to {_mailTo}, with CloudMailService");
			Debug.WriteLine($"Subject: {subject}");
			Debug.WriteLine($"Message: {message}");
		}
    }
}

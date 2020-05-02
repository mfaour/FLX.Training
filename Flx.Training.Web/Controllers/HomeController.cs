using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Flx.Training.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;


namespace Flx.Training.Web.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;

		public HomeController(ILogger<HomeController> logger)
		{
			_logger = logger;
		}

		public IActionResult Index()
		{
			return View();
		}

		public IActionResult Privacy()
		{
			return View();
		}

		//[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		//public IActionResult Error()
		//{
		//	return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		//}

		public void Mail([FromBody] MailInfo info)
		{
			var smtp = new SmtpClient
			{
				Host = "smtp.gmail.com",
				Port = 587,
				EnableSsl = true,
				DeliveryMethod = SmtpDeliveryMethod.Network,
				UseDefaultCredentials = false,
				Credentials = new NetworkCredential(info.Account, info.Password)
			};
			using (var message = new MailMessage()
			{
				From = new MailAddress(info.Account, "FLX Training"),
				Subject = info.Subject,
				BodyEncoding = System.Text.Encoding.UTF8,
				IsBodyHtml = true,
				Body = info.Body
			})
			{
				
				message.To.Add(info.Receiver1);
				message.To.Add(info.Receiver2);
				message.To.Add(info.Receiver3);
				smtp.Send(message);
			}
		}
	}
}

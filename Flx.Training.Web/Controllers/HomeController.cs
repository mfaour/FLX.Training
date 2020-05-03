using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Flx.Training.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;


namespace Flx.Training.Web.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
		private readonly IConfiguration _configuration;

		private string _account;
		private string _password;
		private string _subject;
		private string _displayName;
		private string _smtp;
		private int _port;
		private string _receiver1;
		private string _receiver2;
		private string _receiver3;
		private string _body;

		public HomeController(ILogger<HomeController> logger, IConfiguration configuration)
		{
			_logger = logger;
			_configuration = configuration;

			_account = _configuration.GetSection("MailConiguration").GetSection("Account").Value;
			_displayName = _configuration.GetSection("MailConiguration").GetSection("DisplayName").Value;
			_password = _configuration.GetSection("MailConiguration").GetSection("Password").Value;
			_smtp = _configuration.GetSection("MailConiguration").GetSection("SMTP").Value;
			_port = Convert.ToInt32( _configuration.GetSection("MailConiguration").GetSection("Port").Value);
			_subject = _configuration.GetSection("MailConiguration").GetSection("Subject").Value;
			_receiver1 = _configuration.GetSection("MailConiguration").GetSection("Receiver1").Value;
			_receiver2 = _configuration.GetSection("MailConiguration").GetSection("Receiver2").Value;
			_receiver3 = _configuration.GetSection("MailConiguration").GetSection("Receiver3").Value;
			_body = _configuration.GetSection("MailConiguration").GetSection("MessageBody").Value;
		}

		public IActionResult Index()
		{
			return View();
		}

		public IActionResult Privacy()
		{
			return View();
		}

	
		public void Mail([FromBody] MailInfo info)
		{
			var smtp = new SmtpClient
			{
				Host = _smtp,// "smtp.gmail.com",
				Port = _port,//587,
				EnableSsl = true,
				DeliveryMethod = SmtpDeliveryMethod.Network,
				UseDefaultCredentials = false,
				Credentials = new NetworkCredential(
					_account,
					_password)
			};
			using (var message = new MailMessage()
			{
				From = new MailAddress(_account, _displayName),
				Subject = _subject,
				BodyEncoding = System.Text.Encoding.UTF8,
				IsBodyHtml = true,
				Body = String.Format(_body,info.Sender,info.MobileNumber,info.Package)
			})
			{
				
				message.To.Add(_receiver1);
				message.To.Add(_receiver2);
				message.To.Add(_receiver3);
				smtp.Send(message);
			}
		}
	}
}

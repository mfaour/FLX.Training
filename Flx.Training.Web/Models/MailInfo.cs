using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Flx.Training.Web.Models
{
	public class MailInfo
	{
		public string Account { get { return "trainingflx@gmail.com"; } }
		public string Password { get { return "P@ssw0rd!2"; } }


		public string Sender { get; set; }
		public string Receiver1 { get { return "ang@nationalbrains.com"; } }
		public string Receiver2 { get { return "sara@nationalbrains.com"; } }
		public string Receiver3 { get { return "galtalhah@nationalbrains.com"; } }
		public string Subject { get { return "FLX Training WEB"; } }
		public string MobileNumber { get; set; }
		public string Package { get; set; }

		public string SMTP { get { return "smtp.gmail.com"; } }
		public string Body { get { return $"Message from <b> {Sender}</b>, mobile number <b><a href=https://api.whatsapp.com/send?phone=+966{MobileNumber}>{MobileNumber}</a></b>, for the package <b>{Package} </b>."; } }
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Flx.Training.Web.Models
{
	public class MailInfo
	{

		public string Sender { get; set; }
		public string MobileNumber { get; set; }
		public string Package { get; set; }

		public string Body { get { return $"Message from <b> {Sender}</b>, mobile number <b><a href=https://api.whatsapp.com/send?phone=+966{MobileNumber}>{MobileNumber}</a></b>, for the package <b>{Package} </b>."; } }
	}
}

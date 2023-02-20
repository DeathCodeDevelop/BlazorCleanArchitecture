using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Requests.Identity
{
	public class TokenRequest
	{
		[Required]
		public string Id { get; set; }

		[Required]
		public string Username { get; set; }
	}
}

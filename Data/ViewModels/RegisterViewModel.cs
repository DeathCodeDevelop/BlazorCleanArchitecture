using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.ViewModels
{
	public class RegisterViewModel
	{
		[Required]
		public string? UserName { get; set; }

		[Required]
		public string? Password { get; set; }

		[Required]
		[Compare("Password")]
		public string? ConfirmPassword { get; set; }
	}
}

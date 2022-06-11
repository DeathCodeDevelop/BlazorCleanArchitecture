using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebUI.Helpers
{
	public static class GuidHelper
	{
		public static Guid TryParse(string? str) 
		{
			Guid guid = Guid.Empty;
			if(str != null)
				Guid.TryParse(str, out guid);
			return guid;
		}
	}
}

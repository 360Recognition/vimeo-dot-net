﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VimeoDotNet.Parameters
{
	public interface IParameterProvider
	{
		/// <summary>
		/// Performs validation and returns a description of the first error encountered.
		/// </summary>
		/// <returns>Description of first error, or null if none found.</returns>
		string ValidationError();

		/// <summary>
		/// Provides universal interface to retrieve parameter values.
		/// </summary>
		/// <returns>Returns all parameters as name/value pairs.</returns>
		IDictionary<string, string> GetParameterValues();
	}
}

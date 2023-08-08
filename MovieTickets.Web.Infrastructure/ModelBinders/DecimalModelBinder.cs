using Microsoft.AspNetCore.Mvc.ModelBinding;

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTickets.Web.Infrastructure.ModelBinders
{
	public class DecimalModelBinder : IModelBinder
	{
		public Task BindModelAsync(ModelBindingContext? bindingContext)
		{
			if (bindingContext == null)
			{
				throw new ArgumentNullException(nameof(bindingContext));
			}

			ValueProviderResult valueResult = bindingContext.ValueProvider
				.GetValue(bindingContext.ModelName);

			if (valueResult != ValueProviderResult.None && string.IsNullOrEmpty(valueResult.FirstValue))
			{
				decimal parseValue = 0m;

				bool success = false;

				try
				{
					string formDecValue = valueResult.FirstValue;
					formDecValue = formDecValue
						.Replace(",", CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator);

					formDecValue = formDecValue
						.Replace(".", CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator);

					parseValue = Convert.ToDecimal(formDecValue);

					success = true;
				}
				catch (FormatException fe)
				{
					bindingContext.ModelState.AddModelError(bindingContext.ModelName, fe, bindingContext.ModelMetadata);
				}

				if (success)
				{
					bindingContext.Result = ModelBindingResult.Success(parseValue);
				}
			}

			return Task.CompletedTask;
		}
	}
}

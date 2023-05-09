using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Threading.Tasks;
using WebTuyenDung.Constants;

namespace WebTuyenDung.Binders
{
    public class DateOnlyModelBinder : IModelBinder
    {
        public bool AllowNull { get; init; }

        public DateOnlyModelBinder(bool allowNull)
        {
            AllowNull = allowNull;
        }

        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            if (bindingContext == null)
            {
                throw new ArgumentNullException(nameof(bindingContext));
            }

            var modelName = bindingContext.ModelName;
            var valueResult = bindingContext.ValueProvider.GetValue(modelName);

            if (valueResult == ValueProviderResult.None || string.IsNullOrWhiteSpace(valueResult.FirstValue))
            {
                if (AllowNull)
                {
                    bindingContext.Result = ModelBindingResult.Success(null);
                }
                else
                {
                    bindingContext.ModelState.AddModelError(modelName, $"Field {modelName} is required");
                    bindingContext.Result = ModelBindingResult.Failed();
                }
            }

            bindingContext.ModelState.SetModelValue(modelName, valueResult);
            var rawValue = valueResult.FirstValue;

            if (!DateOnly.TryParseExact(rawValue, DateTimeFormatConstants.DATE_ONLY_FORMAT, out var value))
            {
                bindingContext.ModelState.AddModelError(modelName, $"Field {modelName} does not in valid format");
                bindingContext.Result = ModelBindingResult.Failed();
            }
            else
            {
                bindingContext.Result = ModelBindingResult.Success(value);
            }

            return Task.CompletedTask;
        }
    }
}

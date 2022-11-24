using System;
using System.Globalization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using Microsoft.Extensions.Logging;

namespace MyECommerceWebSite2022.Repositores
{
    public class InvariantDecimalModelBinder : IModelBinder
    {
        private readonly SimpleTypeModelBinder _baseBinder;


        //public IModelBinder GetBinder(ModelBinderProviderContext context)
        //{
        //    if (context == null)
        //    {
        //        throw new ArgumentNullException(nameof(context));
        //    }

        //    if (context.Metadata.ModelType == typeof(decimal))
        //    {
        //        ILoggerFactory loggerFactory = (ILoggerFactory)context.Services.GetService(typeof(ILoggerFactory));
        //        return new DecimalModelBinder(NumberStyles.AllowDecimalPoint,loggerFactory);
        //    }

        //    return null;
        //}

        public InvariantDecimalModelBinder(Type modelType , ModelBinderProviderContext context)
        {
            ILoggerFactory loggerFactory;
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            if (context.Metadata.ModelType == typeof(decimal))
            {
                 loggerFactory = (ILoggerFactory)context.Services.GetService(typeof(ILoggerFactory));
                _baseBinder = new SimpleTypeModelBinder(modelType, loggerFactory);
            }
           
           
        }

        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            if (bindingContext == null) throw new ArgumentNullException(nameof(bindingContext));

            var valueProviderResult = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);

            if (valueProviderResult != ValueProviderResult.None)
            {
                bindingContext.ModelState.SetModelValue(bindingContext.ModelName, valueProviderResult);

                var valueAsString = valueProviderResult.FirstValue;
                decimal result;

                // Use invariant culture
                if (decimal.TryParse(valueAsString, NumberStyles.AllowDecimalPoint | NumberStyles.AllowLeadingSign, CultureInfo.InvariantCulture, out result))
                {
                    bindingContext.Result = ModelBindingResult.Success(result);
                    return Task.CompletedTask;
                }
            }

            // If we haven't handled it, then we'll let the base SimpleTypeModelBinder handle it
            return _baseBinder.BindModelAsync(bindingContext);
        }
    }


}


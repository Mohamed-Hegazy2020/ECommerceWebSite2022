using System;
using System.Globalization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;

namespace MyECommerceWebSite2022.Repositores
{
    public class InvariantDecimalModelBinderProvider : IModelBinderProvider
    {
        public IModelBinder GetBinder(ModelBinderProviderContext context)
        {
            if (context == null) throw new ArgumentNullException(nameof(context));

            if (!context.Metadata.IsComplexType && (context.Metadata.ModelType == typeof(decimal) || context.Metadata.ModelType == typeof(decimal?)))
            {
                return new InvariantDecimalModelBinder(context.Metadata.ModelType,context);
            }

            return null;
        }
    }
}

using Microsoft.AspNetCore.Mvc.ModelBinding;
using ModelValidationExample.Models;

namespace ModelValidationExample.CustomModelBinders
{
    public class PersonModelBinder : IModelBinder

    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            var person = new PersonDto();

            if (bindingContext.ValueProvider.GetValue("personName").Length > 0)
            {
                person.PersonName = bindingContext.ValueProvider.GetValue("personName").FirstValue;

            }

            if(bindingContext.ValueProvider.GetValue("email").Length > 0)
            {
                person.Email = bindingContext.ValueProvider.GetValue("email").FirstValue;

            }

            if(bindingContext.ValueProvider.GetValue("phone").Length > 0)
            { 
                person.Phone = bindingContext.ValueProvider.GetValue("phone").FirstValue;

            }

            bindingContext.Result = ModelBindingResult.Success(person);
            return Task.CompletedTask;
        }
    }
}

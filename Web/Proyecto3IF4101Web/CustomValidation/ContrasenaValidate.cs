using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace Proyecto3IF4101Web.CustomValidation
{
    public class ContrasenaValidate : Attribute, IModelValidator
    {
        public string ErrorMessage { get; set; }
        public IEnumerable<ModelValidationResult> Validate(ModelValidationContext context)
        {
            return new List<ModelValidationResult>

                {
                   new ModelValidationResult("", ErrorMessage)
                };
        }
    }
}

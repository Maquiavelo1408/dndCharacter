using System;
using System.Collections.Generic;
using System.Text;
using BL.BusinessLogic.ViewModel;
using FluentValidation;

namespace BL.BusinessLogic.Validations
{
    public class SpellViewModelValidator : AbstractValidator<SpellViewModel>
    {
        public SpellViewModelValidator()
        {

        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Text;
using BL.BusinessLogic.ViewModels;
using FluentValidation;

namespace BL.BusinessLogic.Validations
{
    public class CharacterEquipmentViewModelValidator : AbstractValidator<CharacterEquipmentViewModel>
    {
        public CharacterEquipmentViewModelValidator()
        {

        }
    }
}

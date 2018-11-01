using AutoMapper;
using BL.BusinessLogic.ViewModel;
using DAL.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BL.BusinessLogic.ViewModels.Mappings
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Character, CharacterViewModel>()
                .ForMember(vm=> vm.ValueAligment, m=> m.MapFrom(e=> e.Aligment.Value));
            CreateMap<CharacterViewModel, Character>();
        }
    }
}

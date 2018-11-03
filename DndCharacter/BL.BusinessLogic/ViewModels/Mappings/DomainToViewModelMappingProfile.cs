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

            CreateMap<AbilityScore, AbilityScoreViewModel>()
                .ForMember(vm => vm.NameCharacter, m => m.MapFrom(e => e.Character.Name))
                .ForMember(vm => vm.ValueAbilityScore, m => m.MapFrom(e => e.AbilityScoreCollection.Value));
            CreateMap<AbilityScoreViewModel, AbilityScore>();

            CreateMap<CharacterEquipment, CharacterEquipmentViewModel>()
                .ForMember(vm=>vm.NameCharacter, m=> m.MapFrom(e=> e.Character.Name))
                .ForMember(vm=> vm.NameEquipment, m=> m.MapFrom(e=> e.Equipment.Name));
            CreateMap<CharacterEquipmentViewModel, CharacterEquipment>();

            CreateMap<CharacterFeat, CharacterFeatViewModel>()
                .ForMember(vm=> vm.NameCharacter, m=> m.MapFrom(e=> e.Character.Name))
                .ForMember(vm=> vm.NameFeat, m=>m.MapFrom(e=> e.Feat.Name));
            CreateMap<CharacterFeatViewModel, CharacterFeat>();

            CreateMap<CharacterSkill, CharacterSkillViewModel>()
                .ForMember(vm=> vm.NameCharacter, m=> m.MapFrom(e=> e.Character.Name))
                .ForMember(vm=> vm.NameSkill, m=> m.MapFrom(e=> e.Skill.Name));
            CreateMap<CharacterSkillViewModel, CharacterSkill>();

            CreateMap<CharacterSpell, CharacterSpellViewModel>()
                .ForMember(vm=> vm.NameCharacter, m=> m.MapFrom(e=> e.Character.Name))
                .ForMember(vm=> vm.NameSpell, m=> m.MapFrom(e=> e.Spell.Name));
            CreateMap<CharacterSpellViewModel, CharacterSpell>();

            CreateMap<Class, ClassViewModel>();
            CreateMap<ClassViewModel, Class>();

            CreateMap<Collection, CollectionViewModel>();
            CreateMap<CollectionViewModel, Collection>();
            CreateMap<DataCollection, DataCollectionViewModel>()
                .ForMember(vm=>vm.NameCollection, m=> m.MapFrom(e=> e.Collection.Name));
            CreateMap<DataCollectionViewModel, DataCollection>();

            CreateMap<Equipment, EquipmentViewModel>()
                .ForMember(vm=> vm.ValueTypeEquipment, m=> m.MapFrom(e=> e.TypeEquipment.Value));
            CreateMap<EquipmentViewModel, Equipment>();

            CreateMap<Feat, FeatViewModel>();
            CreateMap<FeatViewModel, Feat>();

            CreateMap<FeatFeature, FeatFeatureViewModel>()
                .ForMember(vm=> vm.IdFeat, m=> m.MapFrom(e=> e.Feat.Name))
                .ForMember(vm=> vm.IdCTypeFeat, m=> m.MapFrom(e=> e.TypeFeat.Value));
            CreateMap<FeatFeatureViewModel, FeatFeature>();

            CreateMap<Skill, SkillViewModel>()
                .ForMember(vm=> vm.ValueAbilityScore, m=> m.MapFrom(e=> e.AbilityScoreSkill.Value));
            CreateMap<SkillViewModel, Skill>();

            CreateMap<Spell, SpellViewModel>();
            CreateMap<SpellViewModel, Spell>();

            CreateMap<SpellClass, SpellClassViewModel>()
                .ForMember(vm=> vm.NameClass, m=> m.MapFrom(e=> e.Class.Name))
                .ForMember(vm=> vm.NameSpell, m=> m.MapFrom(e=> e.Spell.Name));
            CreateMap<SpellClassViewModel, Spell>();
        }
    }
}

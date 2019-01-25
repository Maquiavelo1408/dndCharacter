using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using BL.BusinessLogic.ViewModel;
using BL.BusinessLogic.ViewModels;
using DAL.Data.Repository;
using DAL.Model.Entities;

namespace BL.BusinessLogic.LogicHandler
{
    public class CharacterLoginHandler
    {
        private readonly DndRepository _dndRepository;
        public CharacterLoginHandler(DndRepository dndRepository)
        {
            _dndRepository = dndRepository;
        }
        #region Character
        public List<CharacterViewModel> GetCharacters()
        {
            var characters = _dndRepository.GetAll<Character>().ToList();

            return Mapper.Map<List<Character>, List<CharacterViewModel>>(characters);
        }

        public CharacterViewModel GetCharacterById(int id)
        {
            var entity = _dndRepository.GetSingle<Character>(a => a.Id == id, false, a=> a.Aligment);

            return Mapper.Map<Character, CharacterViewModel>(entity);
        }

        public CharacterViewModel CreateCharacter(CharacterViewModel viewModel)
        {
            var character = Mapper.Map<CharacterViewModel, Character>(viewModel);
            if (_dndRepository.GetSingle<Character>(a => a.Id == viewModel.Id, true) != null)
            {
                throw new Exception(string.Format(Resources.ValidationMessages.EntityM_Error_AlredyExist, nameof(Character)));
            }
            _dndRepository.Add(character);
            
            _dndRepository.Commit();
            character = _dndRepository.GetSingle<Character>(a => a.Id == character.Id, false, a=> a.Aligment);
            return Mapper.Map<Character, CharacterViewModel>(character);
        }

        public CharacterViewModel UpdateCharacter(CharacterViewModel viewModel)
        {
            var character = _dndRepository.GetSingle<Character>(a => a.Id == viewModel.Id);
            if (character == null)
                throw new Exception(string.Format(Resources.ValidationMessages.EntityM_Error_NotFound, nameof(Character)));

            character.Name = viewModel.Name;
            character.Level = viewModel.Level;
            character.IdCAligment = viewModel.IdCAligment;
            character.IdClass = viewModel.IdClass;
            character.PlayerName = viewModel.PlayerName;
            character.IdRace = viewModel.IdRace;
            character.ExperiencePoints = viewModel.ExperiencePoints;
            character.ProficiencyBonus = viewModel.ProficiencyBonus;
            character.ArmorClass = viewModel.ArmorClass;
            character.Initiative = viewModel.Initiative;
            character.Speed = viewModel.Speed;
            character.MaxHitPoints = viewModel.MaxHitPoints;
            character.CopperCoins = viewModel.CopperCoins;
            character.SilverCoins = viewModel.SilverCoins;
            character.ElectrumCoins = viewModel.ElectrumCoins;
            character.GoldCoins = viewModel.GoldCoins;

            _dndRepository.Update(character);
            _dndRepository.Commit();
            return Mapper.Map<Character, CharacterViewModel>(_dndRepository.GetSingle<Character>(a => a.Id == viewModel.Id, false, a => a.Aligment));
        }

        public void DeleteCharacter(int idCharacter)
        {
            var character = _dndRepository.GetSingle<Character>(a => a.Id == idCharacter);
            if (character == null)
                throw new Exception(string.Format(Resources.ValidationMessages.EntityM_Error_AlredyExist, nameof(Character)));
            try
            {
                _dndRepository.Delete(character);
                _dndRepository.Commit();
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format(Resources.ValidationMessages.EntityF_Error_Terminate, nameof(Character)));
            }
                
        }
        #endregion

        #region Class
        public List<ClassViewModel> GetClasses()
        {
            var classes = _dndRepository.GetAll<Class>().ToList();
            return Mapper.Map<List<Class>, List<ClassViewModel>>(classes);
        }

        public ClassViewModel GetClassById(int id)
        {
            var entity = _dndRepository.GetSingle<Class>(a => a.Id == id, false);
            return Mapper.Map<Class, ClassViewModel>(entity);
        }

        public ClassViewModel CreateClass(ClassViewModel viewModel)
        {
            var classEntity = Mapper.Map<ClassViewModel, Class>(viewModel);
            if (_dndRepository.GetSingle<Class>(a => a.Id == viewModel.Id) != null)
                throw new Exception(string.Format(Resources.ValidationMessages.EntityM_Error_AlredyExist, nameof(Class)));

            _dndRepository.Add(classEntity);
            _dndRepository.Commit();
            classEntity = _dndRepository.GetSingle<Class>(a => a.Id == classEntity.Id, false);
            return Mapper.Map<Class, ClassViewModel>(classEntity);
        }

        public ClassViewModel UpdateClass(ClassViewModel viewModel)
        {
            var entity = _dndRepository.GetSingle<Class>(a => a.Id == viewModel.Id);
            if (entity == null)
                throw new Exception(string.Format(Resources.ValidationMessages.EntityM_Error_NotFound, nameof(Class)));
            entity.Name = viewModel.Name;
            _dndRepository.Update(entity);
            _dndRepository.Commit();
            return Mapper.Map<Class, ClassViewModel>(_dndRepository.GetSingle<Class>(a => a.Id == viewModel.Id));
        }

        public void DeleteClass(int id)
        {
            var entity = _dndRepository.GetSingle<Class>(a => a.Id == id);
            if (entity == null)
                throw new Exception(string.Format(Resources.ValidationMessages.EntityM_Error_NotFound, nameof(Class)));
            _dndRepository.Delete(entity);
            _dndRepository.Commit();
        }
        #endregion

        #region Skill

        public List<CharacterSkillViewModel> GetSkillsByCharacter(int idCharacter)
        {
            var character = GetCharacterById(idCharacter);
            if (character == null)
                throw new Exception(string.Format(Resources.ValidationMessages.EntityM_Error_NotFound, nameof(Character)));

            var skills = _dndRepository.GetAllWhere(new List<System.Linq.Expressions.Expression<Func<CharacterSkill, bool>>>()
            {
                a=>a.IdCharacter == idCharacter
            }).ToList();

            return Mapper.Map<List<CharacterSkill>, List<CharacterSkillViewModel>>(skills);

        }

        public void SetSkillsToCharacter(int idCharacter, List<CharacterSkillViewModel> skills)
        {
            var character = GetCharacterById(idCharacter);

            if(character == null)
            {
                throw new Exception(string.Format(Resources.ValidationMessages.EntityM_Error_NotFound, nameof(Character)));
            }
            _dndRepository.DeleteWhere<CharacterSkill>(a => a.IdCharacter == idCharacter);
            var viewModel = Mapper.Map<List<CharacterSkillViewModel>, List< CharacterSkill>>(skills);
            _dndRepository.AddRange(viewModel);
            _dndRepository.Commit();
        }

        #endregion

        #region CharacterSpells

        public SpellKnowViewModel GetCharacterSpell(int idCharacter)
        {
            var character = _dndRepository.GetSingle<Character>(a => a.Id == idCharacter, false, a=> a.CharacterSpells);
            if (character == null)
                throw new Exception(string.Format(Resources.ValidationMessages.EntityM_Error_NotFound, nameof(Character)));

            var spells = _dndRepository.GetAllWhere(new List<System.Linq.Expressions.Expression<Func<Spell, bool>>>()
            {
                a=> character.CharacterSpells.Where(s=>s.IdSpell == a.Id).First() != null
            }).ToList();
            var characterSpells = new SpellKnowViewModel();
            foreach(var spell in spells)
            {
                var spellVM = Mapper.Map<Spell, SpellViewModel>(spell);
                switch (spell.Level)
                {
                    case 1:
                        characterSpells.SpellsLevel1.Add(spellVM);
                        break;
                    case 2:
                        characterSpells.SpellsLevel2.Add(spellVM);
                        break;
                    case 3:
                        characterSpells.SpellsLevel3.Add(spellVM);
                        break;
                    case 4:
                        characterSpells.SpellsLevel4.Add(spellVM);
                        break;
                    case 5:
                        characterSpells.SpellsLevel5.Add(spellVM);
                        break;
                    case 6:
                        characterSpells.SpellsLevel6.Add(spellVM);
                        break;
                    case 7:
                        characterSpells.SpellsLevel7.Add(spellVM);
                        break;
                    case 8:
                        characterSpells.SpellsLevel8.Add(spellVM);
                        break;
                    case 9:
                        characterSpells.SpellsLevel9.Add(spellVM);
                        break;
                    case 0:
                    default:
                        characterSpells.Cantrips.Add(spellVM);
                        break;
                }
            }
            return characterSpells;
        }

        #endregion

    }
}

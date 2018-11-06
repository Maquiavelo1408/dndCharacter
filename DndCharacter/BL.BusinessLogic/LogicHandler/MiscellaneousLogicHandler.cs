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
    public class MiscellaneousLogicHandler
    {
        private readonly DndRepository _dndRepository;
        public MiscellaneousLogicHandler(DndRepository dndRepository)
        {
            _dndRepository = dndRepository;
        }

        #region Equipment
        public List<EquipmentViewModel> GetEquipments()
        {
            var entities = _dndRepository.GetAll<Equipment>().ToList();
            return Mapper.Map<List<Equipment>, List<EquipmentViewModel>>(entities);
        }

        public EquipmentViewModel GetEquipmentById(int id)
        {
            var entity = _dndRepository.GetSingle<Equipment>(a => a.IdEquipment == id, false, a => a.TypeEquipment);
            if (entity == null)
                throw new Exception(string.Format(Resources.ValidationMessages.EntityM_Error_NotFound, nameof(Equipment)));
            return Mapper.Map<Equipment, EquipmentViewModel>(entity);
        }

        public EquipmentViewModel CreateEquipment(EquipmentViewModel viewModel)
        {
            var entity = _dndRepository.GetSingle<Equipment>(a => a.IdEquipment == viewModel.IdEquipment);
            if (entity != null)
                throw new Exception(string.Format(Resources.ValidationMessages.EntityM_Error_AlredyExist, nameof(Equipment)));
            else
                entity = Mapper.Map<EquipmentViewModel, Equipment>(viewModel);
            _dndRepository.Add(entity);
            _dndRepository.Commit();
            entity = _dndRepository.GetSingle<Equipment>(a => a.IdEquipment == viewModel.IdEquipment, false, a=> a.TypeEquipment);
            return Mapper.Map<Equipment, EquipmentViewModel>(entity);
        }

        public EquipmentViewModel UpdateEquipment(EquipmentViewModel viewModel)
        {
            var entity = _dndRepository.GetSingle<Equipment>(a => a.IdEquipment == viewModel.IdEquipment);
            if (entity == null)
                throw new Exception(string.Format(Resources.ValidationMessages.EntityM_Error_NotFound, nameof(Equipment)));

            entity.IdCTypeEquipment = viewModel.IdCTypeEquipment;
            entity.Name = viewModel.Name;
            entity.Cost = viewModel.Cost;

            _dndRepository.Update(entity);
            _dndRepository.Commit();
            return GetEquipmentById(entity.IdEquipment);
        }

        public void DeleteEquipment(int id)
        {
            var entity = GetEquipmentById(id);
            try
            {
                _dndRepository.Delete(entity);
                _dndRepository.Commit();
            }
            catch
            {
                throw new Exception(string.Format(Resources.ValidationMessages.EntityM_Error_Delete, nameof(Equipment)));
            }
        }
        #endregion

        #region Skill
        public List<SkillViewModel> GetSkills()
        {
            var skills = _dndRepository.GetAll<Skill>().ToList();
            return Mapper.Map<List<Skill>, List<SkillViewModel>>(skills);
        }

        public SkillViewModel GetSkillById(int id)
        {
            var skill = _dndRepository.GetSingle<Skill>(a => a.IdSkill == id, false, a => a.AbilityScoreSkill);
            if (skill == null)
                throw new Exception(string.Format(Resources.ValidationMessages.EntityF_Error_NotFound, nameof(Skill)));
            return Mapper.Map<Skill, SkillViewModel>(skill);
        }

        public SkillViewModel CreateSkill(SkillViewModel viewModel)
        {
            var skill = _dndRepository.GetSingle<Skill>(a => a.IdSkill==viewModel.IdSkill);
            if (skill != null)
                throw new Exception(string.Format(Resources.ValidationMessages.EntityF_Error_AlredyExist, nameof(Skill)));
            skill = Mapper.Map<SkillViewModel, Skill>(viewModel);
            _dndRepository.Add(viewModel);
            _dndRepository.Commit();
            skill = _dndRepository.GetSingle<Skill>(a => a.IdSkill == skill.IdSkill);
            return Mapper.Map<Skill, SkillViewModel>(skill);
        }

        public SkillViewModel UpdateSkill(SkillViewModel viewModel)
        {
            var skill = _dndRepository.GetSingle<Skill>(a => a.IdSkill == viewModel.IdSkill);
            if (skill == null)
                throw new Exception(string.Format(Resources.ValidationMessages.EntityF_Error_NotFound, nameof(Skill)));

            skill.IdCAbilityScore = viewModel.IdCAbilityScore;
            skill.Name = viewModel.Name;
            _dndRepository.Update(skill);
            _dndRepository.Commit();
            skill = _dndRepository.GetSingle<Skill>(a => a.IdSkill == viewModel.IdSkill, false, a=> a.AbilityScoreSkill); ;
            return Mapper.Map<Skill, SkillViewModel>(skill);
        }

        public void DeleteSkill(int id)
        {
            var skill = _dndRepository.GetSingle<Skill>(a => a.IdSkill == id);
            if (skill == null)
                throw new Exception(string.Format(Resources.ValidationMessages.EntityF_Error_NotFound, nameof(Skill)));
            _dndRepository.Delete(skill);
            _dndRepository.Commit();
        }
        #endregion
    }
}

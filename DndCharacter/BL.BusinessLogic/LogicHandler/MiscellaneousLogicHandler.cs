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
    }
}

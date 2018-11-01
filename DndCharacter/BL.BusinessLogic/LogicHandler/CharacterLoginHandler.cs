using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using BL.BusinessLogic.ViewModel;
using DAL.Data.Repository;
using DAL.Model.Entities;
using static DAL.Data.DndCharacterManagerContext;

namespace BL.BusinessLogic.LogicHandler
{
    public class CharacterLoginHandler
    {
        private readonly DndRepository _dndRepository;
        public CharacterLoginHandler(DndRepository dndRepository)
        {
            _dndRepository = dndRepository;
        }

        public CharacterViewModel GetCharacterById(int id)
        {
            var entity = _dndRepository.GetSingle<Character>(a => a.Id == id, false);

            return Mapper.Map<Character, CharacterViewModel>(entity);
        }
    }
}

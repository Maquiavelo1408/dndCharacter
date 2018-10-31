using System;
using System.Collections.Generic;
using System.Text;
using BL.BusinessLogic.ViewModel;
using static DAL.Data.DndCharacterManagerContext;

namespace BL.BusinessLogic.LogicHandler
{
    public class CharacterLoginHandler
    {
        private readonly DndContextFactory _dndContextFactory;
        public CharacterLoginHandler()
        {

        }

        public CharacterViewModel GetCharacterById(int id)
        {


            return new CharacterViewModel();
        }
    }
}

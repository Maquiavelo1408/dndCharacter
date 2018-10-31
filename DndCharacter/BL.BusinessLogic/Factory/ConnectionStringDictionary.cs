using DAL.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace BL.BusinessLogic.Factory
{
    public interface IConnectionStringDictionary
    {
        string GetConnectionString(int id, bool rebuild = true);
        string GetConnectionString(string id, bool rebuild = true);
    }

    public class ConnectionStringDictionary
    {
        private Dictionary<int, string> _dndDictionary;
        private Dictionary<string, string> _dataDbDictionary;
        private DndCharacterManagerContext _context;
        public ConnectionStringDictionary(DndCharacterManagerContext context)
        {
            _context = context;
            _dndDictionary = new Dictionary<int, string>();
            _dataDbDictionary = new Dictionary<string, string>();
        }

        public string GetConnectionString(int id, bool rebuild = true)
        {
            if (rebuild)
                if (_dndDictionary == null)
                    BuildDictionaryConIdDnd();
        }

        public void BuildDictionaryConIdDnd()
        {
            List<>
        }
    }
}

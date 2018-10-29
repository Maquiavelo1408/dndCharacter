using System;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace DndCharacter
{
    public class Character
    {
        public Character()
        {
            GetData();
        }
        public JObject GetData()
        {
            var data = JObject.Parse(File.ReadAllText("../DndCharacter/character/properties.json"));
            return data;
        }
    }
}

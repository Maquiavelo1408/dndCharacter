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
        public void GetData()
        {
            var data = JObject.Parse(File.ReadAllText("@./propertis.json"));
        }
    }
}

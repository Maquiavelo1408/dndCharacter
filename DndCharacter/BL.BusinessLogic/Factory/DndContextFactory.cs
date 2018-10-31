using System;
using System.Collections.Generic;
using System.Text;

namespace BL.BusinessLogic.Factory
{
    public interface IDndContextFactory
    {
        DndContextFactory CreateDndContext(int id, bool rebuildDictionary = true);
        DndContextFactory CreateDndContext(string id, bool rebuildDictionary = true);
    }

    public class DndContextFactory : IDndContextFactory
    {

    }
}

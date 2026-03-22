using System;
using System.Collections.Generic;
using System.Text;

namespace Project_Orin.Core.Interfaces
{
    public interface IWorldElement
    {
        string? Name { get; set; }

        IWorldElement Parent { get; set; }

        List<IComponent> Components { get; set; }
    }
}

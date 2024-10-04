using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookiesCookbook.Recipe.Ingradients
{
    internal interface IIngradient
    {
        int Id { get; set; }
        string Name { get; set;  }
        string InstructionOfPreparing { get; set; }

    }
}

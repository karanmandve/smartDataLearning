using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookiesCookbook.Recipe.Ingradients
{
    internal class Butter : IIngradient
    {
        public int Id = 3;
        public string Name = "Butter";
        public string InstructionOfPreparing = "Melt on low heat. Add to other ingredients.";
    }
}

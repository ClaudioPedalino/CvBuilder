using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvBuilder.AppUI.Models.Commands
{
    public class AddSkillCommand
    {
        public string Logo { get; set; }
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
    }
}

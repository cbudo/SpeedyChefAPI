using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeedyChefApi.Models
{
    class Preferences
    {
        public Member member { get; set; }
        public List<Member_Group> group {get;set;}
        public List<Tool> tools { get; set; }
        public List<Oven> ovens { get; set; }
        public List<Member_Allergen> allergens { get; set; }
    }
}

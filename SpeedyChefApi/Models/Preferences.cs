using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SpeedyChefApi.Models
{
    [DataContract]
    public class Preferences
    {
    }
    public class Member
    {
        public string memname { get; set; }
        public List<Member_Group> groups { get; set; }
        public List<Allergen> allergens { get; set; }
    }
    public class Member_Group
    {
        public string adminName { get; set; }
        public string Name { get; set; }
        public List<string> memershipNames { get; set; }
    }
    public class Allergen
    {
        public FoodItem FoodItem { get; set; }
    }
    public class FoodItem
    {
        public string FoodName { get; set; }
    }
}

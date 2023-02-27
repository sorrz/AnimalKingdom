using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalKingdom.Models
{
    internal class Dog : Animal
    {
        private string Color { get; set; }
        private bool Heritage { get; set; }


        public Dog(string name, int id, GenderEnum gender, AnimalTypeEnum type, string color, bool heritage, AnimalStatusEnum status)
            :base(name, id, gender, type, status)
        {
            Color = color;
            Heritage = heritage;
        }

    }
}

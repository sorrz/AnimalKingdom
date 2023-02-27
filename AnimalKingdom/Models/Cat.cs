using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalKingdom.Models
{
    internal class Cat : Animal
    {

        private string Color { get; set; }
        private string Description { get; set; }


        public Cat(string name, int id, GenderEnum gender, AnimalTypeEnum type, string color, string description, AnimalStatusEnum status)
            : base(name, id, gender, type, status)
        {
            Color = color;
            Description = description;
        }


    }
}

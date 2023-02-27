using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalKingdom.Models
{
    internal class Parrot : Animal
    {

        private string Color { get; set; }
        private double Wingspan { get; set; }



        public Parrot(string name, int id, GenderEnum gender, AnimalTypeEnum type, string color, double wingspan, AnimalStatusEnum status)
            : base(name, id, gender, type, status)
        {
            Color = color;
            Wingspan = wingspan;
        }


    }
}

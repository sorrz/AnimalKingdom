using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalKingdom.Data
{
    internal class App
    {
        public Shelter shelter = new Shelter();
        internal void Run()
        {
            Console.WriteLine("Welcome to AnimalKingdom!");
            shelter.Menu();

           
        }

       
    }
}

using AnimalKingdom.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using AnimalKingdom.Models;
using System.Reflection;
using System.Diagnostics;

namespace AnimalKingdom.Data
{
    internal class Shelter
    {
        
        public List<Animal> Animals;
        private static readonly string filePath = "C:\\Users\\danst\\source\\repos\\AnimalKingdom\\AnimalKingdom\\Files\\animals.json";
        public static string exportPath = "";

        public Shelter()
        {
            Animals = LoadAnimals();
        }

        private List<Animal>? LoadAnimals()
        {
            var text = File.ReadAllText(filePath);
            if (!string.IsNullOrEmpty(text))
                return JsonSerializer.Deserialize<List<Animal>>(text);
            else
                return new List<Animal>();
        }

        internal virtual void WriteToFile()
        {
            var content = JsonSerializer.Serialize(Animals);
            File.WriteAllText(filePath, content, Encoding.UTF8);
        }
        internal virtual void WriteToFile(List<Animal> content, string userPath)
        {
            var exportList = JsonSerializer.Serialize(content);
            File.WriteAllText(userPath, exportList, Encoding.UTF8);
        }

        public void Menu()
        {
            Console.WriteLine("Make a choice: ");
            Console.WriteLine("1.       Add a new Pet");
            Console.WriteLine("2.       List all Animals in the Shelter");
            Console.WriteLine("3.       List Pet's Up for Adoption");
            Console.WriteLine("4.       Create a new List for Export");
            Console.WriteLine("Esc      Exit the Program");
            Console.Write("\n: ");

            while (true)
            {

                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.D1:
                        AddAnimal();
                        break;
                    case ConsoleKey.D2:
                        ListAnimals();
                        break;
                    case ConsoleKey.D3:
                        ListSortedAnimals();
                        break;
                    case ConsoleKey.D4:
                        CreateExport();
                        break;
                    case ConsoleKey.Escape:
                        Environment.Exit(0);
                        break;

                }
            }
        }

        private void CreateExport()
        {
            Console.Write("Please enter a export filepath: ");
            exportPath = Console.ReadLine();
            var exportList = Animals.Where(e => e.AnimalStatus != AnimalStatusEnum.UnAdoptable).ToList().OrderBy(b => b.Id).ToList();
            WriteToFile(exportList, exportPath);
            Console.WriteLine($"Sorted List of Animals that are Adoptable has been created at {exportPath}.");
            Menu();
        }

        private void ListSortedAnimals()
        {
            var adoptAblePets = Animals.Where(e => e.AnimalStatus != AnimalStatusEnum.UnAdoptable || e.AnimalStatus != AnimalStatusEnum.SignedForAdoption).ToList();
            foreach (Animal item in adoptAblePets)
            {
                Console.WriteLine(item.Id + " " + item.Name + " " +  item.AnimalStatus);
            }
            Menu();
        }

        private void ListAnimals()
        {
            int counter = 1;
            foreach (Animal animal in Animals)
            {
                Console.WriteLine($"{counter}: {animal.Id}: {animal.Name} {animal.AnimalStatus} ");
                counter++;
            }
            Menu();
        }

        public void AddAnimal()
        {

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Which Type of Animal do you wanna add?: ");
                Console.WriteLine("1.       Dog");
                Console.WriteLine("2.       Cat");
                Console.WriteLine("3.       Parrot");
                Console.WriteLine("4.       Go back to Menu");
                Console.Write("\n: ");

                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.D1:
                        AddNew(AnimalTypeEnum.Dog);
                        break;
                    case ConsoleKey.D2:
                        AddNew(AnimalTypeEnum.Cat);
                        break;
                    case ConsoleKey.D3:
                        AddNew(AnimalTypeEnum.Parrot);
                        break;
                    case ConsoleKey.D4:
                        Menu();
                        break;


                }
            }
        }

        private void AddNew(AnimalTypeEnum typeOfAnimal)
        {
            Console.WriteLine($"Adding a new {typeOfAnimal}!");
            // Get the name
            Console.Write("What is the Pet's Name?: ");
            var name = Console.ReadLine();
            // Get the ID
            Console.Write("What is the ID?: ");
            var id = Convert.ToInt32(Console.ReadLine());
            // Get the Color
            Console.Write("What is the Color: ");
            var color = Console.ReadLine();
            // Create a new Type Object for Gender and Select the Gender
            GenderEnum gender = GetGender();

            // Create a new Type Object for Status and Select the Status
            AnimalStatusEnum status = GetStatus();

            if (typeOfAnimal == AnimalTypeEnum.Dog)
            {
                Console.Write($"Does your {typeOfAnimal} have a Heritage\n" +
                    $"true or false: ");
                var heritage = Convert.ToBoolean(Console.ReadLine());
                var newAnimal = new Dog(name, id, gender, typeOfAnimal, color, heritage, status);
                Animals.Add(newAnimal);

            }
            if (typeOfAnimal == AnimalTypeEnum.Cat)
            {
                Console.Write($"Add a Description to your {typeOfAnimal}: ");
                var description = Console.ReadLine();
                var newAnimal = new Cat(name, id, gender, typeOfAnimal, color, description, status);
                Animals.Add(newAnimal);

            }
            if (typeOfAnimal == AnimalTypeEnum.Parrot)
            {
                Console.Write($"What is the Wingspan of your {typeOfAnimal}: ");
                var wingspan = Convert.ToDouble(Console.ReadLine());
                var newAnimal = new Parrot(name, id, gender, typeOfAnimal, color, wingspan, status);
                Animals.Add(newAnimal);

            }

            WriteToFile();
        }

        private AnimalStatusEnum GetStatus()
        {
            AnimalStatusEnum y;
            Console.WriteLine("What's the Animals Status:\n" +
                "1. Up For Adoption\n" +
                "2. Signed for Adoption\n" +
                "3. No Child Household\n" +
                "4. Un-Adoptable");
            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.D1:
                    y = AnimalStatusEnum.UpForAdoption;
                    return y;
                case ConsoleKey.D2:
                    y = AnimalStatusEnum.SignedForAdoption;
                    return y;
                case ConsoleKey.D3:
                    y = AnimalStatusEnum.NoChildHousehold;
                    return y;
                case ConsoleKey.D4:
                    y = AnimalStatusEnum.UnAdoptable;
                    return y;
                default:
                    y = AnimalStatusEnum.UpForAdoption;
                    return y;
            }
        }

        private GenderEnum GetGender()
        {
            GenderEnum x;
            Console.WriteLine("Choose Gender:\n" +
                "1. Male \n" +
                "2. Female\n" +
                "3. Unknown");
            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.D1:
                    x = GenderEnum.Male;
                    return x;
                case ConsoleKey.D2:
                    x = GenderEnum.Female;
                    return x;
                case ConsoleKey.D3:
                    x = GenderEnum.Unknown;
                    return x;
                default:
                    x = GenderEnum.Unknown;
                    return x;

            }
        }
    }
}

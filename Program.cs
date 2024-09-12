using System;
using System.Collections.Generic;
using TextFile;

namespace Hobby_Animal
{
    class Program
    {
        static void Main(string[] args)
        {
            TextFileReader reader = new TextFileReader("input.txt");
            reader.ReadLine(out string line);
            int numAnimals = int.Parse(line);
            List<Animal> animals = new List<Animal>();

            Steve steve = new Steve();

            for (int i = 0; i < numAnimals; i++)
            {
                reader.ReadLine(out line);
                string[] animalData = line.Split(' ');
                char type = char.Parse(animalData[0]);
                string name = animalData[1];
                int exhilaration = int.Parse(animalData[2]);
                if(exhilaration < 0) exhilaration = 0;
                else if(exhilaration > 70) exhilaration = 70;

                Animal animal;
                switch (type)
                {
                    case 'T':
                        animal = new Tarantula(name, exhilaration);
                        break;
                    case 'H':
                        animal = new Hamster(name, exhilaration);
                        break;
                    case 'C':
                        animal = new Cat(name, exhilaration);
                        break;
                    default:
                        throw new ArgumentException("Invalid animal type.");
                }

                animals.Add(animal);
            }

            reader.ReadLine(out line);
            string moodSequence = line;
            int steveMood = 0;
            char mood = moodSequence[0];
            Console.Write($"Initial exhilaration levels - ");
            

            foreach (Animal animal in animals)
            {
                Console.Write($"{animal.GetType().Name[0]}: {animal.GetExhilaration()} ");
            }

            Console.WriteLine("\n");
           
            for (int day = 1; day <= moodSequence.Length; day++)
            {
                mood = moodSequence[day - 1]; 
                Console.WriteLine($"Day {day}: Mood - {GetMoodName(mood)}");

                bool allAnimalsHappy = true;
                foreach (Animal animal in animals)
                {

                    animal.SetState();
                    if (!animal.IsAlive()) continue;

                    switch (mood)
                    {
                        case 'j':
                            animal.Care(Joyful.Instance());
                            break;
                        case 'u':
                            animal.Care(Usual.Instance());
                            break;
                        case 'b':
                            animal.Care(Blue.Instance());
                            break;
                    }

                    if (animal.GetExhilaration() < 5)
                    {
                        allAnimalsHappy = false;
                    }
                }

                Console.Write($"After Day {day}: Exhilaration Levels - ");
                foreach (Animal animal in animals)
                {
                    Console.Write($"{animal.GetType().Name[0]}: {animal.GetExhilaration()} ");
                }
                Console.WriteLine();

                if (allAnimalsHappy)
                {
                    steveMood++;
                }

                List<Animal> highestExhilarationAnimals = Steve.FindHighestExhilarationAnimals(animals);
                Console.Write($"Animals of the highest exhilaration level at the end of day: ");
                foreach (Animal animal in highestExhilarationAnimals)
                {
                    Console.Write($"{animal.GetName()} ({animal.GetType().Name}), ");
                }
                Console.WriteLine();

                Console.WriteLine($"Steve's mood: {steveMood}");
                Console.WriteLine();
            }
        }
        static string GetMoodName(char mood)
        {
            switch (mood)
            {
                case 'j':
                    return "Joyful";
                case 'u':
                    return "Usual";
                case 'b':
                    return "Blue";
                default:
                    return "Unknown";
            }
        }    
    }
}

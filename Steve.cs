using Hobby_Animal;
using System.Numerics;

public class Steve
{
    public int Mood; 

    public Steve()
    {
        Mood = 0;
    }

    public void CheckMood(List<Animal> animals)
    {
        if (animals.All(a => a.GetExhilaration() >= 5))
            Mood++;
    }

    public static List<Animal> FindHighestExhilarationAnimals(List<Animal> animals)
    {
        List<Animal> highestExhilarationAnimals = new List<Animal>();
        int highestExhilaration = 0;

        foreach (Animal animal in animals)
        {
            if (animal.GetExhilaration() > highestExhilaration)
            {
                highestExhilaration = animal.GetExhilaration();
                highestExhilarationAnimals.Clear();
                highestExhilarationAnimals.Add(animal);
            }
            else if (animal.GetExhilaration() == highestExhilaration)
            {
                highestExhilarationAnimals.Add(animal);
            }
        }

        return highestExhilarationAnimals;
    }
}
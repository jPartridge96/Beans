using UnityEngine;

public class Coffee : Recipe
{
    public Coffee()
    {
        System.Random rand = new System.Random();
        int rand_cup = rand.Next(0, cups.Length - 1);

        //ingredients = new List<Ingredient> {
        //    new Ingredient(cups[rand_cup]),
        //    new Ingredient("Coffee")
        //};
    }
}


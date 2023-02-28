/*
Espresso.cs
Created date: 2.28.2023
Created by: Jordan partridge
Comment added by: Hyunjin Kim
 */

using UnityEngine;

/// <summary>
/// Script for espresso
/// </summary>
public class Espresso : Recipe
{
    public Espresso()
    {
        // Gernerate random cup
        System.Random rand = new System.Random();
        int rand_cup = rand.Next(0, cups.Length - 1);

        // Ingredients needed for espresso
        ingredients = new List<Ingredient> {
            new Ingredient(cups[rand_cup]),
            new Ingredient("Espresso")
        };
    }
}


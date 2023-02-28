/*
Order.cs
Created date: 2/28/2023
Created by: Jordan Partridge
Code added by: Jordan Partridge
Error fixed by: Hyunjin Kim
Comment added by: Hyunjin Kim
 */

using System;
using UnityEngine;
using System.Collections.Generic;

public class DrinkGenerator : MonoBehaviour
{
    // The type of drink generated
    public DrinkType drinkType;

    // The name of the drink generated
    public string drinkName = "";

    // List that contains order
    public List<string> order; 

    // Randomly generates a drink with modifications
    public void GenerateDrinkType()
    {
        // Get temperature;
        GenerateTemperature();

        // Grabs all values of type DrinkType
        Array values = Enum.GetValues(typeof(DrinkType));

        // Creates random number between 0 and length of all enum values
        System.Random rand = new System.Random();
        int enumIndex = rand.Next(values.Length);

        // Sets drinkType as random value
        drinkType = (DrinkType)values.GetValue(enumIndex);

        // Add to the order
        order.Add(drinkType.ToString());

        // Get dessert
        GenerateDessert();
       
    }

    // Generates hot or iced drink
    private void GenerateTemperature()
    {
        // Grabs all values of type ModificationType
        Array values = Enum.GetValues(typeof(TempType));

        // Creates random number between 0 and length of all enum values
        int enumIndex = UnityEngine.Random.Range(0, values.Length);

        // Adds modification to drink name
        TempType tempType = (TempType)values.GetValue(enumIndex);

        // Add to the order
        order.Add(tempType.ToString());
    }

    // Generates random modifications to the drink
    private void GenerateDessert()
    {
        // Grabs all values of type ModificationType
        Array values = Enum.GetValues(typeof(DessertType));

        // Creates random number between 0 and length of all enum values
        int enumIndex = UnityEngine.Random.Range(0, values.Length);

        // Adds modification to drink name
        DessertType dessertType = (DessertType)values.GetValue(enumIndex);

        // Add to the order
        order.Add(dessertType.ToString());
    }
}


// Enum for drink type
public enum DrinkType
{
    COFFEE,
    TEA,
}

// Enum for temperature
public enum TempType
{
    HOT,
    ICED
}

// Enum for desserts
public enum DessertType
{
    DONUT,
    CROISSANT,
    CAKE
}
using System;
using UnityEngine;
using System.Collections.Generic;

public class DrinkGenerator : MonoBehaviour
{
    // The type of drink generated
    public DrinkType drinkType;

    // The name of the drink generated
    public string drinkName = "";

    public List<string> order; 

    // Randomly generates a drink with modifications
    public void GenerateDrinkType()
    {
        GenerateTemperature();

        // Grabs all values of type DrinkType
        Array values = Enum.GetValues(typeof(DrinkType));

        // Creates random number between 0 and length of all enum values
        System.Random rand = new System.Random();
        int enumIndex = rand.Next(values.Length);

        // Sets drinkType as random value
        drinkType = (DrinkType)values.GetValue(enumIndex);
        order.Add(drinkType.ToString());

        GenerateDessert();

        foreach (var item in order)
        {
            Debug.Log(item);
        }
       
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
        order.Add(dessertType.ToString());
    }
}

public enum DrinkType
{
    COFFEE,
    TEA,
}

public enum TempType
{
    HOT,
    ICED
}

public enum DessertType
{
    DONUT,
    CROISSANT,
    CAKE
}
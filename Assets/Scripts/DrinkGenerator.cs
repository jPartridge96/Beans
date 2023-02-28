using System;
using UnityEngine;

public class DrinkGenerator : MonoBehaviour
{
    // The type of drink generated
    public DrinkType drinkType;

    // The name of the drink generated
    public string drinkName = "";


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
        drinkName += drinkType.ToString();

        GenerateDessert();

        Debug.Log(drinkName);
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
        drinkName += " " + tempType.ToString();
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
        drinkName += " with " + dessertType.ToString();
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
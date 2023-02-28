using System;
using UnityEngine;

public class DrinkGenerator : MonoBehaviour
{
    // The type of drink generated
    public DrinkType drinkType;

    // The name of the drink generated
    public string drinkName;

    // Whether the drink has creamer
    public bool hasCreamer;

    // Whether the drink has cinnamon powder
    public bool hasPowder;

    // Randomly generates a drink with modifications
    public void GenerateDrinkType()
    {
        // Grabs all values of type DrinkType
        Array values = Enum.GetValues(typeof(DrinkType));

        // Creates random number between 0 and length of all enum values
        System.Random rand = new System.Random();
        int enumIndex = rand.Next(values.Length);

        // Sets drinkType as random value
        drinkType = (DrinkType)values.GetValue(enumIndex);
        drinkName = drinkType.ToString();

        GenerateDessert();
    }

    // Generates random modifications to the drink
    private void GenerateDessert()
    {
        // Generate random number of modifications between 0 and 3
        int numModifications = UnityEngine.Random.Range(0, 4);

        for (int i = 0; i < numModifications; i++)
        {
            // Grabs all values of type ModificationType
            Array values = Enum.GetValues(typeof(ModificationType));

            // Creates random number between 0 and length of all enum values
            int enumIndex = UnityEngine.Random.Range(0, values.Length);

            // Adds modification to drink name
            ModificationType modificationType = (ModificationType)values.GetValue(enumIndex);
            drinkName += " " + modificationType.ToString();
        }
    }

    // Returns a random true or false value
    private bool RandTrueFalse()
    {
        return UnityEngine.Random.Range(0, 2) == 0;
    }
}

public enum DrinkType
{
    COFFEE,
    ICED_COFFEE,
    TEA,
    ICED_TEA
}

public enum DessertType
{
    DONUT,
    CROISSANT,
    CAKE
}

public enum ModificationType
{
    VANILLA,
    CARAMEL,
    HAZELNUT,
    ALMOND,
    CHOCOLATE
}

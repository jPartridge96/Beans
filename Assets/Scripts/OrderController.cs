using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderController : MonoBehaviour
{
    // List of possible drinks
    public List<Drink> drinks;

    // Place an order
    public void PlaceOrder()
    {
        // Choose a random drink from the list of possible drinks
        Drink drink = drinks[Random.Range(0, drinks.Count)];

        // Display the drink order
        Debug.Log("Order: " + drink.Name);

        // TODO: Add logic to create the drink and give it to the customer
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customer : MonoBehaviour
{
    public List<GameObject> order;

    public Customer()
    {
        order = CustomerManager.GenerateOrder();
    }

    public void PlaceOrder()
    {
        // TODO: Add logic to pass the order to the UI
    }

}

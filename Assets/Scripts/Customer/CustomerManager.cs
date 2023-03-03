using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class CustomerManager : MonoBehaviour
{
    public GameObject customerPrefab;
    public Transform counter;

    public bool isSpawning = true;
    public float minSpawnTime = 5f;
    public float maxSpawnTime = 10f;

    public static List<List<GameObject>> pendingOrders;

    private void Start()
    {
        StartCoroutine(SpawnCustomers());
    }

    public static List<GameObject> GenerateOrder()
    {
        List<GameObject> list = new List<GameObject>();
        
        // Pick a random food item
        // Pick a random drink item
        // Add food item and drink item ingredients to list

        return list;
    }

    private IEnumerator SpawnCustomers()
    {
        while (isSpawning)
        {
            // Wait for a random time between minSpawnTime and maxSpawnTime
            yield return new WaitForSeconds(Random.Range(minSpawnTime, maxSpawnTime));

            // Spawn a new customer and set their destination to the counter
            GameObject newCustomer = Instantiate(customerPrefab, transform.position, Quaternion.identity);
            CustomerController customerController = newCustomer.GetComponent<CustomerController>();
            customerController.SetDestination(counter.position);
        }
    }

    public static float DeliverOrder(List<GameObject> order)
    {
        List<GameObject> orderMade = CompareLists(order, pendingOrders);

        // An equation to output a score based on order accuracy.
        float rating = 5f;
        if (orderMade == null)
            return 0f;
        else return rating;
    }

    public static List<T> CompareLists<T>(List<T> currentList, List<List<T>> listsToCompare)
    {
        int highestMatches = 0;
        List<T> closestList = null;

        foreach (List<T> list in listsToCompare)
        {
            int matches = 0;
            foreach (T item in currentList)
                if (list.Contains(item))
                    matches++;

            if (matches > highestMatches)
            {
                highestMatches = matches;
                closestList = list;
            }
        }

        if (highestMatches == 0)
            return null;

        return closestList;
    }
}

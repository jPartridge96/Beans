using System.Collections;
using UnityEngine;

public class CustomerSpawner : MonoBehaviour
{
    // Reference to the customer prefab to spawn
    public GameObject customerPrefab;

    // Reference to the counter where customers will place their orders
    public Transform counter;

    public bool isSpawning = true;

    // Minimum and maximum time between spawns
    public float minSpawnTime = 5f;
    public float maxSpawnTime = 10f;

    // Start is called before the first frame update
    private void Start()
    {
        // Start the coroutine to spawn customers
        StartCoroutine(SpawnCustomers());
    }

    // Coroutine to spawn customers at random intervals
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
}

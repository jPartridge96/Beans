using UnityEngine;
using UnityEngine.AI;

public class CustomerController : MonoBehaviour
{
    // Reference to the NavMeshAgent component
    private NavMeshAgent navMeshAgent;

    // Reference to the OrderController component
    private OrderController orderController;

    // Start is called before the first frame update
    private void Start()
    {
        // Get references to NavMeshAgent and OrderController components
        navMeshAgent = GetComponent<NavMeshAgent>();
        orderController = GetComponent<OrderController>();
    }

    // Sets the destination for the NavMeshAgent component
    public void SetDestination(Vector3 destination)
    {
        navMeshAgent.SetDestination(destination);
    }

    // Called when the NavMeshAgent reaches its destination
    private void OnTriggerEnter(Collider other)
    {
        // If the collider is the counter, place an order
        if (other.CompareTag("Counter"))
        {
            orderController.PlaceOrder();
            Destroy(gameObject);
        }
    }
}

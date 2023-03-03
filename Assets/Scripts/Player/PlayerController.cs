using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int score = 0;
    public float maxHealth = 100f;
    public float currentHealth;

    private Animator animator;

    public GameObject currentDrink;
    public GameObject grabPoint;

    private void Start()
    {
        animator = GetComponent<Animator>();
        currentHealth = maxHealth;
    }

    private void Update()
    {
        controlAnimations();
    }

    public void IncreaseScore(int amount)
    {
        score += amount;
        // Update the score UI here
    }

    private void controlAnimations()
    {
        if (Input.GetMouseButtonDown(0))
            animator.SetTrigger("pickup");
    }
}

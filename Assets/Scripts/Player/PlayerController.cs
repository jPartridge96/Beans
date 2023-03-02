using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int score = 0;
    public float maxHealth = 100f;
    public float currentHealth;

    private Animator animator;
    private AnimationClip[] animationList;
    private bool isDead = false;

    public bool canHold;
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
        {
            animator.SetTrigger("pickup");
        }
    }


    public void DecreaseHealth(float amount)
    {
        currentHealth -= amount;
        // Update the health UI here
        if (currentHealth <= 0 && !isDead)
        {
            Die();
        }
    }

    private void Die()
    {
        isDead = true;
        animator.SetBool("isDead", true);
        // Handle player death here, such as restarting the level or showing a game over screen
    }
}

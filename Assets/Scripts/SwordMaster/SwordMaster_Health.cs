using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SwordMaster_Health : MonoBehaviour
{

    //Maximum number of healthbars player has available
    public int maxHealth = 3;
    //Current health of the player
    public int currentHealth;
    //Holds the list of healthbars on display
    public Image[] healthbars;
    //Sprite for fullbar
    public Sprite fullHealthBar;
    //Sprite for empty healthbar
    public Sprite emptyHealthBar;
    //Animator for the script to manipulate
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        animator.SetTrigger("Hurt");

        foreach (Image img in healthbars)
        {
            img.sprite = emptyHealthBar;
        }
        for (int i = 0; i < currentHealth; i++)
        {
            healthbars[i].sprite = fullHealthBar;
        }

        if(currentHealth <= 0)
        {
            animator.SetBool("IsDead", true);

        }
    }
}

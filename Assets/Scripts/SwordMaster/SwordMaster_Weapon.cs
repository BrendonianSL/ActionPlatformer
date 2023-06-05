using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordMaster_Weapon : MonoBehaviour
{
    //Determines whether the player is currently in combat near another enemy
    public bool InCombat;
    //Tracks on whether or not SpinAttack has been unlocked
    public bool SpinAttackUnlock = false;
    //Tracks on whether or not Block has been unlocked
    public bool BlockUnlock = false;
    //Tracks on whether or not Slam has been unlocked
    //Tracks on whether or not we have second slash unlock
    public bool Slash2Unlock = false;
    //Accesses the animator for the script to access and manipulate
    public Animator Animator;

    //Total cooldown time until we can attack next
    public float cooldownTime = 1.3f;
    //Tracks what combo we are currently on
    public static int combo;
    //Tracks the maximum combo we can do
    public static int maxCombo = 3;
    //Holds our current cooldown
    public float currentCooldown;
    float lastClickedTime = 0;
    float maxDelay = 1f;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Checks to see if Block has been pressed
        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            Block();
        }

        //Checks to see if Slam has been pressed
        if(Input.GetKeyDown(KeyCode.F))
        {
            Slam();
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            SpinAttack();
        }

        if (Input.GetKeyDown(KeyCode.T))
        {
            if(combo == 3)
            {
                return;
            }
            else
            {
                Slash();
            }     
        }

        if (Animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.5f && Animator.GetCurrentAnimatorStateInfo(0).IsName("Slash1"))
        {
            Animator.SetBool("Slash1", false);
        }
        if (Animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.5f && Animator.GetCurrentAnimatorStateInfo(0).IsName("Slash2"))
        {
            Animator.SetBool("Slash2", false);
        }
        if (Animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.5f && Animator.GetCurrentAnimatorStateInfo(0).IsName("Slash3"))
        {
            Animator.SetBool("Slash3", false);
            combo = 0;
        }

        if (Time.time - lastClickedTime > maxDelay)
        {
            combo = 0;
        }
    }
    public void Slash()
    {
        lastClickedTime = Time.time;
        combo++;
        Debug.Log("Attack " + combo);

        if (combo == 1)
        {
            Animator.SetBool("Slash1", true);
        }

        if (combo == 2)
        {
            Animator.SetBool("Slash1", false);
            Animator.SetBool("Slash2", true);
        }

        if (combo == 3)
        {
            Animator.SetBool("Slash2", false);
            Animator.SetBool("Slash3", true);
        }

    }

    public void SpinAttack()
    {
        //Checks to see if we have this move unlocked
        if (SpinAttackUnlock == false)
        {
            return;
        }

        //Executes the animation
        Animator.SetTrigger("SpinAttack");
        //Plays Sound Effect

    }

    public void Block()
    {
        //Checks to see if we have this move unlocked
        if (BlockUnlock == false)
        {
            return;
        }

        //Executes the animation
        Animator.SetTrigger("Block");
        //Plays Sound Effect
    }

    public void Slam()
    {
        //Checks to see if we have this move unlocked
        /*if (SlamUnlock == false)
        {
            return;
        }
        */
        //Executes the animation
        Animator.SetTrigger("Slam");
        //Plays Sound Effect
    }
}

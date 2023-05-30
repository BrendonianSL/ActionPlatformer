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

    public float cooldownTime = 2f;
    private float nextFireTime = 0f;
    public static int noOfClicks = 0;
    float lastClickedTime = 0;
    float maxComboDelay = 1;



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
    }
    public void Slash()
    {
        //Executes the animation
        Animator.SetTrigger("Slash");
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fox_Script : MonoBehaviour
{
    private Animator fox_anim;
    public GameObject atck_Fox;
    public float speed;
    private bool Moving;

    // Start is called before the first frame update
    void Start()
    {
        fox_anim = atck_Fox.GetComponent<Animator>();
    }
    void Update()
    {
        anim_movement();
    }
    //animation debugger to check if animations work with translation
    void anim_movement()
    {
        //attack animation, awaiting AI dev progress
        fox_anim.Play("fox_atk");
        fox_anim.SetBool("Is_Atk", false);
        fox_anim.SetBool("Is_Idle", true);
        this.gameObject.transform.Translate(Vector3.back * Time.deltaTime * speed);
        Moving = true;
        //when the player moves play the running animation, set the booleans in a order where the animation only triggers when we want it 
        if (Moving)
        {
            fox_anim.Play("fox_Run");
            fox_anim.SetBool("Is_Running", false);
            fox_anim.SetBool("Is_Idle", true);

        }

    }
}

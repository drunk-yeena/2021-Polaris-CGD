using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wolf_mvmnt : MonoBehaviour
{
    private Animator wolf_anim;
    public GameObject atck_Wolf;
    public float speed;
    private bool Moving;

    // Start is called before the first frame update
    void Start()
    {
        wolf_anim = atck_Wolf.GetComponent<Animator>();
    }
    void Update()
    {
        anim_movement();
    }
    //animation debugger to check if animations work with translation
    void anim_movement()
    {
       
        this.gameObject.transform.Translate(Vector3.back * Time.deltaTime * speed);
        Moving = true;
        //when the player moves play the running animation, set the booleans in a order where the animation only triggers when we want it 
        if(Moving)
        {
            wolf_anim.Play("W_Running");
            wolf_anim.SetBool("is_Running", false);
            wolf_anim.SetBool("is_Idle", true);
            
        }

    }
}

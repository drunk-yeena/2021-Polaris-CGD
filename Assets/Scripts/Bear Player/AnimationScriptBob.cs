using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationScriptBob : MonoBehaviour
{
    private Animator Anim;
    public GameObject Target_Animation_Object;
    // Start is called before the first frame update
    void Start()
    {
        Anim = Target_Animation_Object.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            Anim.Play("Head_Attack");
            Anim.SetBool("Is_Attacking",false);
            Anim.SetBool("Is_Idle", true);
        }
    }
}

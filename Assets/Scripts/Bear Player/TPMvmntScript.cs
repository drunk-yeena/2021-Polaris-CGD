using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TPMvmntScript : MonoBehaviour
{
    //character controller references the controller we assigned to our object in unity ()
    
    public Transform cam1;
    public float speed = 5f;
    public float SmoothTurnTime = 0.1f;
    float turnSmoothVelocity;
    private Animator run_anim;
    public GameObject Run_Target;
    public Rigidbody Bear_Rigid;
    void Start()
    {
        run_anim = Run_Target.GetComponent<Animator>();
    }
    void Update()
    {
        movementMethod();
        
    }
    void movementMethod()
    {
        //the ranges of these axis are -1 to 1
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        //we are not moving up and down so y is 0f
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (direction.magnitude >= 0.1f)
        {
            /*take the theta between the angle we need to move ,
             * Atan returns radians and for that we multiply with Rad2Degrees the + cam.eulerangles makes it so wherever the player looks that is the forward direction*/
            float TargeAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam1.eulerAngles.y;
            // works simillarly to Smoothdamp , create a smooth movement of the parameter we provide (in this case the change in direction from lets say -0.5 to -0.1)
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, TargeAngle, ref turnSmoothVelocity, SmoothTurnTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);


            Vector3 moveDir = Quaternion.Euler(0f, TargeAngle, 0f) * Vector3.forward;
            //always normalized when moving
            //controller.Move(moveDir.normalized * speed * Time.deltaTime);
            //when the player moves play the running animation, set the booleans in a order where the animation only triggers when we want it 
            transform.position += (moveDir.normalized * speed * Time.deltaTime);
            run_anim.Play("Running");
            run_anim.SetBool("Is_moving", false);
            run_anim.SetBool("Idle_run", true);
        }
    }    
}

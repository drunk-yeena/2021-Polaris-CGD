using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Follow : MonoBehaviour
{
    //variables
    public Transform toFollow;
    NavMeshAgent cub;
    bool following = true;
    public float cooldown = 10.0f;
    private float nextActivationTime = 0;
    private float disengageTime = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        //Get NavMesh component
        cub = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextActivationTime)
        {
            //If the F key is pressed
            if (Input.GetKeyDown(KeyCode.F))
            {
                print("Cub call ability used");
                following = true;
                disengageTime = Time.time + 5.0f;
                //Set value for the next time the ability can be activated
                nextActivationTime = Time.time + cooldown;
            }
        }

        if (following == true)
        {
            if (Time.time>disengageTime)
            {
                following = false;
            }
            FollowPlayer();
        }
        
    }

    void FollowPlayer()
    {
        //AI follow player position
        cub.destination = toFollow.position;
    }
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public int Max_Health = 4;
    public int currentHealth;
    public int knockback_Distance=10;
    public GameObject player;
    public Rigidbody RGI;
    public GameObject PointSystem;
    void Start()
    {
        currentHealth = Max_Health;
        
    }
    //bear can take damage and lose health, use it on other scripts to call it by Get component
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        knockBack_Effect();

        if (currentHealth<= 0)
        {
            Die();
        }  
    }
    //call point script add points to the integer
    void Die()
    {
        Destroy(this.gameObject);
       // PointSystem.GetComponent<Points_Script>().addPoints(1000);
        if(this.gameObject.name=="Wolf_Entity")
        {
            PointSystem.GetComponent<Points_Script>().addPoints(500);
        }
        if (this.gameObject.name == "Bear_Entity")
        {
            PointSystem.GetComponent<Points_Script>().addPoints(1000);
        }
    }
    //throws the targeted enemy back a few meters
    public void knockBack_Effect()
    {
        float distance = Vector3.Distance(this.gameObject.transform.position, player.transform.position);
        float lambda = 1 + knockback_Distance / distance;
        Vector3 result = ((player.transform.position) * (1 - lambda) + ((this.gameObject.transform.position) * (lambda)));
       this.gameObject.transform.position = Vector3.Lerp(this.gameObject.transform.position, result,1.0f*Time.deltaTime);
    }
  
}

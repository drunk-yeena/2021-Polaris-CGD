using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Enemy_Combat_Script : MonoBehaviour
{
    public Transform AttackBox;
    public float attackRange = 1f;
    public LayerMask Enemies;
    public int AttackDMG = 1;
    //for animation
    private Animator Anim;
    public GameObject Target_Animation_Object;
    public GameObject player_ref;
    //for text
    public TextMeshProUGUI Stun;
    
    void Start()
    {
        //set animator for this obj
        Anim = Target_Animation_Object.GetComponent<Animator>();
        //made it repeat 5 sec for debbuging
        InvokeRepeating("Attack", 0.5f, 5.0f);
       
    }

    void Update()
    {
        
          //Attack();

    }
    //visualizes our attack box to see where we are hitting
    void OnDrawGizmosSelected()
    {
        if (AttackBox == null)
            return;

        Gizmos.DrawWireSphere(AttackBox.position, attackRange);
    }
    void Attack()
    {
        Collider[] Friendlies_Hit = Physics.OverlapSphere(AttackBox.position, attackRange, Enemies);

        foreach (Collider Friendly in Friendlies_Hit)
        {
            if (Friendly.name == "Bebby")
            {
                Debug.Log("Cub Hit!");
                Friendly.GetComponent<Cub_HP>().TakeDamageAI(AttackDMG);
                Friendly.GetComponent<RemoveHP>().LoseHP(Friendly.GetComponent<Cub_HP>().currentHealth);
            }
            if (Friendly.name == "PlayerCharacter")
            {
                Friendly.GetComponent<CombatScript>().TakeDamage(AttackDMG);
                //you cannot call a IEnumator function wihout coroutine
                StartCoroutine(DisableScript(2f));
            }

        }
        //new lines for animation
        Anim.Play("Head_Attack");
        Anim.SetBool("Is_Attacking", false);
        Anim.SetBool("Is_Idle", true);
        
    }
    //disables player's movemement script
    IEnumerator DisableScript(float stun_time)
    {
        
        //Debug.Log("Stun function called");
        player_ref.GetComponent<TPMvmntScript>().enabled = false;
        Stun.GetComponent<Stun_txt_Script>().enableStunTXT();
        //after disable wait a specific amount of time and then enable again
         yield return new WaitForSeconds(stun_time);
        player_ref.GetComponent<TPMvmntScript>().enabled = true;
        Stun.GetComponent<Stun_txt_Script>().disableStunTXT();
    }
}



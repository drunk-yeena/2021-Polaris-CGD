using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Wolf_Combat : MonoBehaviour
{
    public Transform AttackBox;
    public float attackRange = 1f;
    public LayerMask Enemies;
    public int AttackDMG = 1;
    //for animation
    private Animator wolf_anim;
    public GameObject Target_Animation_Object;
    public GameObject player_ref;
    public TextMeshProUGUI Stun;
    void Start()
    {
        //set animator for this obj
        wolf_anim = Target_Animation_Object.GetComponent<Animator>();
        //made it repeat 5 sec for debbuging
        InvokeRepeating("Attack", 0.5f, 2.0f);

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
                StartCoroutine(DisableScript(1f));
            }

        }
        //new lines for animation
        wolf_anim.Play("Wolf_Atk");
        wolf_anim.SetBool("is_Attacking", false);
        wolf_anim.SetBool("is_Idle", true);

    }
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

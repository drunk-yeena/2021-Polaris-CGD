using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatScript : MonoBehaviour
{
    public int Max_Health = 4;
    int currentHealth;

    public Transform AttackBox;
    public float attackRange = 1f;
    public LayerMask Enemies;
    public int AttackDMG = 1;
    //for animation
    private Animator Anim;
    public GameObject Target_Animation_Object;
    public GameObject ENEMY_B;

    void Start()
    {
        Anim = Target_Animation_Object.GetComponent<Animator>();
        currentHealth = Max_Health;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Attack();
        }


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
        
        Collider[] Enemies_Hit = Physics.OverlapSphere(AttackBox.position, attackRange, Enemies);

        foreach (Collider Enemy in Enemies_Hit)
        {
            Debug.Log("Player hits!");
            if (Enemy.GetComponent<EnemyScript>().currentHealth > 0)
            {
                Enemy.GetComponent<EnemyScript>().TakeDamage(AttackDMG);
                Enemy.GetComponent<RemoveHP>().LoseHP(Enemy.GetComponent<EnemyScript>().currentHealth);
            }
        }
        //new lines for animation
        Anim.Play("Head_Attack");
        Anim.SetBool("Is_Attacking", false);
        Anim.SetBool("Is_Idle", true);
    }
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Die();
        }

        void Die()
        {
            Debug.Log( "Player is dead!");
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttackController : MonoBehaviour
{
    [SerializeField]
    Transform attackPoint;

    [SerializeField]
    float attackRadious;

    [SerializeField]
    public float damage;

    //Animator animator;

    //Agregar Attack Times per Second
    //[SerializeField]
    //float attackTimesPerSecond = 3.0F;

    //float currentTime = 0.0F;

    //float nextAttackTime = 0.0F;

    void Awake()
    {
        //animator = GetComponent<Animator>();
    }

    void Update()
    {
        //if (Input.GetButtonDown("Fire1"))
        //{
        //    if (currentTime > nextAttackTime)
        //    {
                //currentTime = 0.0F;
                //nextAttackTime = Time.deltaTime + (1.0F / attackTimesPerSecond);

                //animator.SetTrigger("melee");a 
        //    }
        //}
    }

    public void OnAttack()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(attackPoint.position, attackRadious);

        foreach (Collider2D collider in colliders)
        {
            HealthController healthController = collider.GetComponent<HealthController>();

            if (healthController != null)
            {
                healthController.TakeDamage(damage);
            }
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPoint.position, attackRadious);
    }
}

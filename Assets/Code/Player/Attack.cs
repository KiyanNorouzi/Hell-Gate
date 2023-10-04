using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FishNet.Object;
using FishNet.Connection;
 
public class Attack : NetworkBehaviour
{
 public int damage;
    public LayerMask playerLayer;
 
    public float timeBetweenAttack;
    float AttackTimer;
    private Animator animator;
    void Start()
    {
       animator = GetComponent<Animator>();
    }
 
    private void Update()
    {
        if (!base.IsOwner)
            return;
 
        if(Input.GetButton("Fire1"))
        {
            if(AttackTimer <= 0) { 
                animator.SetBool("Attack", true);
                Shoot();
                AttackTimer = timeBetweenAttack;        
            }
            else{
                animator.SetBool("Attack", false);
            }
        }
 
        if (AttackTimer > 0)
            AttackTimer -= Time.deltaTime;
    }
 
    private void Shoot()
    {
        ShootServer(damage, Camera.main.transform.position, Camera.main.transform.forward);
        
    }
 
    [ServerRpc(RequireOwnership = false)]
    private void ShootServer(int damageToGive, Vector3 position, Vector3 direction)
    {
        if (Physics.Raycast(position, direction, out RaycastHit hit) && hit.transform.TryGetComponent(out PlayerHealth enemyHealth))
        {
            enemyHealth.health -= damageToGive;

        }
    }
}

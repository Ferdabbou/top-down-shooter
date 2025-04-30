using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemyController : MonoBehaviour
{
    public float lookRadius = 10f;
    public float speed = 20f;
    public float shootCooldown = 2f;
    private float shootTimer = 0f;


    public float shootRange = 10f;
    public GameObject magicProjectilePrefab;
    public Transform firePoint;
    Transform target;
    NavMeshAgent agent;

    Animator animator;
    // Start is called before the first frame update
    void Start()
    {   
        target = PlayerManager.instance.player.transform;
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        animator = GetComponent <Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(target.position, transform.position);

        if(distance <= lookRadius)
        {
            animator.SetBool("isRunning",true);
            agent.SetDestination(target.position);
            
            if(distance <= agent.stoppingDistance)
            {
                animator.SetBool("isRunning",false);
                //attack the player (todo)
                FaceTarget();
            }
        }
        shootTimer += Time.deltaTime;
        if(distance <= shootRange && shootTimer >= shootCooldown){
            animator.SetBool("isRunning",false);
            Shoot();
            shootTimer = 0f ;
        }
        if(distance > shootRange && distance <= lookRadius ){
            animator.SetBool("isRunning",true);
            animator.SetBool("isShooting",false);
        }
        if(distance > shootRange && distance > lookRadius ){
            animator.SetBool("isRunning",false);
            animator.SetBool("isShooting",false);
        }
    }

    void FaceTarget(){
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime*5f); 
    }

    void OnDrawGizmosSelected() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }

    void Shoot()
    {
        animator.SetBool("isShooting",true);
        if (magicProjectilePrefab == null || firePoint == null || target == null)
        {
            Debug.LogWarning("Missing firePoint, target or projectile prefab.");
            return;
        }

        // Offset the target upward (chest height is ~1.5 meters)
        Vector3 targetPosition = target.position + Vector3.up * 1.5f;
        Vector3 direction = (targetPosition - firePoint.position).normalized;


        // Spawn projectile and aim at the player
        GameObject projectile = Instantiate(magicProjectilePrefab, firePoint.position, Quaternion.LookRotation(direction));          
    }
}

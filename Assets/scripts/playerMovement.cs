using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public float moveSpeed ;

    Rigidbody body;
    Animator animator;

    public Camera camera;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody>();
        animator = GetComponent <Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        move();
        rotate();
    }

    void rotate()
    {
        RaycastHit hit;
        Ray ray= camera.ScreenPointToRay(Input.mousePosition);

        if(Physics.Raycast(ray, out hit))
        {
                Vector3 hitpoint = hit.point;
            
                hitpoint.y = transform.position.y;

                transform.LookAt (hitpoint);
             
        }
    }

    void move()
    {
        animator.SetBool("walkForward",false);
        animator.SetBool("walkBackward",false);
        animator.SetBool("walkLeft",false);
        animator.SetBool("walkRight",false);

        if(Input.GetKey(KeyCode.W))
        {
            body.velocity += transform.forward * moveSpeed;
            animator.SetBool("walkForward",true);
        }

         if(Input.GetKey(KeyCode.S))
        {
            body.velocity -= transform.forward * moveSpeed;
            animator.SetBool("walkBackward",true);
        }
         if(Input.GetKey(KeyCode.A))
        {
            body.velocity -= transform.right * moveSpeed;
            animator.SetBool("walkLeft",true);
        }
         if(Input.GetKey(KeyCode.D))
        {
            body.velocity += transform.right * moveSpeed;
            animator.SetBool("walkRight",true);
        }
        
    }
}

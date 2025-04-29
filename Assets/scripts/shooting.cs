using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shooting : MonoBehaviour
{   
    public Transform firePoint;
    public GameObject arrowPrefab;

    public Camera myCam;

    public float arrowSpeed = 20f;

    Animator myAnimator;

    void Start()
    {
        myAnimator = GetComponent<Animator>();
        if (myCam == null)
        {
            myCam = Camera.main;
        }
    }

   

    // Update is called once per frame
    void Update()
    {
        myAnimator.SetBool("shooting",false);
        if (Input.GetButtonDown("Fire1")){
            shoot();
        }       
    }

    void shoot(){
        myAnimator.SetBool("shooting",true);
        Ray ray= myCam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
       
         if(Physics.Raycast(ray, out hit))
        {
                Vector3 hitpoint = hit.point;
                hitpoint.y = firePoint.position.y;

                Vector3 direction = (hitpoint - firePoint.position).normalized;

                GameObject arrow = Instantiate(arrowPrefab, firePoint.position, Quaternion.LookRotation(direction) * Quaternion.Euler(90, 0, 0));
                Rigidbody rb = arrow.GetComponent<Rigidbody>();
                rb.velocity = direction * arrowSpeed;
        }

        
    }

    /*void rotate()
    {
        RaycastHit hit;
        Ray ray= myCam.ScreenPointToRay(Input.mousePosition);

        if(Physics.Raycast(ray, out hit))
        {
                Vector3 hitpoint = hit.point;
            
                hitpoint.y = transform.position.y;

                transform.LookAt (hitpoint);
             
        }
    }*/
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour
{
    public float cameraHeight;
    public float cameraDistance;
    public float cameraSpeed;

    public GameObject target;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        Vector3 targetPosition = target.transform.position;

        targetPosition.y += cameraHeight;
        targetPosition.z -= cameraDistance;

        transform.position = Vector3.Lerp(transform.position, targetPosition, cameraSpeed * Time.deltaTime);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hook : MonoBehaviour { 

    public LayerMask collisionMask;

    public Transform hook;
    private float speed = 15;
    private float rotationSpeed = 800;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Move hook forwards
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
        //Rotate the hook
        hook.Rotate(Vector3.up * Time.deltaTime * rotationSpeed);

        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, Time.deltaTime * speed + .6f, collisionMask))
        {
            Debug.Log("Object collision");
            Vector3 reflectDir = Vector3.Reflect(ray.direction, hit.normal);
            float rot = 90 - Mathf.Atan2(reflectDir.z, reflectDir.x) * Mathf.Rad2Deg;
            transform.eulerAngles = new Vector3(0, rot, 0);

        }
    } 
}

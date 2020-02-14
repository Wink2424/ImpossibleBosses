using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hook : MonoBehaviour {

    
    public LayerMask collisionMask;
    public List<Vector3> bouncePositions = new List<Vector3>();
    public Transform hook;
    private float speed = 15;
    private float rotationSpeed = 800;
    private int bounceCount = 0;
    private float hookRange = 15f;

    /*public Hook (float Speed, float range)
    {
        hookRange = range;
        speed = Speed;
    }*/
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
            
            
            
            Vector3 temp = new Vector3(hook.position.x, hook.position.y, hook.position.z);
            Debug.Log("Vector3 temp =  " + temp.ToString());
            bouncePositions.Add(temp);
            Debug.Log(GetInstanceID().ToString());

        }
    }
    
}

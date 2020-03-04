using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hook : MonoBehaviour {

    
    public LayerMask collisionMask;
    public List<Vector3> bouncePositions = new List<Vector3>();
    public Transform hook;
    private float speed = 10;
    private float rotationSpeed = 800;
    private float hookRange = 15;
    private float distanceTraveled = 0;
    Vector3 hookStart = new Vector3(0,0,0);
    private GameObject playerObj = null;



    public void setHookRange(float hookrange)
    {
        hookRange = hookrange;
    }

    

    // Start is called before the first frame update
    void Start()
    {
        
        
        //Starting position, to be updated to reference player transform
        
    }




    // Update is called once per frame
    void Update()
    {
        //1: move hook forward 
        //2: set hookStart/bouncePosition[0] to player Position as ... the return path.
        //3: if hook range has been reached, move hook towards transform to last bouncePosition in list
        //3a:   if last bouncePosition is 001f away, remove last bouncePosition in list.
        //4: else hook range has not been reached, detect for collision
        //4a: if hook collision occurs, add to bouncePosition[next]
        //5: 

        int bounceCount = bouncePositions.Count - 1;
        if (bouncePositions.Count == 0)
        { //populate first array position
            bouncePositions.Add(new Vector3(0, 0, 0));
        }
        hookStart = new Vector3(GetPlayerPosition().transform.position.x,
            GetPlayerPosition().transform.position.y, GetPlayerPosition().transform.position.z);
        bouncePositions[0] = hookStart; //assign index 0 to player position
        //if (hookStart == new Vector3(0, 0, 0))
        //{
        //    hookStart = new Vector3(hook.position.x, hook.position.y, hook.position.z);
        //}

        //Move hook forwards
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
        //Rotate the 
        // <IMPLEMENT GRAPHIC ROTATION TO 
        // hook.Rotate(Vector3.up * Time.deltaTime * rotationSpeed);
        
            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, Time.deltaTime * speed + .6f, collisionMask))
            {
                Debug.Log("Object collision");
                Vector3 reflectDir = Vector3.Reflect(ray.direction, hit.normal);
                float rot = 90 - Mathf.Atan2(reflectDir.z, reflectDir.x) * Mathf.Rad2Deg;
                transform.eulerAngles = new Vector3(0, rot, 0);

            if (distanceTraveled < hookRange)
            {
                Vector3 temp = new Vector3(hook.position.x, hook.position.y, hook.position.z);
                bouncePositions.Add(temp);
            }
            }
        
        else
        {
            if(bounceCount != 0)
            {

            }
        }


        
        for (int i = 1; i < bouncePositions.Count + 1; i++)
            {
            
            if (bouncePositions.Count == 1)
            {
                distanceTraveled = Vector3.Distance(new Vector3(hook.position.x, hook.position.y, hook.position.z),hookStart);
                
            }
            if (bouncePositions.Count > 1)
                distanceTraveled += Vector3.Distance
                    (new Vector3(hook.position.x, hook.position.y, hook.position.z)
                    , bouncePositions[i - 1]);
           

        }
        
        //}


        // NEED TO REMOVE THE BOUNCE POINT IF WE HAVE REACHED A SPECIFIC RANGE USING VECTOR3.DISTANCE = .001F????? LINES 107 - 131
        /*
        if (distanceTraveled >= hookRange)
        {
            if (bouncePositions.Count == 0)
            {
                Debug.Log(bounceCount);
            }
            else
            {
                Debug.Log(bounceCount + "else");
                if (Vector3.Distance(bouncePositions[bounceCount], transform.position) > .01f)
                {
                    bouncePositions.RemoveAt(bounceCount);
                }
                transform.position = Vector3.MoveTowards(transform.position, bouncePositions[bounceCount], Time.deltaTime * speed);
            }
            */


            //if (bouncePositions.Count > 1)
            //{
            //    //for (int i = bouncePositions.Count-1; i > 1;)
            //    while(bouncePositions.Count >= 1)
            //    {
            //        int nextPosition = bouncePositions.Count - 1; //-1 to use as index
            //        transform.position = Vector3.MoveTowards(transform.position, bouncePositions[nextPosition], Time.deltaTime * speed);
            //        Debug.Log("Moving to " + bouncePositions[nextPosition] + " " + nextPosition);
            //        if(.01f > Vector3.Distance(transform.position,bouncePositions[nextPosition]))
            //        {
            //            bouncePositions.RemoveAt(nextPosition);
            //        }
            //    }
            //}
        
        
    }

    

    private GameObject GetPlayerPosition()
    {
        if (playerObj == null)
            playerObj = GameObject.Find("Player");
        return playerObj;
    }


}



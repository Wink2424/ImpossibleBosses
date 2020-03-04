using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Hook : MonoBehaviour
{


    public LayerMask collisionMask;
    public List<Vector3> bouncePositions = new List<Vector3>();
    public Transform hook;
    private float speed = 10;
    private float rotationSpeed = 800;
    private float hookRange = 15;
    private float distanceTraveled = 0;
    private bool traveling;
    Vector3 hookStart = new Vector3(0, 0, 0);
    private GameObject playerObj = null;



    public void setHookRange(float hookrange)
    {
        hookRange = hookrange;
    }


    // Start is called before the first frame update
    void Start()
    {
        //Starting position, to be updated to reference player transform
        if (bouncePositions.Count == 0)
        {
            bouncePositions.Add(new Vector3(0, 0, 0));
        }


        // set the initial state for the hook to traveling
        traveling = true;
    }


    // Update is called once per frame
    void Update()
    {

        // Assign bouncePositions[0] to player's current position
        hookStart = new Vector3(GetPlayerPosition().transform.position.x,
            GetPlayerPosition().transform.position.y, GetPlayerPosition().transform.position.z);
        bouncePositions[0] = hookStart;

        // The hook is still moving from its initial throw
        if (traveling)
        {
            //Move hook forwards
            transform.Translate(Vector3.forward * Time.deltaTime * speed);

            // Check for bouncePositions
            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, Time.deltaTime * speed + .6f, collisionMask))
            {
                Vector3 reflectDir = Vector3.Reflect(ray.direction, hit.normal);
                float rot = 90 - Mathf.Atan2(reflectDir.z, reflectDir.x) * Mathf.Rad2Deg;
                transform.eulerAngles = new Vector3(0, rot, 0);

                if (distanceTraveled < hookRange)
                {
                    Vector3 temp = new Vector3(hook.position.x, hook.position.y, hook.position.z);
                    bouncePositions.Add(temp);
                }
            }
        }
        else
        {
            // Grab last position in bouncePositions
            var lastPosition = bouncePositions.LastOrDefault();

            // Move this item towards the last bounce position
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(lastPosition.x, lastPosition.y, lastPosition.z), speed * Time.deltaTime);

            // if the last position is where the hook is
            if (transform.position == lastPosition)
            {
                // if the last position is the same as the only bounce position left
                if (lastPosition == bouncePositions.FirstOrDefault())
                {
                    // Destroy the Hook Game Object
                    Destroy(this.gameObject);
                }

                // Remove the last bounce position 
                bouncePositions.RemoveAt(bouncePositions.Count - 1);
            }

        }


        // Calculate the distance the hook is total from player (including each bounce)
        distanceTraveled = 0;
        bouncePositions.ForEach(x => distanceTraveled += Vector3.Distance(new Vector3(hook.position.x, hook.position.y, hook.position.z), x));

        // if the distance traveled is more than the range of the player
        if (distanceTraveled > hookRange)
        {
            // Start the returning process for the hook
            traveling = false;
        }
    }



    private GameObject GetPlayerPosition()
    {
        if (playerObj == null)
            playerObj = GameObject.Find("Player");
        return playerObj;
    }


}



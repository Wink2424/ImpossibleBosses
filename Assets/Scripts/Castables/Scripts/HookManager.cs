using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookManager : MonoBehaviour
{
    public Vector3 offset = new Vector3(0, .6f);
    public GameObject activeHook;
    public GameObject HookObject;
    public float hookRange = 15;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Hook"))
            {
            activeHook = Instantiate(HookObject, transform.position + offset, transform.rotation);
            if (HookObject.GetInstanceID() != null)
            {
                Debug.Log(activeHook.GetInstanceID());
            }
        }
        
        
    }

    
}

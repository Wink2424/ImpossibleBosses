using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookManager : MonoBehaviour
{
    public Vector3 offset = new Vector3(0, .6f);
    public GameObject HookObject;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Hook"))
        {
            Debug.Log("Hook thrown");
            Instantiate(HookObject, transform.position + offset, transform.rotation);
        }
    }
}

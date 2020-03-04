using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookManager : MonoBehaviour
{
    public Vector3 offset = new Vector3(0, .6f);
    public GameObject activeHook;
    public GameObject HookObject;

    private PlayerStats playerStats;

    // Start is called before the first frame update
    void Start()
    {
        playerStats = gameObject.GetComponent<PlayerStats>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Hook"))
            {
            var activeHook = Instantiate(HookObject, transform.position + offset, transform.rotation);
            activeHook.gameObject.GetComponent<Hook>().setHookRange(playerStats.hookRange.GetValue());


        }
        
        
        
    }

    
}

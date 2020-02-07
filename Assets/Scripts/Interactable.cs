﻿using UnityEngine;

public class Interactable : MonoBehaviour {

    public float radius = 3f;
    public Transform interactionTransform;

    bool isFocus = false;
    Transform player;

    public bool hasInteracted = false;

    public virtual void Interact()
    {
        //Overriden/Abstract method
        // Debug.Log("Interacting with " + transform);
    }

    void Update()
    {
        if (isFocus && !hasInteracted)
        {
            float distance = Vector3.Distance(player.position, interactionTransform.position);
            if(distance < radius)
            {
                
                Interact();
                hasInteracted = true;
            }
        }
    }

    public void onFocused(Transform playerTransform)
    {
        isFocus = true;
        player = playerTransform;
        hasInteracted = false;
    }

    public void onDefocused ()
    {
        isFocus = false;
        player = null;
        hasInteracted = false;

    }
    
       void OnDrawGizmosSelected ()
            {

        if (interactionTransform == null)
            interactionTransform = transform;    

            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(interactionTransform.position, radius);
            }
    
}

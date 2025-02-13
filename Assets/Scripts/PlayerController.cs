﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour {

    public Interactable focus;

    public LayerMask movementMask;

    Camera cam;
    PlayerMotor motor;
	// Use this for initialization
	void Start () {
        cam = Camera.main;
        motor = GetComponent<PlayerMotor>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit, 100, movementMask))
            {

                motor.MoveToPoint(hit.point);
                //Move our player to what we hit

                // Stop focusing any objects
                RemoveFocus();
            }
        }

        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100))
            {
                Interactable interactable = hit.collider.GetComponent<Interactable>();
                //check if we hit an interactable
                //set as focus if it is
                if (interactable != null)
                {
                    SetFocus(interactable);

                }
            }
        }
        
    }
    void SetFocus(Interactable newFocus)
    {
        if (newFocus != focus)
        {
            if (focus != null)
                focus.onDefocused();

            focus = newFocus;
            motor.FollowTarget(newFocus);
        }

        newFocus.onFocused(transform);
    }

    void RemoveFocus ()
    {
        if (focus != null)
        {
            focus.onDefocused();
        }

        focus = null;
        motor.StopFollowingTarget();
    }
}

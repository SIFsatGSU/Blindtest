
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCast2 : MonoBehaviour {
    Ray ray;
    RaycastHit hit;
    private bool alreadyHit = false;
	// Use this for initialization
	void Start () {
        Debug.Log("RayCast2 Loaded Properly.");
	}
	
	// Update is called once per frame
	void Update () {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        
        //Testing -- Jack's Implementation of Zane's format
        bool hitOrNot = Physics.Raycast(ray, out hit) && hit.collider.gameObject.tag.Equals("ray_object"); 

        if (hitOrNot && !alreadyHit) { // If mouse hits object
            print(hit.collider.name);
            AudioSource tone = gameObject.GetComponent<AudioSource>();

            tone.Play();




            
        }

        if (!hitOrNot && alreadyHit) { // After object is hit, and leaves 
            print("Hit no more");
        }

        alreadyHit = hitOrNot; // Always lag behind a frame. 


        /* Old Cold -- Deprecated 
        if (Physics.Raycast(ray, out hit))
        {
            //print(hit.collider.name);

            /*if (hit.collider.gameObject.tag.Equals("ray_object"))
            {
                print(hit.collider.name);
            }
        }
        */

    }
}

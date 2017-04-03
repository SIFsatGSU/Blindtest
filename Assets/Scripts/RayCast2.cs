
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCast2 : MonoBehaviour {
    Ray ray;
    RaycastHit hit;
	public AudioSource tone;

	// distance constraints
	public float max_distance;
	public float min_distance;

	// pitch constraints 
	public float max_pitch;
	public float min_pitch;

	public GameObject testSphere;
    private bool alreadyHit = false;

	// Use this for initialization
	void Start () {
        Debug.Log("RayCast2 Loaded Properly.");
	}
	
	// Update is called once per frame
	void Update () {
        //ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		ray = new Ray(this.transform.position, this.transform.forward);
		Debug.DrawRay(ray.origin, ray.direction * 10); // Draws the ray on the "box" hands in the monitor window

        //Testing -- Jack's Implementation of Zane's format
        bool hitOrNot = Physics.Raycast(ray, out hit) && hit.collider.gameObject.tag.Equals("ray_object"); 

		// This simply controls the pitch levels - it does not trigger any functions however.
		if (hit.collider != null) { // if hit.collider is touching anything.
			// Test sphere is the sphere object that 
			testSphere.transform.position = transform.position + hit.distance * transform.forward;

			//print ((hit.collider.transform.position - transform.position).magnitude);
			float distance = Mathf.Clamp (hit.distance, min_distance, max_distance);
			float alpha = (distance - min_distance) / (max_distance - min_distance);
			alpha = 1 - alpha;
			print (alpha);

			float pitch = (1 - alpha) * min_pitch + alpha * max_pitch;
			tone.pitch = pitch;
			print ("Pitch: " + pitch);
		}

        if (hitOrNot && !alreadyHit) { // If mouse hits object
            //print(hit.collider.name);
			tone.clip = (AudioClip) Resources.Load("Jump");
            tone.Play();
			Handheld.Vibrate();
        }

        if (!hitOrNot && alreadyHit) { // After object is hit, and leaves 
            //print("Hit no more");
			tone.clip = (AudioClip) Resources.Load("short-bong");
			tone.Play ();
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

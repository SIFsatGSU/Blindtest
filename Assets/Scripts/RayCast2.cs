
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCast2 : MonoBehaviour {
	public GameObject rayCastingObject;
	public GameObject laserContainer;
    Ray ray;
    RaycastHit hit;

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
		ray = new Ray(rayCastingObject.transform.position, rayCastingObject.transform.forward);
		Debug.DrawRay(ray.origin, ray.direction * 10); // Draws the ray on the "box" hands in the monitor window

        //Testing -- Jack's Implementation of Zane's format
        bool hitOrNot = Physics.Raycast(ray, out hit) && hit.collider.gameObject.tag.Equals("ray_object"); 

		// This simply controls the pitch levels - it does not trigger any functions however.
		if (hit.collider != null) { // if hit.collider is touching anything.
			// Test sphere is the sphere object that 
			testSphere.transform.position = rayCastingObject.transform.position + hit.distance * rayCastingObject.transform.forward;

			// Resize laser.
			float laserContainerScale = laserContainer.transform.parent.transform.lossyScale.z;
			Vector3 laserScale = laserContainer.transform.localScale;
			laserScale.z = hit.distance / laserContainerScale;
			laserContainer.transform.localScale = laserScale;

			//print ((hit.collider.transform.position - transform.position).magnitude);
			float distance = Mathf.Clamp (hit.distance, min_distance, max_distance);
			float alpha = (distance - min_distance) / (max_distance - min_distance);
			alpha = 1 - alpha;

            /*float pitch = Mathf.Lerp(min_pitch, max_pitch, alpha);
			tone.pitch = pitch;
			print ("Pitch: " + pitch);*/
		}

        if (hitOrNot && !alreadyHit) { // If mouse hits object
			GetComponent<AudioController>().PlayIndicator();
			//Handheld.Vibrate();
        }

        if (!hitOrNot && alreadyHit) { // After object is hit, and leaves 
			GetComponent<AudioController>().StopIndicator();
        }

        alreadyHit = hitOrNot; // Always lag behind a frame. 
    }
}

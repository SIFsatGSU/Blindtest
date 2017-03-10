using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCast2 : MonoBehaviour {
    Ray ray;
    RaycastHit hit;

	// Use this for initialization
	void Start () {
        Debug.Log("RayCast2 Loaded Properly.");
	}
	
	// Update is called once per frame
	void Update () {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if(Physics.Raycast(ray, out hit))
        {
            //print(hit.collider.name);
            if (hit.collider.gameObject.tag.Equals("ray_object"))
            {
                
                print(hit.collider.name);
            }
        }
		
	}
}

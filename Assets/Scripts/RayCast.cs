//Helped by Antonio Dominguez via Stranded Soft

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RayCast : MonoBehaviour
{

    GameObject canvas;
    // Use this for initialization
    void Start()
    {
        Debug.Log("I've started the RayCast Script");
        canvas = GameObject.Find("Canvas");
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;

        //Player camera's foward vector
        Vector3 forward = transform.TransformDirection(Vector3.forward);

        if (Physics.Raycast(transform.position, forward, out hit, 90.0F))
        {
            if (hit.collider.gameObject.tag.Equals("ray_object"))
            {
                print(hit.collider.gameObject.name);
            }
        }
    }
}
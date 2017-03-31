using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VR;


public class HandController : MonoBehaviour {
	public VRNode hand;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.localPosition = InputTracking.GetLocalPosition (hand);
		transform.localRotation	= InputTracking.GetLocalRotation (hand);


	}
}

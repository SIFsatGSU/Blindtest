using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour {
	public AudioSource sonarSource;
	public AudioSource indicatorSource;

	private bool buttonDown;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		// Toggle sonar sound when button A is pushed.
		// Since this function executes on each frame, only when the button changes from unpushed to push
		// will the sound to toggled.
		bool currentButtonDown = OVRInput.Get (OVRInput.Button.One);
		if (!buttonDown && currentButtonDown) {
			ToggleSound (sonarSource);
		}
		buttonDown = currentButtonDown;
	}

	public bool ToggleSound(AudioSource source) {
		if (source.isPlaying) {
			source.Stop ();
		} else {
			source.Play ();
		}
		return true;
	}

	public bool PlayIndicator() {
		indicatorSource.Play ();
		return true;
	}

	public bool StopIndicator() {
		indicatorSource.Stop ();
		return true;
	}

	public bool PlaySonar() {
		sonarSource.Play ();
		return true;
	}

	public bool StopSonar() {
		sonarSource.Stop ();
		return true;
	}
}

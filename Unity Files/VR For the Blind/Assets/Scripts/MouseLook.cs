using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour {
    public float xSensitivity;
    public float ySensitivity;
    public float xAngleRange;
    private float xAngle;
    private float yAngle;

    // Use this for initialization
    void Start () {
        xAngle = transform.eulerAngles.x;
        yAngle = transform.eulerAngles.y;
    }

    // Update is called once per frame
    void Update () {
        xAngle -= Input.GetAxisRaw("Mouse Y") * xSensitivity;
        yAngle += Input.GetAxisRaw("Mouse X") * ySensitivity;
        xAngle = Mathf.Clamp(xAngle, -xAngleRange / 2, xAngleRange / 2);
        yAngle = (yAngle % 360 + 360) % 360; // To make it cyclic. It'll always in range of 0 to 360.
        transform.eulerAngles = new Vector3(xAngle, yAngle, 0f);
    }
}

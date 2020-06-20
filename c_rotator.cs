using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class c_rotator : MonoBehaviour {

    public float speed = 1.0f;
    public Vector3 direction =new Vector3(1,0,0);
    // Update is called once per frame
    void Update () {
        transform.Rotate(direction * speed * Time.deltaTime);
	}
}

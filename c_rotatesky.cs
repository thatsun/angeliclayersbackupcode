using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class c_rotatesky : MonoBehaviour {
    public float adjustment = 1.0f;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        RenderSettings.skybox.SetFloat("_Rotation", Time.time * adjustment);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class c_camera_handler : MonoBehaviour {
	[SerializeField]
	Transform[] cameratargets=new Transform[4];
	// Use this for initialization
	[SerializeField]
	Transform cameratransform;
	Vector3 place=Vector3.zero;  
	int current=0;
	[SerializeField]
	float[] timers=new float[4];
	void Start () {
		Invoke("switchcamera",timers[current]);

	}
	
	// Update is called once per frame
	void Update () {
		place = cameratargets [current].position;
		cameratransform.position = place;
		place = cameratargets [current].eulerAngles;
		cameratransform.eulerAngles = place;
	}
	void switchcamera(){
		if (current == 3) {
			current = 0;

		} else {
			current++;
		}

		Invoke ("switchcamera", timers[current]);

	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_autorotate : MonoBehaviour {
	public Controller2D currentplayer;
	// Use this for initialization
	public Transform lazadordepoderes;
	Vector3 helper=Vector3.zero ;
	int last=1;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(currentplayer.collisions.faceDir == last){
			return;
		}
		last = currentplayer.collisions.faceDir;
		if (currentplayer.collisions.faceDir == 1) {
			helper.y = 0f;
			lazadordepoderes.eulerAngles = helper;
		} else {
			helper.y = 180f;
			lazadordepoderes.eulerAngles = helper;
		}
	}
}

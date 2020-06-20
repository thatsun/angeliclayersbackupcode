using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class c_lookatsomething : MonoBehaviour {
	public Transform target1;
	public Transform target2;
	public Transform mytransform;
	Transform target;
	// Use this for initialization
	void Start () {
		


	}
	
	// Update is called once per frame
	void Update () {
		mytransform.LookAt(target);  
	}
	void cahangetarget(){
		target = target1;
	}
	void cahangetarget2(){
		target = target2;
	}
}

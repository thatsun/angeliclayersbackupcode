using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class c_seguir_poloposcicion : MonoBehaviour {
	public Transform avatar;
	public Transform objetoseguido;
	Vector3 place=Vector3.zero;   
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		place = objetoseguido.position;
		avatar.position = place;
	}
}

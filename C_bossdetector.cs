using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_bossdetector : MonoBehaviour {
	int activo=1;
	// Use this for initialization
	public int bossarea=0;
	public boss_nuevo jefe;
	public GameObject bossobject;
	public Collider2D collider;
	void Start(){
		if (game_control.control.catalogo_calabozos [bossarea].bosskilled == 1) {
			bossobject.SetActive (false); 
		} else {
			collider.enabled  = true;
		}
	}
	void OnTriggerEnter2D(Collider2D collider){
		if (collider.tag == "activador" & activo == 1 ) {

			activo = 0;
			jefe.jefedetectado();
		}
	}
	
}

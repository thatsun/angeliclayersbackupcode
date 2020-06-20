using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_key_handler : MonoBehaviour {
	[SerializeField]
	Animator anim;
	int activa=1;
	// Use this for initialization
	void OnTriggerEnter2D(Collider2D collider){
		if(activa==0){
			return;
		}
		if (game_control.control.stopreactions == 1) {
			return;
		}
		if (game_control.control.pausedgame == 1) {
			return;
		}
		if (game_control.control.is_changing_scene == 1) {
			return;
		}
		if (collider.tag == "playerdamage") {
			activa = 0;
			anim.SetTrigger("open");
			this.gameObject.SetActive(false);   
			return;
		}
	}
	

}

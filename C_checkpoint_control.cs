using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_checkpoint_control : MonoBehaviour {
	[SerializeField]
	int checkpoint_number=0;
	int active=0;
	void Start(){
		if(game_control.control.checkpoint_actual<checkpoint_number){
			active = 1;
		}		
	}
	void OnTriggerEnter2D(Collider2D collider){
		if(active==0){
			return;
		}

		if (collider.tag == "playerdamage") {
			if(game_control.control.checkpoint_actual<checkpoint_number){
				active = 0;
				game_control.control.checkpoint_actual =checkpoint_number;  
				
			}
			return;
		}
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_trollstatushandler : MonoBehaviour {
	C_damageplayer statusbridge;

	// Use this for initialization
	void Start () {
		statusbridge = GameObject.Find("damagequad").GetComponent<C_damageplayer>() ;

		InvokeRepeating ("poisonate",90f,90f); 
		InvokeRepeating ("curseara",60f,50f); 
		InvokeRepeating ("frozenate",80f,60f); 
		
	}	
	// Update is called once per frame
	void poisonate () {
		if (game_control.control.stopreactions == 1) {
			return;
		}
		if (game_control.control.pausedgame == 1) {
			return;
		}
		if (game_control.control.is_changing_scene == 1) {
			return;
		}

		if (game_control.control.poisoned == 1) {
			game_control.control.poisoned = 0; 
			statusbridge.poisonedui.enabled = false;  

		} else {
			if(game_control.control.venominmune==1  ){
				return;
			}
			game_control.control.poisoned = 1; 
			statusbridge.poisonedui.enabled = true; 
			Invoke("unpoisonate",5);
		}  
	}
	void unpoisonate(){
		if (game_control.control.poisoned == 1) {
			game_control.control.poisoned = 0; 
			statusbridge.poisonedui.enabled = false;  

		}
	}
	void curseara () {
		if (game_control.control.stopreactions == 1) {
			return;
		}
		if (game_control.control.pausedgame == 1) {
			return;
		}
		if (game_control.control.is_changing_scene == 1) {
			return;
		}

		if (game_control.control.cursed == 0) {
			game_control.control.cursed = 1; 
			statusbridge.cursedui.enabled = true; 

		}
	}
	void frozenate () {
		if (game_control.control.stopreactions == 1) {
			return;
		}
		if (game_control.control.pausedgame == 1) {
			return;
		}
		if (game_control.control.is_changing_scene == 1) {
			return;
		}

		if (game_control.control.frozen == 1) {
			game_control.control.frozen = 0;
			game_control.control.temperature = 100;
			statusbridge.frozenui.fillAmount = game_control.control.temperature * 0.01f;     
			statusbridge.wholeuifrozen.SetActive(false); 
			
		} else {
			game_control.control.frozen = 1; 
			statusbridge.wholeuifrozen.SetActive(true); 
		}

	}
}

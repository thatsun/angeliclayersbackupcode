using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class c_saverpoint : MonoBehaviour {

	public GameObject saveui;
	int uiactiva=0;

	// Use this for initialization
	void OnTriggerStay2D(Collider2D coll){
		if(uiactiva==1 ){
			return;
		}
		if(coll.CompareTag("playerdamage")){
			uiactiva =1;
			saveui.SetActive(true); 

		}
	}void OnTriggerExit2D(Collider2D coll){
		if(uiactiva==0 ){
			return;
		}
		if(coll.CompareTag("playerdamage")){
			uiactiva =0;
			saveui.SetActive(false); 
		}
	}
	public void guardar(){

		if(uiactiva==0 ){
			return;
		}
		if(game_control.control.stopreactions ==1  ){
			return;
		}
		if(game_control.control.pausedgame ==1  ){
			return;
		}

		game_control.control.stopreactions =1;   

		game_control.control.Save_playerdata();
		game_control.control.save_calabozaodata();

		saveui.SetActive(false);
		  
		game_control.control.stopreactions =0; 
	}
}

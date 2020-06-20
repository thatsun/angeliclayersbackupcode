using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_saveroom : MonoBehaviour {
	int activo=1;
	// Use this for initialization
	public string scene="";
	public int puertadestino;
	public int puertadestinofacedir;

	public int currrentdoor=0;

	public bool exitsaveroomdoor=false;
	void OnTriggerStay2D(Collider2D coll){
		if(activo==0){
			return;
		}
		if(coll.CompareTag("playerdamage")){
			activo = 0;
			game_control.control.stopreactions=1;
			if (exitsaveroomdoor == true) {
				
				game_control.control.checkpoint_actual = game_control.control.saveroom_exit  ;
				scene = game_control.control.saveroome_xitscene; 

			} else {
				game_control.control.saveroom_exit = currrentdoor; 
				game_control.control.saveroome_xitscene = Application.loadedLevelName;
				game_control.control.checkpoint_actual = puertadestino;


			}
			game_control.control.puertafacedir  = puertadestinofacedir; 
			game_control.control.change_levelsecure(scene);   
		}
	}
}

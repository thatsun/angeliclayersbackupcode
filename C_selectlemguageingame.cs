using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_selectlemguageingame : MonoBehaviour {
	string nextscene="ge_archivo";
	// Use this for initialization
	int ignoremenu=1;


	void Start () {
		game_control.control.is_changing_scene = 0; 


		ignoremenu = 0;
	}	
	// Update is called once per frame
	public void setlanguage (int option) {
		if(ignoremenu==1){
			return;
		}
		ignoremenu = 1;

		if(option==0){
			game_control.control.idioma = "Eng";   
		}
		else{
			game_control.control.idioma = "Esp";  
		}
		game_control.control.save_idiomasetup (); 
		game_control.control.change_levelsecure(nextscene);
	}
}

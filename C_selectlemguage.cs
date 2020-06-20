using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_selectlemguage : MonoBehaviour {
	public string nextscene= "g_main_menu";
	// Use this for initialization
	int ignoremenu=1;

	public GameObject idiomaui;
	void Start () {
		game_control.control.is_changing_scene = 0; 


		if (game_control.control.languageselected == 1) {
			game_control.control.change_levelsecure(nextscene);
		} else {
			ignoremenu=0;
			idiomaui.SetActive(true);  
		}
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
		game_control.control.languageselected = 1;
		game_control.control.save_idiomasetup (); 
		game_control.control.change_levelsecure(nextscene);
	}
}

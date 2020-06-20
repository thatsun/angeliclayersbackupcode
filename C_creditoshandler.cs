using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class C_creditoshandler : MonoBehaviour {
	public Text butondisplay;
	// Use this for initialization
	public string nestscene="gd_mapa_completo";
	int ignoremenu=1;
	// Update is called once per frame
	void Start(){
		game_control.control.is_changing_scene = 0;   

		if(game_control.control.idioma=="Esp"){
			butondisplay.text = "salir";
		}else{
			butondisplay.text = "exit";
		}

		ignoremenu = 0;
	}
	public void salir () {
		if(ignoremenu==1){
			return;
		}
		ignoremenu = 1;
		game_control.control.change_levelsecure(nestscene);   
		
		
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class c_status_manager : MonoBehaviour {
	public Text nivel_value;
	public Text exp_value;
	public Text next_value;
	public Text skillpoints_value;
	public Text fuerza_value;
	public Text speed_value;
	public Text def_value;

	public Toggle autocuraon;
	public Toggle autopotionon;

	// Use this for initialization
	int ignoremenu=1;
	int helper=0;
	void Start () {
		game_control.control.is_changing_scene = 0;   

		nivel_value.text =""+ game_control.control.base_nivel;  
		exp_value.text =""+ game_control.control.experience; 

		helper = game_control.control.base_nivel * 50;  

		next_value.text =""+ helper;    
		skillpoints_value.text =""+ game_control.control.skillpoints;    


		fuerza_value.text =""+ game_control.control.fuerza;   
		speed_value.text =""+ game_control.control.speed;  
		def_value.text =""+ game_control.control.defensa;  

		if(game_control.control.autocura==1){
			autocuraon.isOn = true;  
		}
		if(game_control.control.autopotion==1){
			autopotionon.isOn = true;  
		}
		ignoremenu = 0;
	}
	
	// Update is called once per frame
	public void upskill (string parametro) {

		if(game_control.control.skillpoints!=0 ){
			game_control.control.skillpoints -= 1;
			skillpoints_value.text =""+ game_control.control.skillpoints; 
			if(parametro=="str"){
				game_control.control.fuerza += 1;  
				fuerza_value.text =""+ game_control.control.fuerza;  
			}
			if(parametro=="speed"){
				game_control.control.speed += 1;  
				speed_value.text =""+ game_control.control.speed; 
			}
			if(parametro=="def"){
				game_control.control.defensa += 1;   
				def_value.text =""+ game_control.control.defensa;  
			}
		}

	}
	public void skillon(string _skill){
		if(_skill=="autocura"){

			if (autocuraon.isOn == true) {
				game_control.control.autocura = 1;

			} else {
				game_control.control.autocura = 0;
			}
		}
		if(_skill=="autopotion"){

			if (autopotionon.isOn == true) {
				game_control.control.autopotion = 1;

			} else {
				game_control.control.autopotion = 0;
			}
		}

	}
	public void salir(string scene) {
		if(ignoremenu==1){
			return;
		}
		ignoremenu = 1;
		game_control.control.save_expdata();
		game_control.control.change_levelsecure(scene); 


	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class c_tacticsmanager : MonoBehaviour {

	[SerializeField]
	Text current_name;


	[SerializeField]
	Text currentdes;
	[SerializeField]
	Image current_icon;

	public itemsdetails[] iteminfos=new itemsdetails[10];

	public itemsdetails[] iteminfosEsp=new itemsdetails[10];

	int seleccionado=0;

	int ignoremenu=0;
	// Use this for initialization

	public Text[] displays=new Text[4];

	public string[] displaysIng=new string[4]; 
	public string[] displaysEsp=new string[4]; 

	void Start () {
		game_control.control.is_changing_scene = 0;  

		if (game_control.control.idioma == "Esp") {
			for(int i=0; i< displays.Length;i++ ){
				displays [i].text = displaysEsp [i];
			}
			current_name.text = iteminfosEsp [seleccionado].nombre;
			currentdes.text = iteminfosEsp [seleccionado].description;
		} else {
			for(int i=0; i< displays.Length;i++ ){
				displays [i].text = displaysIng [i];

			}
			current_name.text = iteminfos [seleccionado].nombre;
			currentdes.text = iteminfos [seleccionado].description;
		}

		current_icon.sprite = iteminfos [seleccionado].icon;



	}
	public void next(){
		if (seleccionado == iteminfos.Length - 1) {
			seleccionado = 0;
		} else {
			seleccionado +=1;
		}

		current_icon.sprite = iteminfos [seleccionado].icon;
		if (game_control.control.idioma == "Esp") {
			
			current_name.text = iteminfosEsp [seleccionado].nombre;
			currentdes.text = iteminfosEsp [seleccionado].description;
		} else {
			
			current_name.text = iteminfos [seleccionado].nombre;
			currentdes.text = iteminfos [seleccionado].description;
		}

	}
	public void prev(){

		if (seleccionado == 0) {
			seleccionado = iteminfos.Length - 1;
		} else {
			seleccionado -=1 ;
		}

		current_icon.sprite = iteminfos [seleccionado].icon;
		if (game_control.control.idioma == "Esp") {

			current_name.text = iteminfosEsp [seleccionado].nombre;
			currentdes.text = iteminfosEsp [seleccionado].description;
		} else {

			current_name.text = iteminfos [seleccionado].nombre;
			currentdes.text = iteminfos [seleccionado].description;
		}


	}
	public void nextscene(string scene) {
		if(ignoremenu==1){
			return;
		}
		ignoremenu = 1; 
		game_control.control.change_levelsecure(scene); 


	}
}

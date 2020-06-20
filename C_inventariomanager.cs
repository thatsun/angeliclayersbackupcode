using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class C_inventariomanager : MonoBehaviour {
	[SerializeField]
	Text current_name;
	[SerializeField]
	Text current_cantidad;

	[SerializeField]
	Text currentdes;
	[SerializeField]
	Image current_icon;

	public itemsdetails[] iteminfos=new itemsdetails[10];

	public itemsdetails[] iteminfosEsp=new itemsdetails[10];

	int seleccionado=0;

	int ignoremenu=0;

	public Sprite defaulticon;

	public Text[] displays=new Text[5];  

	public string[] disesp=new string[5];
	public string[] diseng=new string[5];

	// Use this for initialization
	void Start () {
		game_control.control.is_changing_scene = 0;  

		if (game_control.control.idioma == "Esp") {
			

			for(int i=0; i<displays.Length ;i++ ){

				displays [i].text = disesp [i];
			}

		} else {
			

			for(int i=0; i<displays.Length ;i++ ){

				displays [i].text = diseng [i];
			}

		}


		if (game_control.control.idioma == "Esp") {
			current_name.text = iteminfosEsp [seleccionado].nombre;
			currentdes.text = iteminfosEsp [seleccionado].description;
		} else {
			current_name.text = iteminfos [seleccionado].nombre;
			currentdes.text = iteminfos [seleccionado].description;
		}
		current_icon.sprite = iteminfos [seleccionado].icon;

		current_cantidad.text = game_control.control.catalogo_inventario[seleccionado].inventario.ToString();
		
	}
	public void next(){
		if (seleccionado == game_control.control.catalogo_inventario.Count - 1) {
			seleccionado = 0;
		} else {
			seleccionado +=1;
		}
		if (game_control.control.catalogo_inventario [seleccionado].unlocked == 1) {
			current_icon.sprite = iteminfos [seleccionado].icon;
			if (game_control.control.idioma == "Esp") {
				current_name.text = iteminfosEsp [seleccionado].nombre;
				currentdes.text = iteminfosEsp [seleccionado].description;
			} else {
				current_name.text = iteminfos [seleccionado].nombre;
				currentdes.text = iteminfos [seleccionado].description;
			}
			current_cantidad.text = game_control.control.catalogo_inventario[seleccionado].inventario.ToString();

			
		} else {
			current_icon.sprite = defaulticon;
			if (game_control.control.idioma == "Esp") {
				current_name.text = "vacio";
			} else {
				current_name.text ="empty";
			}


			currentdes.text = "";
			current_cantidad.text = "";

		}

	}
	public void prev(){

		if (seleccionado == 0) {
			seleccionado = game_control.control.catalogo_inventario.Count - 1;
		} else {
			seleccionado -=1 ;
		}

		if (game_control.control.catalogo_inventario [seleccionado].unlocked == 1) {
			current_icon.sprite = iteminfos [seleccionado].icon;
			if (game_control.control.idioma == "Esp") {
				current_name.text = iteminfosEsp [seleccionado].nombre;
				currentdes.text = iteminfosEsp [seleccionado].description;
			} else {
				current_name.text = iteminfos [seleccionado].nombre;
				currentdes.text = iteminfos [seleccionado].description;
			}
			current_cantidad.text = game_control.control.catalogo_inventario[seleccionado].inventario.ToString();


		} else {
			current_icon.sprite = defaulticon;
			if (game_control.control.idioma == "Esp") {
				current_name.text = "vacio";
			} else {
				current_name.text ="empty";
			}
			currentdes.text = "";
			current_cantidad.text = "";

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

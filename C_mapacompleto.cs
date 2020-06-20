using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class C_mapacompleto : MonoBehaviour {

	int ignoremenu=1;
	string infoesp="Desde esta area puedes acceder a todas las opciones del juego";
	string infoing="From this area you can access all the options of the game";
	public Text infotext;

	public string[] botonesesp=new string[8];
	public string[] botonesing=new string[8];

	public Text[] botones=new Text[8];

	public GameObject bossrushbutton;
	public GameObject especialbutton;
	void Start () {
		game_control.control.stopreactions=1; 
		game_control.control.checkpoint_actual = 0;
		game_control.control.vidas = 5;
		game_control.control.health = 100;
		game_control.control.energy = 100;
		game_control.control.dialogo_inicialoido = false;
		game_control.control.dialogo_bossoido = false;
		game_control.control.pausedgame = 0;
		game_control.control.frozen = 0;
		game_control.control.temperature =100;
		game_control.control.poisoned =0;
		game_control.control.cursed =0;
		game_control.control.warping =0;
		game_control.control.venominmune =0;
		game_control.control.is_changing_scene = 0;
		game_control.control.isbossrush = 0;
		game_control.control.bosrushactual = 0;

		
		if(game_control.control.gamecleared ==1  ){
			bossrushbutton.SetActive(true);  
		}
		if(game_control.control.bossrushcelared==1  ){
			especialbutton.SetActive(true); 
			game_control.control.armorunlocked=5;
		}
		ignoremenu=0;

		if (game_control.control.idioma == "Esp") {
			infotext.text = infoesp;

			for(int i=0; i<botones.Length ;i++ ){
				
				botones [i].text = botonesesp [i];
			}

		} else {
			infotext.text = infoing;

			for(int i=0; i<botones.Length ;i++ ){

				botones [i].text = botonesing [i];
			}

		}
	}
	public void salir(string scene) {
		if(ignoremenu==1){
			return;
		}
		ignoremenu = 1; 
		game_control.control.change_levelsecure(scene); 


	}
	IEnumerator ChangeLevel(string scene){
		float fadeTime= GameObject.Find("game control").GetComponent<Fading>().BeginFade(1);
		yield return new WaitForSeconds(fadeTime);
		Application.LoadLevel(scene);

	}
	public void toglelanguage(){
		if(ignoremenu==1){
			return;
		}
		ignoremenu = 1; 
		if (game_control.control.idioma == "Eng") {
			game_control.control.idioma = "Esp";
		} else {
			game_control.control.idioma = "Eng";
		}
		if (game_control.control.idioma == "Esp") {
			infotext.text = infoesp;
		} else {
			infotext.text = infoing;
		}
		game_control.control.save_idiomasetup();
		ignoremenu = 0; 
	}
	public void bossrush(){
		if(ignoremenu==1){
			return;
		}
		ignoremenu = 1; 
		game_control.control.isbossrush = 1;  
		game_control.control.bosrushactual = 0; 
		game_control.control.checkpoint_actual = 2;  
		game_control.control.dialogo_inicialoido = true; 
		game_control.control.dialogo_bossoido = true; 
		game_control.control.change_levelsecure(game_control.control.bossrushscenes.dialogos[game_control.control.bosrushactual]); 
	}
}

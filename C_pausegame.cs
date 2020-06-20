using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_pausegame : MonoBehaviour {
	int ignoremenu=0;
	// Use this for initialization
	public GameObject pauseui;
	public void resume () {
		if(game_control.control.pausedgame ==0   ){
			return;
		}
		if(ignoremenu==1){
			return;
		}
		ignoremenu = 1; 
		pauseui.SetActive(false); 
		game_control.control.pausedgame = 0;

		Time.timeScale = 1; 


	}
	
	// Update is called once per frame
	public void salir (string scene) {
		if(game_control.control.pausedgame ==0   ){
			return;
		}
		if(ignoremenu==1){
			return;
		}
		ignoremenu = 1; 
		game_control.control.change_levelsecure (scene);   
	}
	void Update(){
		if(game_control.control.pausedgame==1){
			if (Input.GetButtonDown ("Pause")) {
				game_control.control.pausedgame = 0;
				Time.timeScale  = 1;
				pauseui.SetActive(false); 
				return;
			} 
			return;
		}
		if (Input.GetButtonDown ("Pause")) {
			game_control.control.pausedgame = 1;
			Time.timeScale  = 0;
			pauseui.SetActive(true); 
			ignoremenu = 0;
		}
	}
	void Start(){
		game_control.control.is_changing_scene = 0;
	}
}

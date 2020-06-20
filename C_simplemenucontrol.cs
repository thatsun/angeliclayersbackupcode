using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_simplemenucontrol : MonoBehaviour {
	int ignoremenu=1;
	// Use this for initialization


	void Start(){
        game_control.control.vidas = 5;
        game_control.control.health = 100;
        game_control.control.energy = 100;
        game_control.control.dialogo_inicialoido = false;
        game_control.control.dialogo_bossoido = false;
        game_control.control.is_changing_scene = 0;
        game_control.control.pausedgame = 0;
        game_control.control.frozen = 0;
        game_control.control.temperature = 100;
        game_control.control.poisoned = 0;
        game_control.control.cursed = 0;
        game_control.control.warping = 0;
        game_control.control.venominmune = 0;
        game_control.control.is_changing_scene = 0;

        if (game_control.control.catalogo_misiones[7].cleared==1)
        {
            game_control.control.gamecleared = 1;
            game_control.control.armorunlocked = 4;

        }
        if (game_control.control.currentarmor == 4)
        {
            game_control.control.catalogo_misiones[7].cleared = 1;
        }
        if (game_control.control.currentarmor==4 & game_control.control.armorunlocked<4)
        {
            game_control.control.armorunlocked = 4;
            game_control.control.gamecleared = 1;
        }
        if (game_control.control.bossrushcelared==1)
        {
            game_control.control.armorunlocked = 5;
            
        }
        game_control.control.save_expdata();
        game_control.control.Save_playerdata();
        ignoremenu = 0;
    }
	public void nextscene(string scene) {
		if(ignoremenu==1){
			return;
		}
		ignoremenu = 1; 

		if (game_control.control.historiainicialoida == 1) {
			game_control.control.change_levelsecure(scene); 
		} else {
			game_control.control.change_levelsecure("historia0"); 
		}



	}
	public void salir () {
		if(ignoremenu==1){
			return;
		}
		ignoremenu = 1; 
		Application.Quit(); 


	}
}

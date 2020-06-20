using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class c_values_reseter : MonoBehaviour {

	// Use this for initialization
	void Start () {
        game_control.control.stopreactions = 1;
        game_control.control.checkpoint_actual = 0;
        game_control.control.vidas = 5;
        game_control.control.health = 100;
        game_control.control.energy = 100;
        game_control.control.dialogo_inicialoido = false;
        game_control.control.dialogo_bossoido = false;
        game_control.control.pausedgame = 0;
        game_control.control.frozen = 0;
        game_control.control.temperature = 100;
        game_control.control.poisoned = 0;
        game_control.control.cursed = 0;
        game_control.control.warping = 0;
        game_control.control.venominmune = 0;
        game_control.control.is_changing_scene = 0;
        game_control.control.isbossrush = 0;
        game_control.control.bosrushactual = 0;
    }
}

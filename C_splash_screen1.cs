using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_splash_screen1 : MonoBehaviour {
	public float delay=5.0f;
	public string nextscene="g_selectlanguaje";
	// Use this for initialization
	void Start () {
		game_control.control.is_changing_scene = 0;  
		Invoke ("changelevel1",delay);
	}

	// Update is called once per frame
	void changelevel1 () {
		game_control.control.change_levelsecure(nextscene);   
	}
}

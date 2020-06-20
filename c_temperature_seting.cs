using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class c_temperature_seting : MonoBehaviour {
	[SerializeField]
	bool temperaturefrozen=false;
	[SerializeField]
	bool cursed=false;
	public UnityEngine.UI.Image cursedui;
	// Use this for initialization
	void Start () {
		if (temperaturefrozen == true) {
			game_control.control.frozen = 1;
		} else {
			game_control.control.frozen = 0;
		}
		cursedui = GameObject.Find ("cursedui").GetComponent<UnityEngine.UI.Image>();
		if (cursed == true) {
			game_control.control.cursed = 1;
			cursedui.enabled = true; 

		} else {
			game_control.control.cursed = 0;
			cursedui.enabled = false; 
		}
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_enginering_manager : MonoBehaviour {
	int ignoremenu=1;
	// Use this for initialization
	void Start () {
		game_control.control.is_changing_scene = 0;
		ignoremenu=0;
	}
	
	// Update is called once per frame
	void Update () {
		
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
}

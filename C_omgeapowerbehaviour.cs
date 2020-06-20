using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_omgeapowerbehaviour : MonoBehaviour {
	public Transform player;
	public float lifetime=5f;
	public float hidedispayat=2f;
	// Use this for initialization
	public C_swordsumoner swordmanager;
	public GameObject efectoblanco;
	public GameObject display;
	void OnEnable(){
		
		Invoke("checkfortargets",2.0f); 
		Invoke("hidedisplay",lifetime); 
		Invoke("disable",hidedispayat); 
		transform.position = new Vector3(player.position.x, player.position.y+4, 0); 
		display.SetActive(true); 
		efectoblanco.SetActive(true); 
	}
	// Update is called once per frame
	void hidedisplay () {
		display.SetActive(false);   
	}
	void disable () {
		efectoblanco.SetActive(false);
		this.gameObject.SetActive(false);   
	}
	void checkfortargets(){
		if (swordmanager.enemy_infos.Count != 0) {
			for (int i = 0; i < swordmanager.enemy_targets.Count; i++) {

				if (swordmanager.enemy_infos [i].activo == 1) {

					swordmanager.enemy_infos [i].damegbyomega ();

				}

			}
		
		} else {
			if (swordmanager.boss_infos.Count != 0) {
				for (int i = 0; i < swordmanager.boss_infos.Count; i++) {

					if (swordmanager.boss_infos [i].activo == 1) {

						swordmanager.boss_infos [i].damegbyomega ();

					}

				}
			}		
		}
	}

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_sword_behaviour : MonoBehaviour {
	public float speed=10f;
	// Use this for initialization
	float step=0;
	Transform target;
	Vector3 target1=Vector3.zero;  
	public C_swordsumoner swordmanager;
	public float lifetime=10;
	public Transform  defaultarget;
	int targetaduqired=0;
	public Animator anim;

	void OnEnable(){
		target = defaultarget; 
		InvokeRepeating("checkfortargets",1.0f,1.0f); 
		Invoke("disblesowrd",lifetime); 
		transform.position = new Vector3(defaultarget.position.x, defaultarget.position.y+4, 0); 
	}
	void Update(){
		if (game_control.control.pausedgame == 1) {
			return;
		}

		if (game_control.control.stopreactions == 1) {
			
			return;
		}
		step = speed * Time.deltaTime;
		target1.x = target.position.x; 
		if (targetaduqired == 1) {
			target1.y = target.position.y; 
		} else {
			target1.y = target.position.y+3.0f; 
		}


		transform.position = Vector3.MoveTowards (transform.position, target1, step);   


	}
	void checkfortargets(){
		if (swordmanager.enemy_infos.Count != 0) {
			for (int i = 0; i < swordmanager.enemy_targets.Count; i++) {
				if (swordmanager.enemy_infos [i] != null) {
					if (swordmanager.enemy_infos [i].activo == 1) {
						target = swordmanager.enemy_targets [i];
						targetaduqired = 1;

						anim.SetTrigger ("hit"); 

						return;
					}
				}


			}
		} else {
			if (swordmanager.boss_infos.Count != 0) {
				for (int i = 0; i < swordmanager.boss_targets.Count; i++) {
					if(swordmanager.boss_infos [i]!=null){
						if (swordmanager.boss_infos [i].activo == 1) {
							target = swordmanager.boss_targets [i];
							targetaduqired = 1;

							anim.SetTrigger ("hit"); 

							return;
						}
					}


				}
			}
		}

		targetaduqired = 0;
		target = defaultarget; 


	}
	void disblesowrd(){
		CancelInvoke("checkfortargets"); 
		this.gameObject.SetActive(false);  
	}
}

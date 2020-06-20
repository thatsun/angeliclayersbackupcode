using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_swordsumoner : MonoBehaviour {
	public GameObject darsword;
	public GameObject holysword;
	public GameObject omegaefect;
	// Use this for initialization
	public int[] costosmp=new int[4]; 

	public List<Transform> enemy_targets;
	public List<C_damagenenmy> enemy_infos;
	public List<boss_nuevo> boss_infos;
	public List<Transform> boss_targets;
	float keydown=0;

	public C_item_manager itemmanager;
	public Animator anim;

	int currentkick=1;

	int k1=Animator.StringToHash("Base Layer.kick1"); 
	int k2=Animator.StringToHash("Base Layer.kick2"); 
	int k3=Animator.StringToHash("Base Layer.kick3"); 
	int hited=Animator.StringToHash("Base Layer.hited");

	AnimatorStateInfo kikinfo;



	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (game_control.control.pausedgame == 1) {
			return;
		}
		if (game_control.control.stopreactions == 1) {
			return;
		}
		keydown = Input.GetAxis ("Vertical");
		if(keydown<= -0.8f){
			if(Input.GetButtonDown("Fire1") ){
				shotanypower();
			}
		}
	}
	void shotanypower () {
		
		if(game_control.control.currentespecial ==0){
			
			kikinfo = anim.GetCurrentAnimatorStateInfo(0);

			if(kikinfo.fullPathHash==k1){
				return;
			}
			if(kikinfo.fullPathHash==k2){
				return;
			}
			if(kikinfo.fullPathHash==k3){
				return;
			}
			if(kikinfo.fullPathHash==hited){
				return;
			}


			if(currentkick==1){
				anim.Play("kick1"); 
				currentkick = 2;
				return;
			}
			if(currentkick==2){
				anim.Play("kick2"); 
				currentkick = 3;
				return;
			}
			if(currentkick==3){
				anim.Play("kick3"); 
				currentkick = 1;
				return;
			}
			return;
		}

		if(game_control.control.currentespecial ==1){
			if(!darsword.activeInHierarchy){
				if(game_control.control.energy >=costosmp[1] ){
					game_control.control.energy -= costosmp [1]; 
					itemmanager.mpbar.fillAmount = game_control.control.energy * 0.01f;  
					darsword.SetActive(true);
				}

			}
			
		}
		if (game_control.control.currentespecial == 2) {
			if(!omegaefect.activeInHierarchy ){
				if(game_control.control.energy >=costosmp[2] ){
					game_control.control.energy -= costosmp [2]; 
					itemmanager.mpbar.fillAmount = game_control.control.energy * 0.01f; 
					omegaefect.SetActive(true);
				}

			}
		}
		if (game_control.control.currentespecial == 3) {
			if(!holysword.activeInHierarchy){
				if(game_control.control.energy >=costosmp[3] ){
					game_control.control.energy -= costosmp [3]; 
					itemmanager.mpbar.fillAmount = game_control.control.energy * 0.01f; 
					holysword.SetActive(true);
				}

			}
		}
	}

}

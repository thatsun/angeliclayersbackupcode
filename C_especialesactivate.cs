using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_especialesactivate : MonoBehaviour {
	public ParticleSystem  flametrower;
	// Use this for initialization
	int allowshot=1;

	WaitForSeconds allowtime=new WaitForSeconds(3.0f); 
	public int currentpower=0;
	void Update(){

		if(Input.GetAxis("Vertical")<-0.5  ){
			if(Input.GetButtonDown("Fire1") ){
				shotanypower();
			}
		}
	}
	void shotanypower () {
		if(allowshot ==0){
			return;
		}
		if(currentpower ==0){
			return;
		}
		allowshot = 0;
		if(currentpower ==1){
			shot_flametrower ();
		}
	}
	
	// Update is called once per frame
	void shot_flametrower() {
		flametrower.Play (); 
		StartCoroutine (allowshotagain());
	}
	IEnumerator  allowshotagain(){
		yield return allowtime;

		allowshot = 1;
	}
}

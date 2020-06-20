using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_flametower_efreet : MonoBehaviour {
	[SerializeField]
	ParticleSystem tower1;
	[SerializeField]
	ParticleSystem tower2;
	[SerializeField]
	ParticleSystem tower3;
	[SerializeField]
	ParticleSystem tower4;

	[SerializeField]
	ParticleSystem firedahsefect;
	// Use this for initialization
	[SerializeField]
	float starttime=10f;
	[SerializeField]
	float interval=15f;
	void Start () {
		InvokeRepeating ("activate_tower",starttime,interval); 

	}
	
	// Update is called once per frame
	public void activate_tower () {
		if (game_control.control.pausedgame == 1) {
			return;
		}
		if (game_control.control.stopreactions == 1) {
			return;
		}
		tower1.Play();
		tower2.Play();
		tower3.Play();
		tower4.Play();

		Invoke("stoptowers",10f); 
	}
	public void stoptowers(){
		tower1.Stop();
		tower2.Stop();
		tower3.Stop();
		tower4.Stop();
	}
	public void firedash () {
		if (game_control.control.pausedgame == 1) {
			return;
		}
		if (game_control.control.stopreactions == 1) {
			return;
		}
		firedahsefect.Play ();
		Invoke("stopdash",5f); 
	}
	public void stopdash(){
		firedahsefect.Stop ();
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_sonidos_player : MonoBehaviour {	
	public AudioSource disparo;
	public AudioSource damagevoice1;
	public AudioSource damagevoice2;
	public AudioSource jumpvoice1;
	public AudioSource jumpvoice2;
	public AudioSource jumpsound;
	public AudioSource stepsound;
	public AudioSource music;
	public AudioSource bossmusic;
	public AudioSource dashsound;
	// Use this for initialization
	int jumpsound_mode=1;
	int damage_mode=1;

	public Controller2D player2dcontrol;
	public PlayerInput playerinputcurrent;
	int enelpiso=0;
	public C_gestor_dialogos dialogosnivel;
	void Start () {
		
	}
	void Update(){
		
		if (player2dcontrol.collisions.below) {
			if(enelpiso==0){
				enelpiso = 1;
                
                stepsound.Play(); 
			}
            playerinputcurrent.allowdash = 1;

        } else {
			if(enelpiso==1){
				enelpiso = 0;
			}

		}
	}
	// Update is called once per frame
	public void play_disparosoubd () {
		disparo.Play(); 
	}
	public void play_damagesound () {
		if (damage_mode == 1) {
			damage_mode = 2; 
			damagevoice1.Play(); 
		} else {
			damage_mode = 1; 
			damagevoice2.Play(); 
		}


	}
	public void play_jumpsound () {
//		if (jumpsound_mode  == 1) {
//			jumpsound_mode = 2; 
//			jumpvoice1.Play(); 
//		} else {
//			jumpsound_mode = 1; 
//			jumpvoice2.Play(); 
//		}

		jumpsound.Play(); 
	}

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_player_shoter : MonoBehaviour {
	public float fire_time;
	public float fire_ratio;
	public Transform SHOTFRONT;
	public Transform SHOTBACK;
	int shot=1; 
	public int shoter=1;
	// Use this for initialization
	public Controller2D player_controler2d;

	public C_sonidos_player sonidos_player_control;

	public Player curentplayer;

	C_player_bullets currentpoler;
    C_player_bullets currentpolerrebotadoras;
    void Update(){
		if (game_control.control.pausedgame == 1) {
			return;
		}
		if(game_control.control.stopreactions==1){
			return;
		}
		if (game_control.control.cursed == 1) {
			return;
		}
        
        if (Input.GetAxis("Vertical")>=0){
			if (Input.GetButtonDown("Fire1")) {
				Fire();
			}
		}
        else
        {
            if (game_control.control.currentespecial != 4)
            {
                return;
            }
            if (Input.GetButtonDown("Fire1"))
            {
                Fire2();
                Fire2();
                Fire2();
                Fire2();
            }

        }

	}
	void Start () {
		curentplayer= GameObject.Find ("Player").GetComponent<Player>(); 
		currentpoler = GameObject.Find ("playerpollsistem").GetComponent<C_player_bullets>();
        currentpolerrebotadoras = GameObject.Find("playerpollsistemrebote").GetComponent<C_player_bullets>();

    }
	void Fire () {
		if (game_control.control.pausedgame == 1) {
			return;
		}
		if (game_control.control.cursed == 1) {
			return;
		}
		
		GameObject obj=currentpoler.GetPooledObjet();
		if (obj==null)return;
		if (curentplayer.wallSliding == true) {
			if (player_controler2d.collisions.faceDir == -1) {
				obj.transform.position = SHOTFRONT.position;
			} else {
				obj.transform.position = SHOTBACK.position;
			}
			
		} else {
			if (player_controler2d.collisions.faceDir == 1) {
				obj.transform.position = SHOTFRONT.position;
			} else {
				obj.transform.position = SHOTBACK.position;
			}
		}

		sonidos_player_control.play_disparosoubd(); 
		obj.SetActive(true);		
	}
    void Fire2()
    {
        if (game_control.control.pausedgame == 1)
        {
            return;
        }
        if (game_control.control.cursed == 1)
        {
            return;
        }

        GameObject obj = currentpolerrebotadoras.GetPooledObjet();
        if (obj == null) return;
        if (curentplayer.wallSliding == true)
        {
            if (player_controler2d.collisions.faceDir == -1)
            {
                obj.transform.position = SHOTFRONT.position;
            }
            else
            {
                obj.transform.position = SHOTBACK.position;
            }

        }
        else
        {
            if (player_controler2d.collisions.faceDir == 1)
            {
                obj.transform.position = SHOTFRONT.position;
            }
            else
            {
                obj.transform.position = SHOTBACK.position;
            }
        }

        sonidos_player_control.play_disparosoubd();
        obj.SetActive(true);
    }
}

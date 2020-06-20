using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_control_animaciones : MonoBehaviour {
	public Animator avatar_anim;
	public Controller2D currentcontroller;
	public Player curentplayer;
	public PlayerInput inputplayer;
	public Transform facingtransfor;
	// Use this for initialization
	Vector3 eulertarget=Vector3.zero ;
    public bool is3dlevel = false;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (game_control.control.pausedgame == 1) {
			return;
		}

		if(! avatar_anim.gameObject.activeInHierarchy  ){
			return;
		}

		if (curentplayer.wallSliding) {
			avatar_anim.SetInteger ("wallslide", 1); 
		} else {
			avatar_anim.SetInteger ("wallslide", 0); 
		}


		if (currentcontroller.collisions.below==true) {
			avatar_anim.SetInteger ("placedonfloor", 1); 
		} else {
			avatar_anim.SetInteger ("placedonfloor", 0); 
		}
		if (game_control.control.stopreactions == 1) {
			avatar_anim.SetInteger ("move", 0);
		} else {
			if (inputplayer.x!=0 ) {
				avatar_anim.SetInteger ("move", 1); 
			} else {
				avatar_anim.SetInteger ("move", 0); 
			}
		}
		if (currentcontroller.collisions.faceDir == 1) {
            if (is3dlevel==true)
            {
                eulertarget.y = 90;
            }
            else
            {
                eulertarget.y = 143;
            }
			
			facingtransfor.eulerAngles = eulertarget;
			avatar_anim.SetInteger ("direction", -1);
		} else {
            if (is3dlevel == true)
            {
                eulertarget.y = 270;
            }
            else
            {
                eulertarget.y = 208;
            }
            
			facingtransfor.eulerAngles = eulertarget;
			avatar_anim.SetInteger ("direction", 1);
		}

	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class c_warp_data : MonoBehaviour {
	public int diretion=1;
	public int warpindex =0;
	// Use this for initialization
	public c_warp_handler warphandler;
	Vector3 pos=Vector3.zero;   
	void OnTriggerStay2D(Collider2D collider){
		if (game_control.control.stopreactions == 1) {
			return;
		}
		if (game_control.control.pausedgame == 1) {
			return;
		}
		if (game_control.control.warping == 1) {
			return;
		}
		if (collider.CompareTag ("playerdamage")) {

			if(warphandler.playercontroller.collisions.faceDir!= diretion){
				game_control.control.warping =1; 
				pos.x = warphandler.warps [warpindex].position.x ; 
				pos.y = warphandler.warps [warpindex].position.y ;

				warphandler.player.position = pos;
				game_control.control.warping =0; 
			}
		}  
	}
}

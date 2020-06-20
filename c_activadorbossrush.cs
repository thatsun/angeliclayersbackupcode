using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class c_activadorbossrush : MonoBehaviour {

    public C_npc_talk npc;
	// Use this for initialization
	void Start () {
        if(game_control.control.gamecleared == 1) {
            npc.gotoescene = true;
        }
	}
	
}

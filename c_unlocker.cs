using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class c_unlocker : MonoBehaviour {
    public C_npc_talk bossrush;
    public C_npc_talk especial;
	// Use this for initialization
	void Start () {
        if (game_control.control.gamecleared == 1)
        {
            bossrush.gotoescene = true;
        }
        if (game_control.control.bossrushcelared == 1)
        {
            especial.gotoescene = true;
        }
    }
	
	
}

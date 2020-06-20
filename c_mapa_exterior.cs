using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class c_mapa_exterior : MonoBehaviour {
    int ignoremenu = 0;
    // Use this for initialization
    public string[] scenes_names = new string[7];
    public int[] puertas_destino = new int[7];
    public int[] facedirs = new int[7];

        
    public void gotoescene(int _index)
    {
        if (game_control.control.pausedgame==1)
        {
            return;
        }
        if (ignoremenu==1)
        {
            return;
        }
        ignoremenu = 1;
        game_control.control.stopreactions = 1;
        game_control.control.checkpoint_actual = puertas_destino[_index];
        game_control.control.puertafacedir = facedirs[_index];
        game_control.control.change_levelsecure(scenes_names[_index]);

    }
}

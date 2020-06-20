using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_singleroom : MonoBehaviour {
    int activo = 1;
    // Use this for initialization
    public string scene = "";
    public int puertadestino;
    public int puertadestinofacedir;
    public int currrentdoor = 0;
    
    void OnTriggerStay2D(Collider2D coll)
    {
        if (activo == 0)
        {
            return;
        }
        if (coll.CompareTag("playerdamage"))
        {
            activo = 0;
            game_control.control.stopreactions = 1;            
            game_control.control.checkpoint_actual = puertadestino;
            game_control.control.puertafacedir = puertadestinofacedir;
            game_control.control.change_levelsecure(scene);
        }
    }
}

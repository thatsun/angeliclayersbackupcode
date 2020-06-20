using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class c_puerta_reiniciadora : MonoBehaviour {
    int activo = 1;
    // Use this for initialization
    public string scene = "";
    public int puertadestino;
    public int puertadestinofacedir;
    void OnTriggerEnter2D(Collider2D coll)
    {
        if (activo == 0)
        {
            return;
        }
        if (coll.CompareTag("playerdamage"))
        {
            activo = 0;
            change();
        }
    }
    void OnTriggerStay2D(Collider2D coll)
    {
        if (activo == 0)
        {
            return;
        }
        if (coll.CompareTag("playerdamage"))
        {
            activo = 0;
            change();
        }
    }
    void change()
    {
        game_control.control.stopreactions = 1;
        game_control.control.checkpoint_actual = puertadestino;
        game_control.control.puertafacedir = puertadestinofacedir;
        game_control.control.change_levelsecure(scene);

        game_control.control.vidas = 5;
        game_control.control.health = 100;
        game_control.control.energy = 100;
        game_control.control.dialogo_inicialoido = false;
        game_control.control.dialogo_bossoido = false;
        game_control.control.pausedgame = 0;
        game_control.control.frozen = 0;
        game_control.control.temperature = 100;
        game_control.control.poisoned = 0;
        game_control.control.cursed = 0;
        game_control.control.warping = 0;
        game_control.control.venominmune = 0;
        
        
    }
}

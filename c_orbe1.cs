using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class c_orbe1 : MonoBehaviour {
    public int orbe_index = 0;
    public int orbe_level = 0;
    int activo = 1;

    public Renderer gameobject_display;
    public GameObject gameobject_efect;
    public GameObject gameobject_dieefect;
    public bool drak_orb = false;
    private void Start()
    {
        if (drak_orb==false)
        {
            if (game_control.control.catalogo_orbes_misiones[orbe_level].catalogo_orbes[orbe_index].collected == true)
            {
                activo = 0;
                gameobject_display.enabled = false;
                gameobject_efect.SetActive(false);

            }
        }
        else
        {
            if (game_control.control.catalogo_orbes_misiones[orbe_level].black_catalogo_orbes[orbe_index].collected == true)
            {
                activo = 0;
                gameobject_display.enabled = false;
                gameobject_efect.SetActive(false);

            }
        }
        
    }
    void offefectdie()
    {
        gameobject_dieefect.SetActive(false);
        gameObject.SetActive(false);
    }
    void OnTriggerEnter2D(Collider2D coll)
    {
        if (game_control.control.pausedgame==1)
        {
            return;
        }
        if (activo == 0)
        {
            return;
        }
        if (coll.CompareTag("playerdamage"))
        {
            activo = 0;
            if (drak_orb == false)
            {
                game_control.control.catalogo_orbes_misiones[orbe_level].catalogo_orbes[orbe_index].collected = true;
            }
            else
            {
                game_control.control.catalogo_orbes_misiones[orbe_level].black_catalogo_orbes[orbe_index].collected = true;
            }
                
            game_control.control.save_orbesdata();
            gameobject_display.enabled = false;
            gameobject_efect.SetActive(false);
            gameobject_dieefect.SetActive(true);
            Invoke("offefectdie", 5.0f);
        }
    }
    void OnTriggerStay2D(Collider2D coll)
    {
        if (game_control.control.pausedgame == 1)
        {
            return;
        }
        if (activo == 0)
        {
            return;
        }
        if (coll.CompareTag("playerdamage"))
        {
            activo = 0;
            if (drak_orb == false)
            {
                game_control.control.catalogo_orbes_misiones[orbe_level].catalogo_orbes[orbe_index].collected = true;
            }
            else
            {
                game_control.control.catalogo_orbes_misiones[orbe_level].black_catalogo_orbes[orbe_index].collected = true;
            }
            game_control.control.save_orbesdata();
            gameobject_display.enabled = false;
            gameobject_efect.SetActive(false);
            gameobject_dieefect.SetActive(true);
            Invoke("offefectdie",5.0f);
        }
    }
}

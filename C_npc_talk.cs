using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_npc_talk : MonoBehaviour {

    public GameObject talkui;

    public bool sleep = false;
    public bool display_on = false;
    public bool dialogo_on =true;
    public bool gotoescene=false;
    public string gotoscene="";
    public int puertadestino = 0;
    public int facedir = 1;

    public int uiactiva = 0;

    public string opcio1_text="";
    public string opcio1_text_eng = "";
    public C_mainmenu_gestor dialogos_npcs;

    public Collider2D thiscollider;

    public int npc_index=0;

    public dialogo npc_dialogo_esp;
    public dialogo npc_dialogo_eng;
    // Use this for initialization
    public bool bossrush=false;

    public int[] dreamsrange=new int[2];
    void OnTriggerStay2D(Collider2D coll)
    {

        if (uiactiva != 0)
        {
            return;
        }
        if (coll.CompareTag("playerdamage"))
        {
            uiactiva = 1;
            talkui.SetActive(true);

        }
    }
    void OnTriggerExit2D(Collider2D coll)
    {
        if (uiactiva == 0)
        {
            return;
        }
        if (coll.CompareTag("playerdamage"))
        {
            uiactiva = 0;
            talkui.SetActive(false);
        }
    }
    public void talkbutton()
    {
        if (uiactiva == 0)
        {
            return;
        }
        if (game_control.control.stopreactions == 1)
        {
            return;
        }
        if (game_control.control.pausedgame == 1)
        {
            return;
        }
        game_control.control.stopreactions = 1;
        uiactiva = 2;
        thiscollider.enabled=false;
        talkui.SetActive(false);
        if (dialogo_on==false)
        {
            game_control.control.checkpoint_actual = puertadestino;
            game_control.control.puertafacedir = facedir;
            game_control.control.change_levelsecure(gotoscene);
            return;
        }
        dialogos_npcs.nextdialogo_startup(npc_index);
    }
    public void opcionbutton1()
    {
        if (bossrush == true)
        {
            go_bossrush();
            return;
        }
        game_control.control.checkpoint_actual = puertadestino;
        game_control.control.puertafacedir = facedir;
        if (sleep==true)
        {
            game_control.control.change_levelsecure(gotoscene+Random.Range(dreamsrange[0], dreamsrange[1]).ToString());
        }
        else
        {
            game_control.control.change_levelsecure(gotoscene);
        }
        
        
    }
    void go_bossrush()
    {
        
        game_control.control.isbossrush = 1;
        game_control.control.bosrushactual = 0;
        game_control.control.checkpoint_actual = 2;
        game_control.control.dialogo_inicialoido = true;
        game_control.control.dialogo_bossoido = true;
        game_control.control.change_levelsecure(game_control.control.bossrushscenes.dialogos[game_control.control.bosrushactual]);
    }
}

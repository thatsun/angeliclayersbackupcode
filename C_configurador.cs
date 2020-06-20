using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_configurador : MonoBehaviour {
	public C_swordsumoner swordmanager;

	public Player playerscript;

	public C_control_animaciones controlanimaciones;

	public C_damageplayer damageplayer;

	public CameraFollow camerafollow;

	public GameObject playerprefab1;
	public GameObject playerprefab2;
	public GameObject playerprefab3;
	public GameObject playerprefab4;
	public GameObject playerprefab5;
	public GameObject playerprefab6;
	public GameObject playerprefab7;
	public GameObject playerprefab8;
	public GameObject playerprefab9;
	public GameObject playerprefab10;
	public GameObject playerprefab11;
	public GameObject playerprefab12;
	public GameObject playerprefab13;
	public GameObject playerprefab14;
	public GameObject playerprefab15;
	public GameObject playerprefab16;
	public GameObject playerprefab17;
	public GameObject playerprefab18;

	public GameObject darkheist;
	public GameObject darheistilum;

	public Transform  parentplayer;
	// Use this for initialization
	[HideInInspector]
	public Animator player_anim;

	public GameObject mainplayerobjetc;
	public GameObject swordmanagerobject;
	public bool selfilum = false;
	int currentbody=0;
	[HideInInspector]
	public GameObject obj;
	public Transform playertarget;
	public C_damagenenmy bossdamageneney;
    public int finalboss = 0;
	void Start () {
        if (finalboss==1)
        {
            game_control.control.currentarmor = 4;
            game_control.control.autocura = 1;
            game_control.control.autopotion = 1;
            obj = GameObject.Instantiate(playerprefab1, parentplayer);
            player_anim = obj.GetComponent<Animator>();
            damageplayer.avatar_body = obj;
        }
        else
        {
            if (game_control.control.currentmodel == 0)
            {
                if (game_control.control.darkheist == 1)
                {
                    if (selfilum == false)
                    {
                        obj = GameObject.Instantiate(darkheist, parentplayer);
                        player_anim = obj.GetComponent<Animator>();
                        damageplayer.avatar_body = obj;
                    }
                    else
                    {
                        obj = GameObject.Instantiate(darheistilum, parentplayer);
                        player_anim = obj.GetComponent<Animator>();
                        damageplayer.avatar_body = obj;
                    }
                }
                else
                {
                    if (selfilum == false)
                    {
                        obj = GameObject.Instantiate(playerprefab1, parentplayer);
                        player_anim = obj.GetComponent<Animator>();
                        damageplayer.avatar_body = obj;
                    }
                    else
                    {
                        obj = GameObject.Instantiate(playerprefab2, parentplayer);
                        player_anim = obj.GetComponent<Animator>();
                        damageplayer.avatar_body = obj;
                    }
                }
            }
            if (game_control.control.currentmodel == 1)
            {
                if (selfilum == false)
                {
                    obj = GameObject.Instantiate(playerprefab3, parentplayer);
                    player_anim = obj.GetComponent<Animator>();
                    damageplayer.avatar_body = obj;
                }
                else
                {
                    obj = GameObject.Instantiate(playerprefab4, parentplayer);
                    player_anim = obj.GetComponent<Animator>();
                    damageplayer.avatar_body = obj;
                }
            }
            if (game_control.control.currentmodel == 2)
            {
                if (selfilum == false)
                {
                    obj = GameObject.Instantiate(playerprefab5, parentplayer);
                    player_anim = obj.GetComponent<Animator>();
                    damageplayer.avatar_body = obj;
                }
                else
                {
                    obj = GameObject.Instantiate(playerprefab6, parentplayer);
                    player_anim = obj.GetComponent<Animator>();
                    damageplayer.avatar_body = obj;
                }
            }
            if (game_control.control.currentmodel == 3)
            {
                if (selfilum == false)
                {
                    obj = GameObject.Instantiate(playerprefab7, parentplayer);
                    player_anim = obj.GetComponent<Animator>();
                    damageplayer.avatar_body = obj;
                }
                else
                {
                    obj = GameObject.Instantiate(playerprefab8, parentplayer);
                    player_anim = obj.GetComponent<Animator>();
                    damageplayer.avatar_body = obj;
                }
            }
            if (game_control.control.currentmodel == 4)
            {
                if (selfilum == false)
                {
                    obj = GameObject.Instantiate(playerprefab9, parentplayer);
                    player_anim = obj.GetComponent<Animator>();
                    damageplayer.avatar_body = obj;
                }
                else
                {
                    obj = GameObject.Instantiate(playerprefab10, parentplayer);
                    player_anim = obj.GetComponent<Animator>();
                    damageplayer.avatar_body = obj;
                }
            }
            if (game_control.control.currentmodel == 5)
            {
                if (selfilum == false)
                {
                    obj = GameObject.Instantiate(playerprefab11, parentplayer);
                    player_anim = obj.GetComponent<Animator>();
                    damageplayer.avatar_body = obj;
                }
                else
                {
                    obj = GameObject.Instantiate(playerprefab12, parentplayer);
                    player_anim = obj.GetComponent<Animator>();
                    damageplayer.avatar_body = obj;
                }
            }
            if (game_control.control.currentmodel == 6)
            {
                if (selfilum == false)
                {
                    obj = GameObject.Instantiate(playerprefab13, parentplayer);
                    player_anim = obj.GetComponent<Animator>();
                    damageplayer.avatar_body = obj;
                }
                else
                {
                    obj = GameObject.Instantiate(playerprefab14, parentplayer);
                    player_anim = obj.GetComponent<Animator>();
                    damageplayer.avatar_body = obj;
                }
            }
            if (game_control.control.currentmodel == 7)
            {
                if (selfilum == false)
                {
                    obj = GameObject.Instantiate(playerprefab15, parentplayer);
                    player_anim = obj.GetComponent<Animator>();
                    damageplayer.avatar_body = obj;
                }
                else
                {
                    obj = GameObject.Instantiate(playerprefab16, parentplayer);
                    player_anim = obj.GetComponent<Animator>();
                    damageplayer.avatar_body = obj;
                }
            }
            if (game_control.control.currentmodel == 8)
            {
                if (selfilum == false)
                {
                    obj = GameObject.Instantiate(playerprefab17, parentplayer);
                    player_anim = obj.GetComponent<Animator>();
                    damageplayer.avatar_body = obj;
                }
                else
                {
                    obj = GameObject.Instantiate(playerprefab18, parentplayer);
                    player_anim = obj.GetComponent<Animator>();
                    damageplayer.avatar_body = obj;
                }
            }
        }
		



		swordmanager.anim = player_anim;
		playerscript.anim = player_anim;
		controlanimaciones.avatar_anim = player_anim;
		damageplayer.player_anim = player_anim;
		if(bossdamageneney!=null){
			bossdamageneney.sonidocontrol = mainplayerobjetc.GetComponent<C_sonidos_player> ();
		}



		mainplayerobjetc.SetActive(true); 
		swordmanagerobject.SetActive(true); 
		camerafollow.enabled=true;   
	}
	
	// Update is called once per frame

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class c_cleardatamanager : MonoBehaviour {
    int ignoremenu = 1;
    // Use this for initialization
    public Image[] levels= new Image[8];
    public Image[] armors = new Image[6];
    public Image[] sword = new Image[3];
    public Image[] extras = new Image[3];
    public Image[] enhancements = new Image[3];
    public Image[] art = new Image[8];
    public Image[] figurines = new Image[8];
    public Image[] skins = new Image[8];


    public Color[] levels_c = new Color[8];
    public Color[] armors_c = new Color[6];
    public Color[] sword_c = new Color[3];
    public Color[] extras_c = new Color[3];
    public Color[] enhancements_c = new Color[3];
    public Color[] art_c = new Color[8];
    public Color[] figurines_c = new Color[8];
    public Color[] skins_c = new Color[8];

    public Sprite orbe1;

    void Start () {
        game_control.control.is_changing_scene = 0;


        for(int i=0; i< levels.Length; i++)
        {
            if (game_control.control.catalogo_misiones[i].cleared==1)
            {
                levels[i].sprite = orbe1;
                art[i].sprite = orbe1;
                figurines[i].sprite = orbe1;
                skins[i].sprite = orbe1;

                levels[i].color = levels_c[i];
                art[i].color = art_c[i];
                figurines[i].color = figurines_c[i];
                skins[i].color = skins_c[i];
            }
        }
        if (game_control.control.espunlocked>0)
        {
            sword[0].sprite = orbe1;
            sword[0].color = sword_c[0];
        }
        if (game_control.control.espunlocked > 1)
        {
            sword[1].sprite = orbe1;
            sword[1].color = sword_c[1];
        }
        if (game_control.control.espunlocked > 2)
        {
            sword[2].sprite = orbe1;
            sword[2].color = sword_c[2];
        }

        if (game_control.control.gamecleared == 1)
        {
            extras[0].sprite = orbe1;
            extras[0].color = extras_c[0];
        }
        if (game_control.control.bossrushcelared == 1)
        {
            extras[1].sprite = orbe1;
            extras[1].color = extras_c[1];

            enhancements[0].sprite = orbe1;
            enhancements[1].sprite = orbe1;
            enhancements[2].sprite = orbe1;

            enhancements[0].color = enhancements_c[0];
            enhancements[1].color = enhancements_c[1];
            enhancements[2].color = enhancements_c[2];
        }
        //if (game_control.control.enhancementarea == 1)
        //{
        //    extras[2].sprite = orbe1;
        //}
        armors[0].sprite = orbe1;
        armors[0].color = armors_c[0];

        if (game_control.control.armorunlocked > 0)
        {
            armors[1].sprite = orbe1;
            armors[1].color = armors_c[1];
        }
        if (game_control.control.armorunlocked > 1)
        {
            armors[2].sprite = orbe1;
            armors[2].color = armors_c[2];
        }
        if (game_control.control.armorunlocked > 2)
        {
            armors[3].sprite = orbe1;
            armors[3].color = armors_c[3];
        }
        if (game_control.control.armorunlocked > 3)
        {
            armors[4].sprite = orbe1;
            armors[4].color = armors_c[4];
        }
        if (game_control.control.armorunlocked > 4)
        {
            armors[5].sprite = orbe1;
            armors[5].color = armors_c[5];
        }







        ignoremenu = 0;
    }

    // Update is called once per frame
    public void salir(string scene)
    {
        if (ignoremenu == 1)
        {
            return;
        }
        ignoremenu = 1;
        game_control.control.save_expdata();
        game_control.control.change_levelsecure(scene);


    }
}

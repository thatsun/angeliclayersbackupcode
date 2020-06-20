using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class C_filemanager : MonoBehaviour {
    public string[] filenames = new string[4];
    // Use this for initialization
    int currentfileselected=0;
    public Dropdown option;
    public Button clearbutton;
    public Button loadbutton;
    public Toggle allowclearbutton;

    public GameObject clearingdisplay;

    int ignoremenu=0;
    void Start () {
        game_control.control.is_changing_scene = 0;
	}
    public void salir(string scene)
    {
        if (ignoremenu == 1)
        {
            return;
        }
        ignoremenu = 1;
        game_control.control.change_levelsecure(scene);


    }
    // Update is called once per frame
    public void selectfile()
    {
        
        currentfileselected = option.value;
    }
    public void loadfile()
    {
        if (ignoremenu == 1)
        {
            return;
        }
        ignoremenu = 1;
        option.interactable = false;
        loadbutton.interactable = false;
        if (clearbutton != null) {
            clearbutton.interactable = false;
        }
        if (allowclearbutton != null)
        {
            allowclearbutton.interactable = false;
        }


        loadop();
        
        game_control.control.change_levelsecure("g_splashscreen");
    }
    void loadop()
    {
        game_control.control.checkpoint_actual = 0;
        game_control.control.currentarmor = 0;
        game_control.control.currentespecial = 0;
        game_control.control.armorunlocked = 0;
        game_control.control.espunlocked = 0;
        game_control.control.bossrushcelared = 0;
        game_control.control.gamecleared = 0;

        game_control.control.base_nivel = 1;
        game_control.control.experience = 0;
        game_control.control.skillpoints = 0;
        game_control.control.fuerza = 1;
        game_control.control.speed = 1;
        game_control.control.defensa = 1;
        game_control.control.autocura = 0;
        game_control.control.autopotion = 0;
        game_control.control.historiainicialoida = 0;
        game_control.control.languageselected = 0;

        game_control.control.reset_dictionary_data();

        game_control.control.savefile = filenames[currentfileselected];
        game_control.control.Load_playerdata();
        game_control.control.load_expdata();
        game_control.control.load_Espsetup();
        game_control.control.load_idiomasetup();
    }
    public void clearfile()
    {
        if (ignoremenu == 1)
        {
            return;
        }
        ignoremenu = 1;
        allowclearbutton.isOn = false;
        clearingdisplay.SetActive(false);
        bool _clearing=  game_control.control.clearfile(filenames[currentfileselected]);
        if (_clearing==true)
        {
            if (game_control.control.savefile== filenames[currentfileselected])
            {
                loadop();
            }
            
            clearingdisplay.SetActive(true);
            StartCoroutine(shomessageclear());
        }
    }
    IEnumerator shomessageclear()
    {
        yield return new WaitForSeconds(3.0f);
        clearingdisplay.SetActive(false);
        ignoremenu = 0;
    }
    public void enableclear()
    {
        if (allowclearbutton.isOn == true)
        {
            clearbutton.interactable = true;
        }
        else
        {
            clearbutton.interactable = false;
        }

    }
}

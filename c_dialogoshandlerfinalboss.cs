using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class c_dialogoshandlerfinalboss : MonoBehaviour {

    [SerializeField]
    GameObject dialogosui;
    [SerializeField]
    GameObject engelname;
    [SerializeField]
    GameObject othername;

    [SerializeField]
    UnityEngine.UI.Image othersprite;

    [SerializeField]
    Text othernametext;
    [SerializeField]
    Text dialogotext;

    int ignoremenu = 1;
    // Use this for initialization
    public dialogo dialogoinicial;
    public dialogo dialogoinicialIng;
    int dialogoactual = 0;

    [SerializeField]
    string nextscene = "";

    [SerializeField]
    UnityEngine.UI.Image fondosprite;



    void Start()
    {

        
        game_control.control.catalogo_misiones[7].cleared = 1;
        game_control.control.catalogo_misiones[8].cleared = 1;
        if (game_control.control.armorunlocked == 3)
        {
            game_control.control.armorunlocked = 4;
        }
        if (game_control.control.espunlocked == 2)
        {
            game_control.control.espunlocked = 3;
        }
        game_control.control.gamecleared = 1;
        


        game_control.control.save_Espsetup();

        game_control.control.Save_playerdata();
        game_control.control.is_changing_scene = 0;
        iniciardialogo();
    }
    void iniciardialogo()
    {

        dialogoactual = 0;

        if (game_control.control.idioma == "Esp")
        {
            othersprite.sprite = dialogoinicial.actualother;
            othernametext.text = dialogoinicial.other_char_name;
        }
        else
        {
            othersprite.sprite = dialogoinicialIng.actualother;
            othernametext.text = dialogoinicialIng.other_char_name;
        }

        dialogosui.SetActive(true);
        nextdialogo_startup();
    }
    void nextdialogo_startup()
    {
        if (game_control.control.idioma == "Esp")
        {
            dialogotext.text = dialogoinicial.dialogos[dialogoactual];
        }
        else
        {
            dialogotext.text = dialogoinicialIng.dialogos[dialogoactual];
        }


        if (dialogoinicial.isengel[dialogoactual] == true)
        {
            engelname.SetActive(true);
            othername.SetActive(false);
        }
        else
        {
            engelname.SetActive(false);
            othername.SetActive(true);


        }
        dialogoactual++;
        ignoremenu = 0;
    }
    public void nextdialogo()
    {
        if (ignoremenu == 1)
        {
            return;
        }
        ignoremenu = 1;
        if (dialogoactual == dialogoinicial.dialogos.Length)
        {
            dialogosui.SetActive(false);
            game_control.control.stopreactions = 1;
            game_control.control.checkpoint_actual = 0;
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
            game_control.control.is_changing_scene = 0;


            game_control.control.change_levelsecure(nextscene);
            return;
        }
        if (game_control.control.idioma == "Esp")
        {
            dialogotext.text = dialogoinicial.dialogos[dialogoactual];
        }
        else
        {
            dialogotext.text = dialogoinicialIng.dialogos[dialogoactual];
        }


        if (dialogoinicial.isengel[dialogoactual] == true)
        {
            engelname.SetActive(true);
            othername.SetActive(false);


        }
        else
        {
            engelname.SetActive(false);
            othername.SetActive(true);


        }
        dialogoactual++;
        ignoremenu = 0;
    }
}

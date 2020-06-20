using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class C_mainmenu_gestor : MonoBehaviour {
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
    

    public C_npc_talk[] npc_talk=new C_npc_talk[3];
    


    int dialogoactual = 0;

    int index_npc = 0;

    public GameObject nextbutton_ui;

    public GameObject avatar_displayUI;
    public GameObject optionsUI;
    public Text opcion1_text;
    public Text opcion2_text;

    public void nextdialogo_startup(int _index)
    {
        if (ignoremenu == 1)
        {
            return;
        }
        ignoremenu = 1;
        dialogoactual = 0;
        index_npc = _index;
        if (game_control.control.idioma == "Esp")
        {
            dialogotext.text = npc_talk[index_npc].npc_dialogo_esp.dialogos[dialogoactual];
        }
        else
        {
            dialogotext.text = npc_talk[index_npc].npc_dialogo_eng.dialogos[dialogoactual];
        }

        othernametext.text = npc_talk[index_npc].npc_dialogo_eng.other_char_name;
        if (npc_talk[index_npc].display_on==true)
        {
            avatar_displayUI.SetActive(true);
        }
        else
        {
            avatar_displayUI.SetActive(false);
        }

        if (npc_talk[index_npc].npc_dialogo_esp.isengel[dialogoactual] == true)
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
        nextbutton_ui.SetActive(true);
        optionsUI.SetActive(false);
        dialogosui.SetActive(true);
    }
    public void nextdialogo_button()
    {
        if (ignoremenu == 1)
        {
            return;
        }
        ignoremenu = 1;
        if (dialogoactual== npc_talk[index_npc].npc_dialogo_esp.dialogos.Length)
        {
            nextbutton_ui.SetActive(false);
            if (npc_talk[index_npc].gotoescene==true)
            {
                dialogotext.text = "";
                if (game_control.control.idioma == "Eng" )
                {
                    opcion1_text.text = npc_talk[index_npc].opcio1_text_eng;
                    opcion2_text.text = "i am fine thanks";
                }
                else
                {
                    opcion1_text.text = npc_talk[index_npc].opcio1_text;
                    opcion2_text.text = "Tal vez despues, gracias";
                }
                
                optionsUI.SetActive(true);
                ignoremenu = 0;
                return;
            }

            dialogosui.SetActive(false);
            npc_talk[index_npc].uiactiva = 0;
            npc_talk[index_npc].thiscollider.enabled = true;
            game_control.control.stopreactions = 0;
            ignoremenu = 0;
            return;
        }

        if (game_control.control.idioma == "Esp")
        {
            dialogotext.text = npc_talk[index_npc].npc_dialogo_esp.dialogos[dialogoactual];
        }
        else
        {
            dialogotext.text = npc_talk[index_npc].npc_dialogo_eng.dialogos[dialogoactual];
        }


        if (npc_talk[index_npc].npc_dialogo_esp.isengel[dialogoactual] == true)
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
    void Start()
    {

        game_control.control.stopreactions = 0;

        for(int i=0; i<npc_talk.Length; i++)
        {
            npc_talk[i].npc_index = i;
        }

        ignoremenu = 0;
        
    }
    public void opcion1button()
    {
        if (ignoremenu == 1)
        {
            return;
        }
        ignoremenu = 1;
        npc_talk[index_npc].opcionbutton1();
    }
    public void opcion2button()
    {
        if (ignoremenu == 1)
        {
            return;
        }
        ignoremenu = 1;
        dialogosui.SetActive(false);
        npc_talk[index_npc].uiactiva = 0;
        npc_talk[index_npc].thiscollider.enabled = true;
        game_control.control.stopreactions = 0;
        ignoremenu = 0;
    }
}

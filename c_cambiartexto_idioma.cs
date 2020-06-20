using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class c_cambiartexto_idioma : MonoBehaviour {
    
    Text textoUI;
    [SerializeField]
    string text_esp="";
    [SerializeField]
    string text_ing="";

	// Use this for initialization
	void Start () {
        textoUI = gameObject.GetComponent<Text>();
        if (game_control.control.idioma == "Eng")
        {
            textoUI.text = text_ing;
        }
        else
        {
            textoUI.text = text_esp;
        }
	}
	
	
}

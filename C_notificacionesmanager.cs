using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class C_notificacionesmanager : MonoBehaviour {
	public GameObject  notui;
	public GameObject  notbox;
	// Use this for initialization
	public string[] titulos=new string[9]; 

	public string[] titulosIng=new string[9]; 

	public string[] descripciones=new string[9]; 

	public string[] descripcionesIng=new string[9]; 

	public Sprite[] icons=new Sprite[9]; 

	public Text titulo;
	public Text des;
	public Image icon;

	int currentnotificaction=0;

	int ignoremenu=1;

    public EventSystem eventSystem;
    public GameObject okbutton;
    public GameObject mision1button;

	void Start () {
		if (game_control.control.notificaciones.Count == 0) {
			notui.SetActive(false);
            eventSystem.SetSelectedGameObject(mision1button, new BaseEventData(eventSystem));
        } else {
			if (game_control.control.idioma == "Esp") {
				titulo.text=titulos[currentnotificaction];
				des.text=descripciones[currentnotificaction];
			} else {
				titulo.text=titulosIng[currentnotificaction];
				des.text=descripcionesIng[currentnotificaction];
			}

			icon.sprite=icons[currentnotificaction];

			currentnotificaction++;
			notbox.SetActive(true);
            eventSystem.SetSelectedGameObject(okbutton, new BaseEventData(eventSystem));

            ignoremenu = 0;

		}
	}
	public void nextnot(){
		if(ignoremenu == 1){
			return;
		}
		ignoremenu = 1;
		notbox.SetActive(false); 
		if (currentnotificaction < game_control.control.notificaciones.Count) {
			if (game_control.control.idioma == "Esp") {
				titulo.text=titulos[currentnotificaction];
				des.text=descripciones[currentnotificaction];
			} else {
				titulo.text=titulosIng[currentnotificaction];
				des.text=descripcionesIng[currentnotificaction];
			}
			icon.sprite = icons [currentnotificaction];
			currentnotificaction++;
			notbox.SetActive (true);
            eventSystem.SetSelectedGameObject(okbutton, new BaseEventData(eventSystem));
            ignoremenu = 0;
		} else {
			notui.SetActive(false);
            eventSystem.SetSelectedGameObject(mision1button, new BaseEventData(eventSystem));
            clearall();
		}




	}
	
	// Update is called once per frame
	void clearall () {
		game_control.control.notificaciones.Clear();
	}
}

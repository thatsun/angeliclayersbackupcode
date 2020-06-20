using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class C_gestor_dialogos : MonoBehaviour {
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

	int ignoremenu=1;
	// Use this for initialization
	public dialogo dialogoinicial;
	public dialogo dialogoboss;

	public dialogo dialogoinicialIng;
	public dialogo dialogobossIng;
	public C_damagenenmy bossreference;
	public boss_nuevo bossreference2;

	int dialogoactual=0;

	string mododialogos="inicial";

	void Start () {
		iniciardialogo ();
		
	}
	void iniciardialogo(){
		if(game_control.control.dialogo_inicialoido==true){
			mododialogos ="boss";
			game_control.control.stopreactions = 0;
			return;
		}
		dialogoactual = 0;
		if (game_control.control.idioma == "Esp") {
			othersprite.sprite = dialogoinicial.actualother;   
			othernametext.text = dialogoinicial.other_char_name;  
		} else {
			othersprite.sprite = dialogoinicialIng.actualother;   
			othernametext.text = dialogoinicialIng.other_char_name;  
		}


		dialogosui.SetActive(true);
		nextdialogo_startup();
	}
	void nextdialogo_startup(){
		
		if (mododialogos == "inicial") {
			if (game_control.control.idioma == "Esp") {
				dialogotext.text = dialogoinicial.dialogos [dialogoactual]; 
			} else {
				dialogotext.text = dialogoinicialIng.dialogos [dialogoactual]; 
			}


			if (dialogoinicial.isengel [dialogoactual] == true) {
				engelname.SetActive (true);
				othername.SetActive (false);


			} else {
				engelname.SetActive (false);
				othername.SetActive (true);


			}


		} else {
			if (game_control.control.idioma == "Esp") {
				dialogotext.text = dialogoboss.dialogos [dialogoactual]; 
			} else {
				dialogotext.text = dialogobossIng.dialogos [dialogoactual]; 
			}

			if (dialogoboss.isengel [dialogoactual] == true) {
				engelname.SetActive (true);
				othername.SetActive (false);


			} else {
				engelname.SetActive (false);
				othername.SetActive (true);


			}
		}
		dialogoactual++;
		ignoremenu = 0;
	}
	public void nextdialogo(){
		if (ignoremenu == 1) {
			return;
		}
		ignoremenu = 1;
		if(dialogoactual==10){
			dialogosui.SetActive(false); 
			if(mododialogos == "inicial"){
				mododialogos = "boss";
				game_control.control.dialogo_inicialoido   = true;


			}
			else{
				game_control.control.dialogo_bossoido  = true;
				if(bossreference!=null){
					bossreference.activarboss();
				}
				else{
					bossreference2.activarboss();  
				}
				 
			}
			game_control.control.stopreactions = 0;
			return;
		}
		if (mododialogos == "inicial") {
			if (game_control.control.idioma == "Esp") {
				dialogotext.text= dialogoinicial.dialogos[dialogoactual]; 

			} else {
				dialogotext.text= dialogoinicialIng.dialogos[dialogoactual]; 

			}

			if (dialogoinicial.isengel [dialogoactual] == true) {
				engelname.SetActive (true);
				othername.SetActive (false);


			} else {
				engelname.SetActive (false);
				othername.SetActive (true);


			}

			
		} else {
			if (game_control.control.idioma == "Esp") {
				dialogotext.text= dialogoboss.dialogos[dialogoactual]; 
			} else {
				dialogotext.text= dialogobossIng.dialogos[dialogoactual]; 
			}

			if (dialogoboss.isengel [dialogoactual] == true) {
				engelname.SetActive (true);
				othername.SetActive (false);


			} else {
				engelname.SetActive (false);
				othername.SetActive (true);


			}
		}
		dialogoactual++;
		ignoremenu = 0;
	}
	public void bossdialogostart(){
		if(game_control.control.dialogo_bossoido ==true){
			if(bossreference!=null){
				bossreference.activarboss();
			}
			else{
				bossreference2.activarboss();  
			}
			return;
		}
		game_control.control.stopreactions = 1;
		dialogoactual = 0;
		othersprite.sprite = dialogoboss.actualother;   
		othernametext.text = dialogoboss.other_char_name;  
		dialogosui.SetActive(true);
		nextdialogo_startup();
	}
}

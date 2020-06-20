using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class C_dialogos_historia0 : MonoBehaviour {



	[SerializeField] 
	Text dialogotext;

	int ignoremenu=1;
	// Use this for initialization
	public historia_sc dialogoinicial;
	public historia_sc dialogoinicialIng;
	int dialogoactual=0;

	[SerializeField] 
	string nextscene="";

	public GameObject[] diapositivas=new GameObject[20]; 

	void Start () {

		game_control.control.is_changing_scene = 0;   
		iniciardialogo ();
	}
	void iniciardialogo(){

		dialogoactual = 0;

		nextdialogo_startup();
	}
	void nextdialogo_startup(){
		if (game_control.control.idioma == "Esp") {
			dialogotext.text = dialogoinicial.dialogos [dialogoactual]; 

		} else {
			dialogotext.text = dialogoinicialIng.dialogos [dialogoactual]; 

		}
		diapositivas [dialogoactual].SetActive(true); 

		dialogoactual++;
		ignoremenu = 0;
	}
	public void nextdialogo(){
		if (ignoremenu == 1) {
			return;
		}
		ignoremenu = 1;
		if(dialogoactual==dialogoinicial.dialogos.Length){
			
			nextscene_mision ();   
			return;
		}
		if (game_control.control.idioma == "Esp") {
			dialogotext.text = dialogoinicial.dialogos [dialogoactual]; 

		} else {
			dialogotext.text = dialogoinicialIng.dialogos [dialogoactual]; 

		}
		diapositivas [dialogoactual].SetActive(true); 
		dialogoactual++;
		ignoremenu = 0;
	}
	public void nextscene_mision() {


		game_control.control.change_levelsecure(nextscene); 


	}
}

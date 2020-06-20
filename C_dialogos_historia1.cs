using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class C_dialogos_historia1 : MonoBehaviour {
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
	public dialogo dialogoinicialIng;
	int dialogoactual=0;

	[SerializeField] 
	string nextscene="";

	[SerializeField] 
	UnityEngine.UI.Image fondosprite;

    public int finalbossfase = 0;


	void Start () {

		game_control.control.is_changing_scene = 0;   
		iniciardialogo ();
	}
	void iniciardialogo(){

		dialogoactual = 0;

		if(game_control.control.idioma=="Esp"){
			othersprite.sprite = dialogoinicial.actualother;   
			othernametext.text = dialogoinicial.other_char_name;  
		}else{
			othersprite.sprite = dialogoinicialIng.actualother;   
			othernametext.text = dialogoinicialIng.other_char_name;  
		}

		dialogosui.SetActive(true);
		nextdialogo_startup();
	}
	void nextdialogo_startup(){
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
		dialogoactual++;
		ignoremenu = 0;
	}
	public void nextdialogo(){
		if (ignoremenu == 1) {
			return;
		}
		ignoremenu = 1;
		if(dialogoactual==dialogoinicial.dialogos.Length){
			dialogosui.SetActive(false);
            if (finalbossfase==1)
            {
                finalboss_nextscene_mision();
                return;
            }
			nextscene_mision ();   
			return;
		}
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
		dialogoactual++;
		ignoremenu = 0;
	}
	public void nextscene_mision() {
		
		game_control.control.historiainicialoida = 1;
		game_control.control.Save_playerdata();  
		game_control.control.nivel_actual = 0;   
		game_control.control.cinematico1  = "bossdefeat1";
		game_control.control.cinematico2  = "boss1end";
		game_control.control.change_levelsecure("ge_nivel1"); 


	}
    public void finalboss_nextscene_mision()
    {

        
        game_control.control.nivel_actual = 8;
        game_control.control.cinematico1 = "finalbossdefeatfase2";
        game_control.control.cinematico2 = "boss_end_09";
        game_control.control.change_levelsecure(nextscene);


    }
}

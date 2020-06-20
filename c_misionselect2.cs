using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class c_misionselect2 : MonoBehaviour {
	// Use this for initialization
	int ignoremenu=1;
	public string[] misiones=new string[8]; 
	public string[] cinematico1=new string[8];
	public string[] cinematico2=new string[8]; 
	[SerializeField]
	bool isMisisonSelect=false;
	[SerializeField]
	Button[] misiones_botones=new Button[8]; 
	[SerializeField]
	Image[] imagenes_botones=new Image[8]; 
	public Sprite warning;
	public Sprite cleared;
	public Sprite unstable;

	[SerializeField]
	Color warningcolor;
	[SerializeField]
	Color clearedcolor;
	[SerializeField]
	Color unstablecolor;


	public string infoesp="Selecciona la brecha que deseas cerrar, solo puedes seleccionar las brechas estables con el icono warning, las brechas cerradas apareceran con el icono data avaliable para poder jugarlas de nuevo";
	public string infoing="select the warning icon breach to continue, the cleared breachs data can be accesed as a simulation by click on his cleared icon , the unstable breachs are not avaliables yet, you must wait till they stabilize to close them";
	public Text infotext;
	public Text exittext;
	public Text titletext;


	void Start(){
		game_control.control.stopreactions=1; 
		game_control.control.checkpoint_actual = 0;
		game_control.control.vidas = 5;
		game_control.control.health = 100;
		game_control.control.energy = 100;
		game_control.control.dialogo_inicialoido = false;
		game_control.control.dialogo_bossoido = false;
		game_control.control.is_changing_scene = 0;
		game_control.control.pausedgame = 0;
		game_control.control.frozen = 0;
		game_control.control.temperature =100;
		game_control.control.poisoned =0;
		game_control.control.cursed =0;
		game_control.control.warping =0;
		game_control.control.venominmune =0;

//		if(isMisisonSelect==true){
//			game_control.control.Load_playerdata();   
//			for(int i=0; i < misiones_botones.Length; i++ ){
//				if (game_control.control.catalogo_misiones [i].unlocked == 1) {
//					misiones_botones [i].interactable = true; 
//
//					if (game_control.control.catalogo_misiones [i].cleared == 1) {
//						imagenes_botones [i].sprite = cleared;
//						imagenes_botones [i].color = clearedcolor;
//					} else {
//						imagenes_botones [i].color = warningcolor;
//					}
//
//
//
//
//				} else {
//					imagenes_botones[i].sprite  = unstable;
//					imagenes_botones [i].color = unstablecolor;
//				}
//			}
//		}

		if (game_control.control.idioma == "Esp") {
			infotext.text = infoesp;
			exittext.text = "Salir";
			titletext.text = "Seleccionar Mision";
		} else {
			infotext.text = infoing;
			exittext.text = "Exit";
			titletext.text = "Mision select";
		}
		ignoremenu = 0;
	}
	public void nextscene(string scene) {
		if(ignoremenu==1){
			return;
		}
		ignoremenu = 1; 
		game_control.control.change_levelsecure(scene); 


	}
	public void nextscene_mision(int mision) {
		if(ignoremenu==1){
			return;
		}
		ignoremenu = 1; 

		game_control.control.nivel_actual = mision;   

		if (game_control.control.saveroom_exit != 0) {
			game_control.control.checkpoint_actual = 1;
			game_control.control.dialogo_inicialoido  = true;
			game_control.control.change_levelsecure ("saveroom");
		} else {
			game_control.control.checkpoint_actual = 0;
			game_control.control.dialogo_inicialoido  = false;
			game_control.control.dialogo_bossoido  = false;
			game_control.control.change_levelsecure(misiones[mision]); 
		}



	}
	// Update is called once per frame
	public void salir () {
		if(ignoremenu==1){
			return;
		}
		ignoremenu = 1; 
		Application.Quit(); 


	}
	IEnumerator ChangeLevel(string scene){
		float fadeTime= GameObject.Find("game control").GetComponent<Fading>().BeginFade(1);
		yield return new WaitForSeconds(fadeTime);
		Application.LoadLevel(scene);

	}
}

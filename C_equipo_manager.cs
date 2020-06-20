using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class C_equipo_manager : MonoBehaviour {
	public Text armor_des;
	public Text especial_des;
	public string[] armornames=new string[5];
	public string[] especialnames=new string[4];

	public string[] armornamesIng=new string[5];
	public string[] especialnamesIng=new string[4];

	public Sprite[] especialicons=new Sprite[4];
	public C_skinswitcher skinswitcher;
	public Image especial_icon;
	// Use this for initialization
	int ignoremenu=1;

	public Text[] displaytexts=new Text[6];

	public string[] displayIng=new string[6];
	public string[] displayESp=new string[6];

	void Start () {
		game_control.control.is_changing_scene = 0; 

		if (game_control.control.idioma == "Esp") {

			for(int i=0; i<displaytexts.Length;i++){
				displaytexts [i].text = displayESp [i];
			}


			armor_des.text =armornames[game_control.control.currentarmor ];
			especial_des.text =especialnames[game_control.control.currentespecial ];
		} else {
			for(int i=0; i<displaytexts.Length;i++){
				displaytexts [i].text = displayIng [i];
			}

			armor_des.text =armornames[game_control.control.currentarmor ];
			especial_des.text =especialnames[game_control.control.currentespecial ];
		}

		ignoremenu = 0;
	}
	
	// Update is called once per frame
	public void nextarmor () {
		if(ignoremenu==1){
			return;
		}
		ignoremenu = 1; 

		if (game_control.control.currentarmor == game_control.control.armorunlocked ) {
			game_control.control.currentarmor = 0;
		} else {
			game_control.control.currentarmor += 1;
		}
		if (game_control.control.idioma == "Esp") {
			armor_des.text =armornames[game_control.control.currentarmor ];

		} else {
			armor_des.text =armornames[game_control.control.currentarmor ];

		}

		skinswitcher.switchbody ();
		ignoremenu = 0; 
	}
	public void prevarmor () {
		if(ignoremenu==1){
			return;
		}
		ignoremenu = 1; 
		if (game_control.control.currentarmor == 0) {
			game_control.control.currentarmor =  game_control.control.armorunlocked ;
		} else {
			game_control.control.currentarmor -= 1;
		}
		if (game_control.control.idioma == "Esp") {
			armor_des.text =armornames[game_control.control.currentarmor ];

		} else {
			armor_des.text =armornames[game_control.control.currentarmor ];

		}

		skinswitcher.switchbody ();
		ignoremenu = 0; 
	}
	public void nextesp () {
		if(ignoremenu==1){
			return;
		}
		ignoremenu = 1; 
		if (game_control.control.currentespecial == game_control.control.espunlocked) {
			game_control.control.currentespecial = 0;
		} else {
			game_control.control.currentespecial += 1;
		}

		if (game_control.control.idioma == "Esp") {
			
			especial_des.text =especialnames[game_control.control.currentespecial ];
		} else {
			
			especial_des.text =especialnames[game_control.control.currentespecial ];
		}
		especial_icon.sprite=especialicons[game_control.control.currentespecial];  
		ignoremenu = 0; 

	}
	public void prevesp () {
		if(ignoremenu==1){
			return;
		}
		ignoremenu = 1; 
		if (game_control.control.currentespecial == 0) {
			game_control.control.currentespecial = game_control.control.espunlocked;
		} else {
			game_control.control.currentespecial -= 1;
		}
		if (game_control.control.idioma == "Esp") {
			
			especial_des.text =especialnames[game_control.control.currentespecial ];
		} else {
			
			especial_des.text =especialnames[game_control.control.currentespecial ];
		}
		especial_icon.sprite=especialicons[game_control.control.currentespecial];  
		ignoremenu = 0; 

	}
	public void salir(string scene) {
		if(ignoremenu==1){
			return;
		}
		ignoremenu = 1; 
		game_control.control.Save_playerdata ();   
		game_control.control.change_levelsecure(scene); 


	}
	IEnumerator ChangeLevel(string scene){
		float fadeTime= GameObject.Find("game control").GetComponent<Fading>().BeginFade(1);
		yield return new WaitForSeconds(fadeTime);
		Application.LoadLevel(scene);

	}
}

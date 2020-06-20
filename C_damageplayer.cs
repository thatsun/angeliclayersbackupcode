using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class C_damageplayer : MonoBehaviour {
	public Animator player_anim;
	public Image hpbar;

	public C_sonidos_player sonidos_player_control;
	// Use this for initialization

	int allowhit=1;
	int habilitado=0;
	int allowhitpicos=1;

	WaitForSeconds wait1=new WaitForSeconds(1.0f); 
	WaitForSeconds wait2=new WaitForSeconds(0.05f); 

	int changing_scene=0;
	int allowhitpart=1;
	public UnityEngine.UI.Image poisonedui;
	public UnityEngine.UI.Image frozenui;
	public UnityEngine.UI.Image cursedui;
	public GameObject wholeuifrozen;
	int frozenui_active=0;
	int allowheateron =1;
	int warping=0;
	[SerializeField]
	c_warp_handler warphandler;
	GameObject warphandlerobj;

	public GameObject avatar_body;
	[SerializeField]
	GameObject deadefect;
	float helper=0;

	C_item_manager itemmanager;

	void OnParticleCollision(GameObject other) {
		if(changing_scene==1){
			return;
		}
		if (game_control.control.pausedgame == 1) {
			return;
		}
		if (game_control.control.stopreactions == 1) {
			return;
		}
		if(allowhitpart==0){
			return;
		}
		allowhitpart = 0;
		if (game_control.control.nivel_actual == 2) {

			if (game_control.control.currentarmor == 1) {
				game_control.control.health -= 2;
			} else {
				game_control.control.health -= 5;
			}

		} else if(game_control.control.nivel_actual==3  ){
			if (game_control.control.currentarmor == 3) {
				game_control.control.health -= 2;
			} else {
				game_control.control.health -= 5;
			}	

		}else {
			game_control.control.health -= 5;
		}

		if(game_control.control.health<=0){
			checkforresetorgameover();
		}
		player_anim.Play("hited",0);  
		sonidos_player_control.play_damagesound(); 
		hpbar.fillAmount = game_control.control.health * 0.01f;
		StartCoroutine(allowdamageparticles()); 
	}
	void Start () {
		game_control.control.poisoned = 0;
		InvokeRepeating("statushandler",2.5f,2.5f); 
		poisonedui = GameObject.Find ("poisonedui").GetComponent<UnityEngine.UI.Image>();
		poisonedui.enabled = false; 
		wholeuifrozen = GameObject.Find ("temperature core");
		frozenui = GameObject.Find ("coreheatbar").GetComponent<UnityEngine.UI.Image>();
		wholeuifrozen.SetActive(false); 
		cursedui = GameObject.Find ("cursedui").GetComponent<UnityEngine.UI.Image>();
		warphandlerobj = GameObject.Find ("warphandler");

		itemmanager = GameObject.Find ("itemcontrol").GetComponent<C_item_manager>();

		if(warphandlerobj!=null){
			warphandler=warphandlerobj.GetComponent<c_warp_handler>();
		}

		
		InvokeRepeating ("autocurar",0.15f,0.15f); 
		

	}
	void autocurar(){
		if(changing_scene==1){
			return;
		}
		if (game_control.control.stopreactions == 1) {
			return;
		}
		if (game_control.control.pausedgame == 1) {
			return;
		}
		if(game_control.control.health==100 ){
			return;			
		}
		if(game_control.control.health<=0 ){
			return;			
		}
        if (game_control.control.autocura == 0)
        {
            return;
        }
        helper = game_control.control.health + 1f;

        if (helper > 100) {
			game_control.control.health = 100;
		} else {
			game_control.control.health = helper;
		}
        hpbar.fillAmount = game_control.control.health * 0.01f;
    }
	void statushandler(){
		if(changing_scene==1){
			return;
		}
		if (game_control.control.stopreactions == 1) {
			return;
		}
		if (game_control.control.pausedgame == 1) {
			return;
		}
		if (game_control.control.is_changing_scene == 1) {
			return;
		}
		if(game_control.control.poisoned==1){
			game_control.control.health -= 3;
			if(game_control.control.health<=0){
				if (game_control.control.autopotion == 1 & (itemmanager.seleccionado==0 || itemmanager.seleccionado==1 || itemmanager.seleccionado==0 )) {
					if (game_control.control.catalogo_inventario [itemmanager.seleccionado].inventario != 0) {
						itemmanager.useitem (); 
					} else {
						game_control.control.poisoned = 0;
						poisonedui.enabled = false; 
						game_control.control.frozen = 0;
						game_control.control.temperature = 100;
						checkforresetorgameover();
					}
				} else {
					game_control.control.frozen = 0;
					game_control.control.temperature = 100;
					game_control.control.poisoned = 0;
					poisonedui.enabled = false; 
					checkforresetorgameover();
				}
			}
			if(player_anim.gameObject.activeInHierarchy ){
				player_anim.Play("hited",0);  
			}
			sonidos_player_control.play_damagesound(); 
			hpbar.fillAmount = game_control.control.health * 0.01f;
		}
		if(game_control.control.frozen ==1){
			if(frozenui_active==0){
				frozenui_active = 1;
				wholeuifrozen.SetActive(true); 
			}
			if (game_control.control.temperature <= 0) {
				game_control.control.health -= 2;
				hpbar.fillAmount = game_control.control.health * 0.01f;
				if (game_control.control.health <= 0) {
					

					if (game_control.control.autopotion == 1 & (itemmanager.seleccionado==0 || itemmanager.seleccionado==1 || itemmanager.seleccionado==0 )) {
						if (game_control.control.catalogo_inventario [itemmanager.seleccionado].inventario != 0) {
							itemmanager.useitem (); 
						} else {
							game_control.control.poisoned = 0;
							poisonedui.enabled = false; 
							game_control.control.frozen = 0;
							game_control.control.temperature = 100;
							checkforresetorgameover();
						}
					} else {
						game_control.control.frozen = 0;
						game_control.control.temperature = 100;
						game_control.control.poisoned = 0;
						poisonedui.enabled = false; 
						checkforresetorgameover();
					}
				}
			} else {
				game_control.control.temperature -= 2;
				frozenui.fillAmount = game_control.control.temperature * 0.01f;    
			}


		}
	}
	void OnTriggerEnter2D(Collider2D collider){
		if(changing_scene==1){
			return;
		}
		if (collider.tag == "checkpoint") {
			
			return;
		}
		if (collider.tag == "puerta") {

			return;
		}
		if (collider.tag == "keys") {

			return;
		}
		if (collider.tag == "item") {

			return;
		}
		if (collider.tag == "uncurse") {
			game_control.control.cursed =0; 
			cursedui.enabled = false; 
			return;
		}
		if (game_control.control.stopreactions == 1) {
			return;
		}
		if (game_control.control.pausedgame == 1) {
			return;
		}
		if (collider.tag == "picos") {
			
			if (game_control.control.currentarmor == 4) {
				return;
			} 

			checkforresetorgameover();
			return;
		}
		if (collider.tag == "heater") {
			return;
		}
		if (collider.tag == "warp") {
			
			return;
		}
		game_control.control.health -= (5/game_control.control.fuerza)/game_control.control.defensa ;
		if(game_control.control.health<=0){
			
			if (game_control.control.autopotion == 1 & (itemmanager.seleccionado==0 || itemmanager.seleccionado==1 || itemmanager.seleccionado==0 )) {
				if (game_control.control.catalogo_inventario [itemmanager.seleccionado].inventario != 0) {
					itemmanager.useitem (); 
				} else {
					game_control.control.poisoned = 0;
					checkforresetorgameover();
				}
			} else {
				game_control.control.poisoned = 0;
				checkforresetorgameover();
			}

		}
		if(player_anim.gameObject.activeInHierarchy ){
			player_anim.Play("hited",0);  
		}
		sonidos_player_control.play_damagesound(); 
		hpbar.fillAmount = game_control.control.health * 0.01f;



	}
	void OnTriggerStay2D(Collider2D collider){
		if(changing_scene==1){
			return;
		}
		if (game_control.control.pausedgame == 1) {
			return;
		}
		if (collider.tag == "item") {

			return;
		}
		if (collider.tag == "puerta") {

			return;
		}
		if (collider.tag == "uncurse") {
			if(game_control.control.cursed ==1){
				game_control.control.cursed =0;
				cursedui.enabled = false;
			}
			return;
		}
		if (collider.tag == "heater") {
			if(allowheateron==0){
				return;
			}

			if(game_control.control.temperature!=100 ){
				allowheateron = 0;
				game_control.control.temperature+=1 ;
				frozenui.fillAmount = game_control.control.temperature * 0.01f;    
				StartCoroutine(allowheater()); 
			}
			return;
		}
		if (collider.tag == "warp") {

			return;
		}
		if (collider.tag == "venompicos" & allowhitpicos==1) {
			allowhitpicos = 0;
			game_control.control.health -= 5;
			if( game_control.control.venominmune==0){
				if (game_control.control.currentarmor != 2) {
					game_control.control.poisoned = 1;
					poisonedui.enabled = true; 
				} 

			}
			if(game_control.control.health<=0){
				

				if (game_control.control.autopotion == 1 & (itemmanager.seleccionado==0 || itemmanager.seleccionado==1 || itemmanager.seleccionado==0 )) {
					if (game_control.control.catalogo_inventario [itemmanager.seleccionado].inventario != 0) {
						itemmanager.useitem (); 
					} else {
						game_control.control.poisoned = 0;
						poisonedui.enabled = false; 
						checkforresetorgameover();
					}
				} else {
					game_control.control.poisoned = 0;
					poisonedui.enabled = false; 
					checkforresetorgameover();
				}

			}
			if(player_anim.gameObject.activeInHierarchy ){
				player_anim.Play("hited",0);  
			}

			sonidos_player_control.play_damagesound(); 
			hpbar.fillAmount = game_control.control.health * 0.01f;
			StartCoroutine(allowdamagepicos());
			return;
		}
		if (collider.tag == "enemigo" & allowhit==0) {
			allowhit = 0;
			game_control.control.health -= 5;
			if(game_control.control.health<=0){
				if (game_control.control.autopotion == 1 & (itemmanager.seleccionado==0 || itemmanager.seleccionado==1 || itemmanager.seleccionado==0 )) {
					if (game_control.control.catalogo_inventario [itemmanager.seleccionado].inventario != 0) {
						itemmanager.useitem (); 
					} else {
						game_control.control.poisoned = 0;
						poisonedui.enabled = false; 
						checkforresetorgameover();
					}
				} else {
					game_control.control.poisoned = 0;
					poisonedui.enabled = false; 
					checkforresetorgameover();
				}
			}	
			if(player_anim.gameObject.activeInHierarchy ){
				player_anim.Play("hited",0);  
			}
			sonidos_player_control.play_damagesound(); 
			hpbar.fillAmount = game_control.control.health * 0.01f;
			StartCoroutine(allowdamage()); 

		}
	}
	IEnumerator allowheater(){
		yield return  wait2;
		allowheateron = 1;

	}
	IEnumerator allowdamagepicos(){
		yield return  wait1;
		allowhitpicos = 1;

	}
	IEnumerator allowdamageparticles(){
		yield return  wait1;
		allowhitpart = 1;

	}
	IEnumerator allowdamage(){
		yield return  wait1;
		allowhit = 1;

	}
	void checkforresetorgameover(){
		if(changing_scene==1){
			return;
		}
		CancelInvoke("autocurar"); 
		changing_scene = 1;
		avatar_body.SetActive(false);  
		deadefect.SetActive(true);
        if (Application.loadedLevelName== "ge_nigthmare1" || Application.loadedLevelName == "ge_nigthmare2" || Application.loadedLevelName == "ge_nigthmare3" || Application.loadedLevelName == "ge_nigthmare4")
        {
            game_control.control.poisoned = 0;
            game_control.control.health = 100;
            game_control.control.energy = 100;
            game_control.control.frozen = 0;
            game_control.control.temperature = 100;
            game_control.control.change_levelsecure("ge_engel_room");
            return;
        }
		game_control.control.vidas -= 1;
		if (game_control.control.vidas != 0) {
			game_control.control.poisoned = 0;
			game_control.control.health = 100;
			game_control.control.energy = 100; 
			game_control.control.frozen = 0;
			game_control.control.temperature = 100;
			game_control.control.change_levelsecure(Application.loadedLevelName); 

		} else {
			
			game_control.control.checkpoint_actual = 0;
			game_control.control.vidas = 5;
			game_control.control.poisoned = 0;
			game_control.control.health = 100;
			game_control.control.energy = 100; 
			game_control.control.frozen = 0;
			game_control.control.temperature = 100;
			game_control.control.dialogo_inicialoido = false;
			game_control.control.dialogo_bossoido = false;

			if (game_control.control.isbossrush == 1) {
				game_control.control.isbossrush = 0;
				game_control.control.change_levelsecure("gd_main_menu"); 
			} else {
				game_control.control.change_levelsecure("gd_main_menu"); 
			}

		}
	}
	IEnumerator ChangeLevel(string scene){
		float fadeTime= GameObject.Find("game control").GetComponent<Fading>().BeginFade(1);
		yield return new WaitForSeconds(fadeTime);
		Application.LoadLevel(scene);

	}


}

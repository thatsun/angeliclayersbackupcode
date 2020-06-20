using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class C_item_manager : MonoBehaviour {
	[SerializeField]
	Text current_name;
	[SerializeField]
	Text current_cantidad;
	[SerializeField]
	UnityEngine.UI.Image current_icon;

	public itemsdetails[] iteminfos=new itemsdetails[10];

	public int seleccionado=0;
	// Use this for initialization
	float helper=0;
	public UnityEngine.UI.Image hpbar;
	public UnityEngine.UI.Image mpbar;
	public UnityEngine.UI.Image poisonedui;
	public UnityEngine.UI.Image cursedui;


	WaitForSeconds venomwait=new WaitForSeconds(300f); 

	public C_damageplayer damagepbridge;

	public Sprite defaulticon;

	void Start () {
		game_control.control.venominmune =0;
		hpbar = GameObject.Find ("hpbar").GetComponent<UnityEngine.UI.Image>();
		mpbar = GameObject.Find ("mpbar").GetComponent<UnityEngine.UI.Image>();
		poisonedui = GameObject.Find ("poisonedui").GetComponent<UnityEngine.UI.Image>();
		cursedui = GameObject.Find ("cursedui").GetComponent<UnityEngine.UI.Image>();
		poisonedui.enabled=false; 
		current_icon.sprite = iteminfos [seleccionado].icon;
		current_name.text = iteminfos [seleccionado].nombre;
		current_cantidad.text = game_control.control.catalogo_inventario[seleccionado].inventario.ToString();

		hpbar.fillAmount = game_control.control.health * 0.01f;    
		mpbar.fillAmount = game_control.control.energy * 0.01f; 
	}
	
	// Update is called once per frame
	void Update () {
		if(game_control.control.pausedgame ==1  ){
			return;
		}
		if(game_control.control.stopreactions ==1  ){
			return;
		}
		if(game_control.control.is_changing_scene ==1  ){
			return;
		}
		if(Input.GetButtonDown("NextItem")){
			togleitem ();
			return;
		}
		if(Input.GetButtonDown("UseItem")){
			useitem();
		}
	}
	public void useitem(){
		if(game_control.control.pausedgame ==1  ){
			return;
		}
		if(game_control.control.stopreactions ==1  ){
			return;
		}
		if(game_control.control.is_changing_scene ==1  ){
			return;
		}
		if(game_control.control.health<=0 & game_control.control.autopotion==0){
			return;
		}
		if(game_control.control.catalogo_inventario[seleccionado].inventario==0){
			return;
		}
		if (game_control.control.catalogo_inventario [seleccionado].unlocked == 0) {
			return;
		}
		if(seleccionado==0){
			if (game_control.control.health < 100) {
				helper = game_control.control.health + 30f;
				if (helper > 100) {
					game_control.control.health = 100f;
				} else {
					game_control.control.health = helper;
				}

				game_control.control.catalogo_inventario [seleccionado].inventario -= 1; 
				current_cantidad.text = game_control.control.catalogo_inventario[seleccionado].inventario.ToString();
				hpbar.fillAmount = game_control.control.health * 0.01f;    
			} else {
                hpbar.fillAmount = game_control.control.health * 0.01f;
            }
			return;
		}
		if(seleccionado==1){
			if (game_control.control.health != 100) {
				
				game_control.control.health = 100;   
				game_control.control.catalogo_inventario [seleccionado].inventario -= 1; 
				current_cantidad.text = game_control.control.catalogo_inventario[seleccionado].inventario.ToString();
				hpbar.fillAmount = game_control.control.health * 0.01f; 
			} else {
                hpbar.fillAmount = game_control.control.health * 0.01f;
            }
			return;
		}
		if(seleccionado==2){
			if (game_control.control.poisoned==1 ) {
				game_control.control.poisoned =0; 
				poisonedui.enabled =false; 
				game_control.control.catalogo_inventario [seleccionado].inventario -= 1; 
				current_cantidad.text = game_control.control.catalogo_inventario[seleccionado].inventario.ToString();
				hpbar.fillAmount = game_control.control.health * 0.01f;    
			} else {
				//no use
			}
			return;
		}
		if(seleccionado==3){
			if (game_control.control.energy != 100) {

				game_control.control.energy = 100;   
				game_control.control.catalogo_inventario [seleccionado].inventario -= 1; 
				current_cantidad.text = game_control.control.catalogo_inventario[seleccionado].inventario.ToString();
				mpbar.fillAmount = game_control.control.energy * 0.01f; 
			} else {
				//no use
			}
			return;

		}
		if(seleccionado==4){
			if (game_control.control.luck != 2) {

				game_control.control.luck = 2;   
				game_control.control.catalogo_inventario [seleccionado].inventario -= 1; 
				current_cantidad.text = game_control.control.catalogo_inventario[seleccionado].inventario.ToString();
				 
			} else {
				//no use
			}

			return;
		}
		if(seleccionado==5){
			if (game_control.control.venominmune!= 1) {

				game_control.control.venominmune = 1;   
				game_control.control.catalogo_inventario [seleccionado].inventario -= 1; 
				current_cantidad.text = game_control.control.catalogo_inventario[seleccionado].inventario.ToString();

				game_control.control.poisoned = 0;   
				poisonedui.enabled = false;
				StartCoroutine(inmuneoff()); 
			} else {
				//no use
			}
			return;

		}
		if(seleccionado==6){
			if (game_control.control.cursed != 0) {

				game_control.control.cursed = 0;   
				game_control.control.catalogo_inventario [seleccionado].inventario -= 1; 
				current_cantidad.text = game_control.control.catalogo_inventario[seleccionado].inventario.ToString();

				 
				cursedui.enabled = false;

			} else {
				//no use
			}
			return;

		}
		if(seleccionado==7){
			if (game_control.control.health != 0 & game_control.control.frozen==1 & game_control.control.temperature !=100) {

				game_control.control.temperature = 100;   
				game_control.control.catalogo_inventario [seleccionado].inventario -= 1; 
				current_cantidad.text = game_control.control.catalogo_inventario[seleccionado].inventario.ToString();

				damagepbridge.frozenui.fillAmount = game_control.control.temperature * 0.01f;     
				cursedui.enabled = false;

			} else {
				//no use
			}
			return;
		}
		if(seleccionado==8){
			if (game_control.control.cursed != 0) {

				game_control.control.cursed = 0;   
				game_control.control.catalogo_inventario [seleccionado].inventario -= 1; 
				current_cantidad.text = game_control.control.catalogo_inventario[seleccionado].inventario.ToString();


				cursedui.enabled = false;

			}
			if (game_control.control.cursed != 0) {

				game_control.control.cursed = 0;   
				game_control.control.catalogo_inventario [seleccionado].inventario -= 1; 
				current_cantidad.text = game_control.control.catalogo_inventario[seleccionado].inventario.ToString();


				cursedui.enabled = false;

			}
			if (game_control.control.health != 0 & game_control.control.frozen==1 & game_control.control.temperature !=100) {

				game_control.control.temperature = 100;   
				game_control.control.catalogo_inventario [seleccionado].inventario -= 1; 
				current_cantidad.text = game_control.control.catalogo_inventario[seleccionado].inventario.ToString();

				damagepbridge.frozenui.fillAmount = game_control.control.temperature * 0.01f;     
				cursedui.enabled = false;

			}
		}
		if(seleccionado==9){
			if (game_control.control.health != 100) {

				game_control.control.health = 100;   
				game_control.control.catalogo_inventario [seleccionado].inventario -= 1; 
				current_cantidad.text = game_control.control.catalogo_inventario[seleccionado].inventario.ToString();
				hpbar.fillAmount = game_control.control.health * 0.01f; 
			}
			if (game_control.control.energy != 100) {

				game_control.control.energy = 100;   
				game_control.control.catalogo_inventario [seleccionado].inventario -= 1; 
				current_cantidad.text = game_control.control.catalogo_inventario[seleccionado].inventario.ToString();
				mpbar.fillAmount = game_control.control.energy * 0.01f; 
			}
			return;
		}
	}
	void togleitem(){
		if(seleccionado==9){
			seleccionado = 0;
		}
		else{
			seleccionado++;
		}
		if (game_control.control.catalogo_inventario [seleccionado].unlocked == 1) {
			current_icon.sprite = iteminfos [seleccionado].icon;
			current_name.text = iteminfos [seleccionado].nombre;
			current_cantidad.text = game_control.control.catalogo_inventario[seleccionado].inventario.ToString();
		} else {
			current_icon.sprite = defaulticon;
			current_name.text = "empty";
			current_cantidad.text = "";
		}


		
	}
	IEnumerator  inmuneoff(){
		yield return venomwait;
		game_control.control.venominmune =0;   
		
	}
	public void updateitemui(int indice){
		if(indice==seleccionado ){
			current_cantidad.text = game_control.control.catalogo_inventario[seleccionado].inventario.ToString();
		}
	}

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_item_fijo : MonoBehaviour {

	public int activa=0;

	[SerializeField]
	float life=10f;
	[SerializeField]
	int tipo=0;
	// Update is called once per frame
	public C_item_manager itemmanager;


	public void Start(){
		itemmanager = GameObject.Find ("itemcontrol").GetComponent<C_item_manager>();
		activa = 1;
	}
	void OnTriggerEnter2D(Collider2D collider){
		if (game_control.control.pausedgame == 1) {
			return;
		}
		if (game_control.control.stopreactions == 1) {
			return;
		}
		if (game_control.control.is_changing_scene == 1) {
			return;
		}
		if(activa==0){
			return;
		}

		if (collider.gameObject.CompareTag("playerdamage")){
			activa = 0; 
			game_control.control.catalogo_inventario[tipo].inventario++;   

			itemmanager.updateitemui(tipo); 

			this.gameObject.SetActive (false);  
			return;
		}
	}


}

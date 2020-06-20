using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_item : MonoBehaviour {

	public int activa=0;

	[SerializeField]
	float life=10f;
	[SerializeField]
	int tipo=0;
	// Update is called once per frame
	public C_item_manager itemmanager;
	public bool nodesactivar=false;
	public void OnEnable(){
		
		activa = 1;
		if(nodesactivar==false){
			Invoke("disablebullet",life); 

		}

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
			if (nodesactivar == false) {
				CancelInvoke (); 
			}
			this.gameObject.SetActive (false);  
			return;
		}
	}
	void disablebullet(){
		activa = 0; 
		this.gameObject.SetActive(false);  
	}

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class my_item_poolscript : MonoBehaviour {
	

	public List<GameObject> pooled_objects=new List<GameObject>();
	public List<C_item> pooled_itemdata=new List<C_item>();
	// Use this for initialization
	public C_item_manager itemnanager;
	// Update is called once per frame
	int indexer1=0;
	public void Start(){
		
		itemnanager = GameObject.Find ("itemcontrol").GetComponent<C_item_manager>();   

		for (int i =0; i< pooled_itemdata.Count; i++){
			pooled_itemdata [i].itemmanager = itemnanager;
		}
	}
	public GameObject GetPooledObjet(){
		indexer1 = Random.Range(0,40); 
		if(indexer1<10){
			return null;
		}
		indexer1 = Random.Range(0,20); 
		if (indexer1 < 10) {
			if (!pooled_objects [0].activeInHierarchy) {
				return pooled_objects [0];
			}
			return null;
		} else {
			indexer1 = Random.Range(1,9); 
			if(game_control.control.catalogo_inventario[indexer1].unlocked==0){
				return null;
			}

			if (!pooled_objects [indexer1].activeInHierarchy) {
				return pooled_objects [indexer1];
			}
			return null;
		}
		return null;
	}
}

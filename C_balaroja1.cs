using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_balaroja1 : MonoBehaviour {	
	public int activa=0;
	public Transform target;
	Vector3 target1=Vector3.zero;
	[SerializeField]
	float speed;
	float step;
	public bool perseguir=false;
	public bool circular=false;
	// Use this for initialization
	public float life=10f;
	Vector3 normaliseddirection=Vector3.zero;
	public bool invulnerable_a_disparos=false;
	[SerializeField]
	bool poison=false;
	[SerializeField]
	bool cursed=false;
	public UnityEngine.UI.Image poisonedui;
	public UnityEngine.UI.Image cursedui;
	void Awake () {
		if (circular == true) {
			target = GameObject.Find("boss_circularshoter").GetComponent<Transform>();
		} else {
			target = GameObject.Find("configurador").GetComponent<C_configurador>().playertarget;
		}
		poisonedui = GameObject.Find ("poisonedui").GetComponent<UnityEngine.UI.Image>();
		cursedui = GameObject.Find ("cursedui").GetComponent<UnityEngine.UI.Image>();

	}	
	void Start(){
		
	}
	// Update is called once per frame
	public void OnEnable(){
		normaliseddirection=(target.position-transform.position).normalized;
		activa = 1;
		Invoke("disablebullet",life); 

	}
	void OnTriggerEnter2D(Collider2D collider){
		if (game_control.control.pausedgame == 1) {
			return;
		}
		if(activa==0){
			return;
		}
		if (invulnerable_a_disparos==true & game_control.control.currentarmor!=5  ) {
			if (collider.gameObject.CompareTag("playerdamage")){
				activa = 0; 
				if(poison==true & game_control.control.poisoned==0 & game_control.control.venominmune==0 & game_control.control.currentarmor!=2 ){
					game_control.control.poisoned = 1;   
					poisonedui.enabled = true; 
				}
				if(cursed==true & game_control.control.cursed==0){
					if (game_control.control.currentarmor != 3 & game_control.control.currentarmor !=5) {
						game_control.control.cursed = 1;   
						cursedui.enabled = true; 
					} 

				}
				CancelInvoke (); 
				this.gameObject.SetActive (false);  
				return;
			}
		}
		else {
			if (collider.gameObject.CompareTag("playerdamage")){
				if(poison==true & game_control.control.poisoned==0 & game_control.control.venominmune==0 & game_control.control.currentarmor!=2 ){
					game_control.control.poisoned = 1;   
					poisonedui.enabled = true; 
				}
				if(cursed==true & game_control.control.cursed==0){
					if (game_control.control.currentarmor != 3 & game_control.control.currentarmor !=5) {
						game_control.control.cursed = 1;   
						cursedui.enabled = true; 
					} 

				}

			}

			activa = 0; 
			CancelInvoke (); 
			this.gameObject.SetActive (false);  
			return;
		}





	}
	void disablebullet(){
		activa = 0; 
		this.gameObject.SetActive(false);  
	}
	void Update(){
		if (game_control.control.pausedgame == 1) {
			return;
		}
		if(activa==0){
			return;
		}
		if (game_control.control.stopreactions == 1) {
			activa = 0; 
			CancelInvoke(); 
			this.gameObject.SetActive(false);  
			return;
		}
		step = speed * Time.deltaTime;
		if (perseguir == true) {
			target1.x = target.position.x; 
			target1.y = target.position.y; 
			transform.position = Vector3.MoveTowards (transform.position, target1, step);   
		} else {
			transform.position += normaliseddirection * speed * Time.deltaTime;   
		}

	}
}

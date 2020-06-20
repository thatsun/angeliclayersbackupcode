using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_balaazul : MonoBehaviour {
	public int activa=0;

	Vector3 target1=Vector3.zero;
	[SerializeField]
	float speed;

	public bool perseguir=false;
	// Use this for initialization
	public Controller2D player2dcontrol; 
	public Player currentplayer;
	Vector3 normaliseddirection=Vector3.zero;
	void Awake () {
		player2dcontrol = GameObject.Find ("Player").GetComponent<Controller2D>();  
		currentplayer = GameObject.Find ("Player").GetComponent<Player>();
	}	
	// Update is called once per frame
	public void OnEnable(){
		if (currentplayer.wallSliding == true) {
			if (player2dcontrol.collisions.faceDir == 1) {
				normaliseddirection.x = -1;
			} else {
				normaliseddirection.x = 1;
			}
			
		} else {
			if (player2dcontrol.collisions.faceDir == 1) {
				normaliseddirection.x = 1;
			} else {
				normaliseddirection.x = -1;
			}
		}

		activa = 1;
		Invoke("disablebullet",5.0f); 

	}
	void OnTriggerEnter2D(Collider2D collider){
		if (game_control.control.pausedgame == 1) {
			return;
		}
		if(game_control.control.stopreactions==1){
			return;
		}
		if(activa==0){
			return;
		}
		activa = 0; 
		CancelInvoke(); 
		this.gameObject.SetActive(false);  



	}
	void disablebullet(){
		activa = 0; 
		this.gameObject.SetActive(false);  
	}
	void Update(){
		if (game_control.control.pausedgame == 1) {
			return;
		}
		if(game_control.control.stopreactions==1){
			activa = 0; 
			CancelInvoke(); 
			this.gameObject.SetActive(false);  
			return;
		}

		transform.position += normaliseddirection * speed * Time.deltaTime;   


	}
}

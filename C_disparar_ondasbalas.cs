using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_disparar_ondasbalas : MonoBehaviour {
	public float fire_time;
	public float fire_ratio;
	public Transform my_transform;
	int shot=1; 
	public int shoter=1;
	// Use this for initialization
	my_generic_pool_script genericpooler;
	Vector3 temp_rot=Vector3.zero;   
	void Start () {

        //		InvokeRepeating("Fire_interval",1.0f,1.0f);
        
        genericpooler =GameObject.Find ("poolsistemboss").GetComponent<my_generic_pool_script>();  

		InvokeRepeating("fire10",fire_time,fire_ratio);
		InvokeRepeating("fire12",fire_time+0.25f,fire_ratio);
		InvokeRepeating("fire12_1",fire_time+0.5f,fire_ratio);
		InvokeRepeating("fire12_2",fire_time+0.75f,fire_ratio);

	}
	void fire10(){
		if (game_control.control.pausedgame == 1) {
			return;
		}
		if (game_control.control.stopreactions == 1) {
			return;
		}
		if(shoter==0 ){
			return;
		}	
		temp_rot.z = 0f;
		my_transform.eulerAngles = temp_rot;
		Fire();
		temp_rot.z = 36f;
		my_transform.eulerAngles = temp_rot;
		Fire();
		temp_rot.z = 72f;
		my_transform.eulerAngles = temp_rot;
		Fire();
		temp_rot.z = 108f;
		my_transform.eulerAngles = temp_rot;
		Fire();
		temp_rot.z = 144f;
		my_transform.eulerAngles = temp_rot;
		Fire();
		temp_rot.z = 180f;
		my_transform.eulerAngles = temp_rot;
		Fire();
		temp_rot.z = 216f;
		my_transform.eulerAngles = temp_rot;
		Fire();
		temp_rot.z = 252f;
		my_transform.eulerAngles = temp_rot;
		Fire();
		temp_rot.z = 288f;
		my_transform.eulerAngles = temp_rot;
		Fire();
		temp_rot.z = 324f;
		my_transform.eulerAngles = temp_rot;
		Fire();

	}
	void fire12(){
		if (game_control.control.pausedgame == 1) {
			return;
		}
		if (game_control.control.stopreactions == 1) {
			return;
		}
		if(shoter==0 ){
			return;
		}	
		temp_rot.z = 3f;
		my_transform.eulerAngles = temp_rot;
		Fire();
		temp_rot.z = 33f;
		my_transform.eulerAngles = temp_rot;
		Fire();
		temp_rot.z = 75f;
		my_transform.eulerAngles = temp_rot;
		Fire();
		temp_rot.z = 113f;
		my_transform.eulerAngles = temp_rot;
		Fire();
		temp_rot.z = 147f;
		my_transform.eulerAngles = temp_rot;
		Fire();
		temp_rot.z = 183f;
		my_transform.eulerAngles = temp_rot;
		Fire();
		temp_rot.z = 219f;
		my_transform.eulerAngles = temp_rot;
		Fire();
		temp_rot.z = 255f;
		my_transform.eulerAngles = temp_rot;
		Fire();
		temp_rot.z = 291f;
		my_transform.eulerAngles = temp_rot;
		Fire();
		temp_rot.z = 327f;
		my_transform.eulerAngles = temp_rot;
		Fire();

	}
	void fire12_1(){
		if (game_control.control.pausedgame == 1) {
			return;
		}
		if (game_control.control.stopreactions == 1) {
			return;
		}
		if(shoter==0 ){
			return;
		}	
		temp_rot.z = 9f;
		my_transform.eulerAngles = temp_rot;
		Fire();
		temp_rot.z = 39f;
		my_transform.eulerAngles = temp_rot;
		Fire();
		temp_rot.z = 81f;
		my_transform.eulerAngles = temp_rot;
		Fire();
		temp_rot.z = 119f;
		my_transform.eulerAngles = temp_rot;
		Fire();
		temp_rot.z = 153f;
		my_transform.eulerAngles = temp_rot;
		Fire();
		temp_rot.z = 189f;
		my_transform.eulerAngles = temp_rot;
		Fire();
		temp_rot.z = 225f;
		my_transform.eulerAngles = temp_rot;
		Fire();
		temp_rot.z = 261f;
		my_transform.eulerAngles = temp_rot;
		Fire();
		temp_rot.z = 297f;
		my_transform.eulerAngles = temp_rot;
		Fire();
		temp_rot.z = 333f;
		my_transform.eulerAngles = temp_rot;
		Fire();

	}
	void fire12_2(){
		if (game_control.control.pausedgame == 1) {
			return;
		}
		if (game_control.control.stopreactions == 1) {
			return;
		}
		if(shoter==0 ){
			return;
		}	
		temp_rot.z = 6f;
		my_transform.eulerAngles = temp_rot;
		Fire();
		temp_rot.z = 36f;
		my_transform.eulerAngles = temp_rot;
		Fire();
		temp_rot.z = 78f;
		my_transform.eulerAngles = temp_rot;
		Fire();
		temp_rot.z = 116f;
		my_transform.eulerAngles = temp_rot;
		Fire();
		temp_rot.z = 150f;
		my_transform.eulerAngles = temp_rot;
		Fire();
		temp_rot.z = 186f;
		my_transform.eulerAngles = temp_rot;
		Fire();
		temp_rot.z = 222f;
		my_transform.eulerAngles = temp_rot;
		Fire();
		temp_rot.z = 258f;
		my_transform.eulerAngles = temp_rot;
		Fire();
		temp_rot.z = 294f;
		my_transform.eulerAngles = temp_rot;
		Fire();
		temp_rot.z = 330f;
		my_transform.eulerAngles = temp_rot;
		Fire();

	}
	void Fire () {
		if (game_control.control.pausedgame == 1) {
			return;
		}
		
		GameObject obj=genericpooler.GetPooledObjet();
		if (obj==null)return;
		obj.transform.position = my_transform.position;
		obj.SetActive(true);		
	}	
}

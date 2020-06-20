using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_skinswitcher : MonoBehaviour {
	public Renderer body;
	public Renderer[] armor1=new Renderer[8];

	public Texture2D[] armors=new Texture2D[5];  
	public Texture2D[] bodys=new Texture2D[5];  
	// Use this for initialization
	public bool emision=false;
	void Start () {
        

		for(int i=0; i<armor1.Length ;i++){
			armor1 [i].material.SetTexture("_MainTex",bodys[game_control.control.currentarmor] );  
		}
		body.material.SetTexture("_MainTex",armors[game_control.control.currentarmor] );
		if(emision==true ){
			for(int i=0; i<armor1.Length ;i++){
				armor1 [i].material.SetTexture("_EmissionMap",bodys[game_control.control.currentarmor] );  
			}
			body.material.SetTexture("_EmissionMap",armors[game_control.control.currentarmor] );
		}
	}
	public void switchbody(){
		for(int i=0; i<armor1.Length ;i++){
			armor1 [i].material.SetTexture("_MainTex",bodys[game_control.control.currentarmor] );  
		}
		body.material.SetTexture("_MainTex",armors[game_control.control.currentarmor] );
		if(emision==true ){
			for(int i=0; i<armor1.Length ;i++){
				armor1 [i].material.SetTexture("_EmissionMap",bodys[game_control.control.currentarmor] );  
			}
			body.material.SetTexture("_EmissionMap",armors[game_control.control.currentarmor] );
		}
	}

}

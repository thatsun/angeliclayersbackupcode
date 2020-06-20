using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_controles_halp : MonoBehaviour {
	[SerializeField]
	GameObject controlpanel;
	[SerializeField]
	bool hiden=true;
	// Update is called once per frame
	public void hidecontrol () {
		if(hiden==true){
			hiden = false;
			controlpanel.SetActive(true);
		}else{
			hiden = true;
			controlpanel.SetActive(false);
		}
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class C_especialeschar : MonoBehaviour {

	public GameObject m1;
	public GameObject m2;
	public GameObject m3;
	public GameObject m4;
	public GameObject m5;
	public GameObject m6;
	public GameObject m7;
	public GameObject m8;
	public GameObject m9;


	public int current=0;
	int previous;

	int ignoremenu=1;

	public Text[] displays=new Text[4];

	public string[] displaysIng=new string[4]; 
	public string[] displaysEsp=new string[4]; 

	void Start () {
		game_control.control.is_changing_scene = 0;
        
        current=game_control.control.currentmodel;
        if (previous == 0)
        {
            m1.SetActive(false);
        }
        if (previous == 1)
        {
            m2.SetActive(false);
        }
        if (previous == 2)
        {
            m3.SetActive(false);
        }
        if (previous == 3)
        {
            m4.SetActive(false);
        }
        if (previous == 4)
        {
            m5.SetActive(false);
        }
        if (previous == 5)
        {
            m6.SetActive(false);
        }
        if (previous == 6)
        {
            m7.SetActive(false);
        }
        if (previous == 7)
        {
            m8.SetActive(false);
        }
        if (previous == 8)
        {
            m9.SetActive(false);
        }

        if (current == 0)
        {
            m1.SetActive(true);
        }
        if (current == 1)
        {
            m2.SetActive(true);
        }
        if (current == 2)
        {
            m3.SetActive(true);
        }
        if (current == 3)
        {
            m4.SetActive(true);
        }
        if (current == 4)
        {
            m5.SetActive(true);
        }
        if (current == 5)
        {
            m6.SetActive(true);
        }
        if (current == 6)
        {
            m7.SetActive(true);
        }
        if (current == 7)
        {
            m8.SetActive(true);
        }
        if (current == 8)
        {
            m9.SetActive(true);
        }


        

        if (game_control.control.idioma == "Esp") {
			for(int i=0; i< displays.Length;i++ ){
				displays [i].text = displaysEsp [i];
			}
		} else {
			for(int i=0; i< displays.Length;i++ ){
				displays [i].text = displaysIng [i];
			}
		}


		ignoremenu=0;
	}
	public void salir(string scene) {
		if(ignoremenu==1){
			return;
		}
		ignoremenu = 1; 
		game_control.control.change_levelsecure(scene); 


	}
	IEnumerator ChangeLevel(string scene){
		float fadeTime= GameObject.Find("game control").GetComponent<Fading>().BeginFade(1);
		yield return new WaitForSeconds(fadeTime);
		Application.LoadLevel(scene);

	}
	public void next(){
		previous=current;
		current+=1;
		if(current==9){
			current=0;
		}

		if(current==0){
			m1.SetActive(true);
		}
		if(current==1){
			m2.SetActive(true);
		}
		if(current==2){
			m3.SetActive(true);
		}
		if(current==3){
			m4.SetActive(true);
		}
		if(current==4){
			m5.SetActive(true);
		}
		if(current==5){
			m6.SetActive(true);
		}
		if(current==6){
			m7.SetActive(true);
		}
		if(current==7){
			m8.SetActive(true);
		}
		if(current==8){
			m9.SetActive(true);
		}


		if(previous==0){
			m1.SetActive(false);
		}
		if(previous==1){
			m2.SetActive(false);
		}
		if(previous==2){
			m3.SetActive(false);
		}
		if(previous==3){
			m4.SetActive(false);
		}
		if(previous==4){
			m5.SetActive(false);
		}
		if(previous==5){
			m6.SetActive(false);
		}
		if(previous==6){
			m7.SetActive(false);
		}
		if(previous==7){
			m8.SetActive(false);
		}
		if(previous==8){
			m9.SetActive(false);
		}
		game_control.control.currentmodel = current;  
	}

}

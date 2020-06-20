using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class c_cinematic_handler : MonoBehaviour {
	[SerializeField]
	Transform[] cameratargets=new Transform[4];
	[SerializeField]
	Transform[] cameralooktargets=new Transform[4];
	// Use this for initialization
	[SerializeField]
	Transform cameratransform;
	Vector3 place=Vector3.zero;  
	int current=0;
	int currentsound=0;
	int currentvisual=0;
	[SerializeField]
	float[] timers=new float[4];
	[SerializeField]
	string nextscene="";
	//playsetings
	[SerializeField]
	float duracion=10f;
	[SerializeField]
	bool soundon=false;
	[SerializeField]
	bool visuales=false;

	[SerializeField]
	AudioSource[] soundefects=new AudioSource[4];
	[SerializeField]
	float[] soundefectstimers=new float[4];

	int camerasizelimit=0;
	int helper=0;

	[SerializeField]
	bool debugingescene=false;

	[SerializeField]
	ParticleSystem[] visualefects=new ParticleSystem[4];
	[SerializeField]
	float[] visualefectstimers=new float[4];

	void Start () {
		game_control.control.is_changing_scene = 0;   
		camerasizelimit = cameratargets.Length-1;  
		if (debugingescene == false) {
			nextscene = game_control.control.cinematico2;
		} 

		Invoke("switchcamera",timers[current]);
		Invoke("cinematico_fin",duracion);
		if(soundon==true){
			Invoke("soundefect",soundefectstimers[currentsound]);
		}
		if(visuales==true){
			Invoke("visualefect",visualefectstimers[currentvisual]);
		}

	}

	// Update is called once per frame
	void Update () {
		if (current == cameratargets.Length) {
			helper = cameratargets.Length - 1;
		} else {
			helper = current;
		}

		place = cameratargets [helper].position;
		cameratransform.position = place;

		cameratransform.LookAt(cameralooktargets[helper]);
	}
	void switchcamera(){
		if (current == camerasizelimit) {
			return;

		} else {
			current++;
			Invoke ("switchcamera", timers[current]);


		}



	}
	void visualefect(){
		if (currentvisual == visualefects.Length) {
			return;

		} else {

			visualefects[currentvisual].Play(); 
			currentvisual++;
			if (currentvisual == visualefects.Length) {
				return;
			}
			Invoke("visualefect",visualefectstimers[currentvisual]);
		}



	}
	void soundefect(){
		if (currentsound == soundefects.Length) {
			return;

		} else {
			
			soundefects[currentsound].Play(); 
			currentsound++;
			if (currentsound == soundefects.Length) {
				return;
			}
			Invoke ("soundefect", soundefectstimers[currentsound]);
		}



	}
	void cinematico_fin(){
		game_control.control.change_levelsecure(nextscene);  
	}
}

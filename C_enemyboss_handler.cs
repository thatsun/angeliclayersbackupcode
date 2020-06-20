using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_enemyboss_handler : MonoBehaviour {
	public Transform bossfacing;
	public Transform playertransform;
	// Use this for initialization
	Vector3 targetfacing=Vector3.zero;  

	public Animator boss_animator;
	public Animator poscicion_animator;
	// Update is called once per frame
	void Update () {
		if (game_control.control.pausedgame == 1) {
			return;
		}
		if (bossfacing.position.x > playertransform.position.x) {
			targetfacing.y=135f;
			bossfacing.eulerAngles = targetfacing; 
		} else {
			targetfacing.y=51f;
			bossfacing.eulerAngles = targetfacing; 
		}
	}
}

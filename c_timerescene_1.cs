using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class c_timerescene_1 : MonoBehaviour {
    public Text timervalue;
    public int currenttime = 300;
    public string nextscene;
	// Use this for initialization
	void Start () {
        InvokeRepeating("timer",1.0f,1.0f);
	}
	
	// Update is called once per frame
	void timer () {
        if (game_control.control.is_changing_scene==1)
        {
            return;
        }
        if (game_control.control.pausedgame == 1)
        {
            return;
        }
        if (game_control.control.stopreactions == 1)
        {
            return;
        }

        if (currenttime==0)
        {
            game_control.control.stopreactions = 1;            
            
            game_control.control.health = 100;
            game_control.control.energy = 100;
            
            game_control.control.pausedgame = 0;
            game_control.control.frozen = 0;
            game_control.control.temperature = 100;
            game_control.control.poisoned = 0;
            game_control.control.cursed = 0;
            game_control.control.warping = 0;

            game_control.control.change_levelsecure(nextscene);
            CancelInvoke();
            return;
        }
        else
        {
            currenttime--;
            timervalue.text = currenttime.ToString();
        }
        
    }
    
}

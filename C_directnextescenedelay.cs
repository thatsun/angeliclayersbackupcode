using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_directnextescenedelay : MonoBehaviour {
    public string nextscene="";
    public float delay = 5.0f;
    // Use this for initialization
    void Start () {
        game_control.control.is_changing_scene = 0;

        Invoke("gonextscene", delay);
	}

    // Update is called once per frame
    public void gonextscene()
    {


                
        game_control.control.change_levelsecure(nextscene);


    }
}

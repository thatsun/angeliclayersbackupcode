using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class c_extradisplays : MonoBehaviour {
    
    [SerializeField] GameObject autopotion_label;
    [SerializeField] GameObject autocura_label;
    public GameObject enhanced_label;
    
    // Use this for initialization
    void Start () {
        if (game_control.control.autocura==1)
        {
            autocura_label.SetActive(true);
        }
        else
        {
            autocura_label.SetActive(false);
        }
        if (game_control.control.autopotion == 1)
        {
            autopotion_label.SetActive(true);
        }
        else
        {
            autopotion_label.SetActive(false);
        }
    }	
}

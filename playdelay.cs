using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playdelay : MonoBehaviour {
    public float empiezanen=25.0f;
    public float terminasen = 30f;
    public  AudioSource audioSource;
    // Use this for initialization
    void Start () {
        audioSource.time = empiezanen;//donde empezar obviamente el clip debe estar parado a estas alturas
        audioSource.Play();//reproducir
        audioSource.SetScheduledEndTime(AudioSettings.dspTime + (terminasen- empiezanen));//donde parar, esto es solo si ocupas que se pare antes
        

    }

    // Update is called once per frame
    void Update () {
		
	}
}

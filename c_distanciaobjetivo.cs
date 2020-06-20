using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class c_distanciaobjetivo : MonoBehaviour {
    public Text objetivodistvalue;
    public float distancia = 100;
    // Use this for initialization
    public Transform engel;
    public Transform objetivo;
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        distancia = Vector3.Distance(engel.position,objetivo.position);

        distancia= Mathf.FloorToInt(distancia);
        objetivodistvalue.text = distancia.ToString();
    }
}

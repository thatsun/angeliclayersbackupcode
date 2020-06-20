using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class c_color_material : MonoBehaviour {
    public Color color;
    public Renderer renderere;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        renderere.material.SetColor("_Color",color);

    }
}

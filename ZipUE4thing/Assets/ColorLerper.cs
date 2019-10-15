using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorLerper : MonoBehaviour {


    public Color highMalwareColor;
    public Color LowMalwareColor;
    public float nodeMalwareChance;

	// Use this for initialization
	void Start () {
       // nodeMalwareChance = .90f;//.00-1.00 (A percentage)
        GetComponent<Renderer>().material.color = Color.Lerp(LowMalwareColor, highMalwareColor, nodeMalwareChance);
    }
	
	// Update is called once per frame
	void Update () {
       
    }
}

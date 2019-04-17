using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateScript : MonoBehaviour {
    public KeyScript k;
    public bool key = false;
    public bool keyExists = true;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		//Line below seems to be causing a nullpointer exception
        if (k.turned)
        {
            Destroy(this.gameObject);
            Destroy(k.gameObject);
        }
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorScript : MonoBehaviour {
    public string nextScene = "";
	// Use this for initialization
	void Start () {
        GetComponent<Rigidbody2D>().velocity = new Vector2(-15, 0);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
private void OnCollisionEnter2D(Collision2D coll){
    if (coll.gameObject.CompareTag("Player"))
    {
        SceneManager.LoadScene(nextScene);
    }
  }
}

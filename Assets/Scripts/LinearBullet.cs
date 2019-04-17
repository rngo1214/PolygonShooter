using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinearBullet : MonoBehaviour {
    public float angle = 0.0f;
    public float moveSpeed = 25f;
	// Use this for initialization
	void Start () {
        float xvel = moveSpeed * Mathf.Cos(angle);
        float yvel = moveSpeed * Mathf.Sin(angle);
        GetComponent<Rigidbody2D>().velocity = new Vector2(xvel, yvel);
    }
	
	// Update is called once per frame
	void Update () {
        //if (transform.position.x < -50 || transform.position.x > 50 || transform.position.y > 50 || transform.position.y < -50)
        //{
        //    Destroy(this.gameObject);
        //}
    }
    public void OnCollisionEnter2D(Collision2D coll)
    {
        Destroy(this.gameObject);
    }
}

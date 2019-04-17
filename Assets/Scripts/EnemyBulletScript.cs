using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletScript : MonoBehaviour {
    public PlayerBehavior target;
    public float moveSpeed;
	// Use this for initialization
	void Start () {
        Vector3 playerPos = new Vector3(target.transform.position.x, target.transform.position.y, 0);
        Vector3 direction = (playerPos - GetComponent<Rigidbody2D>().transform.position);
        direction.z = 0;
        direction.Normalize();
        GetComponent<Rigidbody2D>().velocity = direction * moveSpeed;
    }
	public void setTarget(PlayerBehavior targ){
        target = targ;
    }
	// Update is called once per frame
	void Update () {
		//if(transform.position.x<-100 || transform.position.x>100 || transform.position.y>100 || transform.position.y < -100)
        //{
        //    Destroy(this.gameObject);
        //}
	}
    public void OnCollisionEnter2D(Collision2D coll)
    {
        Destroy(this.gameObject);
    }
}

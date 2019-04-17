using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour {
    public PlayerBehavior obj;
    public float speed;
    // Use this for initialization
    void Start () {
        Vector3 target = Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
        Vector3 playerPos = new Vector3(obj.transform.position.x, obj.transform.position.y, 0);
        Vector3 direction = target - playerPos;
        direction.z = 0;
        direction.Normalize();
        GetComponent<Rigidbody2D>().velocity = direction * speed;
        //Debug.Log(GetComponent.<Rigidbody2D>().velocity);
    }
	
	// Update is called once per frame
	void Update () {
		//if(transform.position.x<-100 || transform.position.x>100 || transform.position.y>100 || transform.position.y < -100)
        //{
        //    Destroy(this.gameObject);
        //}
	}
    private void OnCollisionEnter2D(Collision2D collision){
        Destroy(this.gameObject);
    }
}


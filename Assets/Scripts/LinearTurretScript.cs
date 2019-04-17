using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinearTurretScript : MonoBehaviour {
    public LinearBullet bul;
    public int interval=40;
    int timer;
    public float angle=0.0f;
    public float projspeed = 25f;
    // Use this for initialization
    void Start () {
        timer = 0;
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 myPos = new Vector3(transform.position.x, transform.position.y, 0);
        if (timer == 0)
        {
            LinearBullet bullet1 = Instantiate(bul, myPos, Quaternion.identity);
            bullet1.angle = angle;
            bullet1.moveSpeed = projspeed;
            timer = interval;
        }
        else
        {
            timer--;
        }
    }
}

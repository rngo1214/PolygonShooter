using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserShooter : MonoBehaviour {

    public LaserScript las;
    public int interval = 5;
    int timer;
    public float angle = 0.0f;
    public float projspeed = 25f;
    // Use this for initialization
    void Start()
    {
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 myPos = new Vector3(transform.position.x, transform.position.y, 0);
        if (timer == 0)
        {
            LaserScript laser1 = Instantiate(las, myPos, Quaternion.identity);
            laser1.angle = angle;
           // laser1.moveSpeed = projspeed;
            timer = 999999;
        }
        else
        {
            timer--;
        }
    }
}
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VelKoz : ActiveItemTemplate {
    public BulletScript template;
    BulletScript left;
    BulletScript right;
    private void Awake()
    {
        cdTime = 100;
        howLong = 200;
    }
    public override void revert()
    {
    }

    public override void use()
    {
        if (activeTime > 0)
        {
            left = Instantiate(template, p.transform.position, Quaternion.identity);
            right = Instantiate(template, p.transform.position, Quaternion.identity);
            left.obj = right.obj = p;
            activeTime = -1;
            p.itemCD = p.itemCDTime;
        }
        else if( activeTime < 0)
        {
            Vector2 leftVel = left.GetComponent<Rigidbody2D>().velocity;
            Vector2 rightVel = right.GetComponent<Rigidbody2D>().velocity;
            double leftAngle = Math.Atan(leftVel.y / leftVel.x);
            double rightAngle = Math.Atan(leftVel.y / leftVel.x);
            Debug.Log(leftAngle + "    " + rightAngle);
            double leftNewAngle = Math.Atan(leftVel.y / leftVel.x) + Math.PI / 2;
            double rightNewAngle = Math.Atan(leftVel.y / leftVel.x) - Math.PI / 2;
            Debug.Log(leftNewAngle + "    " + rightNewAngle);
            left.GetComponent<Rigidbody2D>().velocity = new Vector2((float)Math.Cos(leftNewAngle) * left.speed, (float)Math.Sin(leftNewAngle) * left.speed);
            right.GetComponent<Rigidbody2D>().velocity = new Vector2((float)Math.Cos(rightNewAngle) * left.speed, (float)Math.Sin(rightNewAngle) * left.speed);
            activeTime = 1;
        }
    }

    // Use this for initialization
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space) && activeTime < 0)
        {
            Vector2 leftVel = left.GetComponent<Rigidbody2D>().velocity;
            Vector2 rightVel = right.GetComponent<Rigidbody2D>().velocity;
            double leftAngle = Math.Atan(leftVel.y / leftVel.x);
            double rightAngle = Math.Atan(leftVel.y / leftVel.x);
            Debug.Log(leftAngle + "    " + rightAngle);
            double leftNewAngle = Math.Atan(leftVel.y / leftVel.x) + Math.PI / 2;
            double rightNewAngle = Math.Atan(leftVel.y / leftVel.x) - Math.PI / 2;
            Debug.Log(leftNewAngle + "    " + rightNewAngle);
            left.GetComponent<Rigidbody2D>().velocity = new Vector2((float) Math.Cos(leftNewAngle) * left.speed, (float) Math.Sin(leftNewAngle) * left.speed);
            right.GetComponent<Rigidbody2D>().velocity = new Vector2((float)Math.Cos(rightNewAngle) * left.speed, (float)Math.Sin(rightNewAngle) * left.speed);
            activeTime = 1;
        }
        base.Update();

    }
}

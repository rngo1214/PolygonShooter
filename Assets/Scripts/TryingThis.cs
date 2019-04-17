using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class TryingThis : MonoBehaviour
{
    public int jumpHeight = 15;
    private int jumpNum = 1;
    public int maxJumps = 1;
    public float moveSpeed = 0.1f;
    private bool facingRight = true;
    private bool movingLeft = false;
    private bool movingRight = false;
    public GameObject proj;
    private int dashnum = 0;
    private int bulletTimer = 0;
    public int bulletWaitTime = 20;
    public int iFrames = 30;
    public int hp = 5;
    public double boostMag = 2.0;
    public double modifier = 1.5;
    public int[] coor = new int[3];
    public bool grapple = false;
    // Use this for initialization
    void Start()
    {
        coor[0] = 0;
        coor[1] = 0;
        coor[2] = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (iFrames > 0)
        {
            iFrames--;
        }
        if (bulletTimer > 0)
        {
            bulletTimer--;
        }
        if (hp <= 0)
        {
            Destroy(this.gameObject);
        }
        double xvel;
        double yvel;
        if (Input.GetKey(KeyCode.W))
        {
            Vector3 tempPos = transform.position;
            tempPos.y += moveSpeed;
            transform.position = tempPos;
        }
        if (Input.GetKey(KeyCode.S))
        {
            Vector3 tempPos = transform.position;
            tempPos.y -= moveSpeed;
            transform.position = tempPos;
        }
        if (Input.GetKey(KeyCode.A))
        {
            Vector3 tempPos = transform.position;
            tempPos.x -= moveSpeed;
            transform.position = tempPos;
        }
        if (Input.GetKey(KeyCode.D))
        {
            Vector3 tempPos = transform.position;
            tempPos.x += moveSpeed;
            transform.position = tempPos;
        }
        if (Input.GetMouseButtonDown(0) && bulletTimer == 0)
        {
            Vector2 myPos = new Vector2(transform.position.x, transform.position.y);
            GameObject obj;
            GameObject projectile = Instantiate(proj, myPos, Quaternion.identity);
            Physics.IgnoreCollision(projectile.GetComponent<Collider>(), projectile.GetComponent<Collider>());
            //projectile.GetComponent.<Rigidbody2D>().velocity = (direction/direction.magnitude)*15;
        }
        Vector3 tempVel = GetComponent<Rigidbody2D>().velocity;
        tempVel.x = tempVel.x / (float)1.4f;
        tempVel.y = tempVel.y / (float)1.4f;
        //GetComponent<Rigidbody2D>().velocity.x = GetComponent<Rigidbody2D>().velocity.x/1.4;
        //GetComponent<Rigidbody2D>().velocity.y = GetComponent<Rigidbody2D>().velocity.y/1.4;
        GetComponent<Rigidbody2D>().velocity = tempVel;
    }
    public void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag("Enemy"))
        {
            if (iFrames == 0)
            {
                hp--;
                iFrames = 30;
            }
        }
    }
    public void OnCollisionExit2D(Collision2D coll)
    {
    }
    //function Flip(){
    //	var flipScale = GetComponent.<Rigidbody2D>().transform.localScale;
    //	flipScale.x *= -1;
    //	GetComponent.<Rigidbody2D>().transform.localScale = flipScale;
    //	facingRight = !facingRight;
    //}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerBehavior : MonoBehaviour
{
    private bool facingRight = true;
    private bool movingLeft = false;
    private bool movingRight = false;
    public BulletScript proj;
    private int bulletTimer = 0;
    public int bulletWaitTime = 20;
    public int iFrames = 30;
    public int hp = 5;
    int rolltime = 0;
    int rollCoolDown = 0;
    public int rollDelay = 160;
    public int rollTimeVar = 80;
    public float damage = 1.0f;
    public float moveSpeed = 0.1f;
    public int shotDelay = 1000;
    public float shotSpeed = 70.0f;
    Vector3 tempDir = new Vector3(0, 0, 0);
    public Text health;
    public int starthp = 100;
    public ActiveItemTemplate item;
    public int itemCD = 100;
    public int itemCDTime = 100;
    public bool itemActive = false;
    public int itemActiveTime;
    public int howLongItem = 0;

    // Use this for initialization
    void Start()
    {
        hp = starthp;
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (itemActive == true)
        {
            itemActiveTime --;
            if (itemActiveTime == 0)
            {
                itemActiveTime = howLongItem;
                itemActive = false;
                item.revert();
            }
        }
        else if (itemCD < itemCDTime)
            itemCD ++;
        health.text = "HP: " + hp;
        if (rolltime > 0)
        {
            rolltime--;
            GetComponent<Rigidbody2D>().velocity = tempDir * 32;
            gameObject.layer = 10;
        }
        if(rolltime == 0)
        {
            gameObject.layer = 8;
        }
        if (rollCoolDown > 0)
        {
            rollCoolDown--;
        }
        if (iFrames > 0)
        {
            GetComponent<Renderer>().material.color = Color.gray;
            iFrames--;
        }
        else
            GetComponent<Renderer>().material.color = Color.white;
        if (bulletTimer > 0)
        {
            bulletTimer--;
        }
        if (hp <= 0)
        {
            SceneManager.LoadScene("GameOver");
        }
        float xvel = GetComponent<Rigidbody2D>().velocity.x;
        float yvel = GetComponent<Rigidbody2D>().velocity.y;
        float diagMove = moveSpeed / 1.414f;
        if (Input.GetKey(KeyCode.W) && rolltime==0)
        {
            if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
                GetComponent<Rigidbody2D>().velocity = new Vector2(xvel, (diagMove));
            else
                GetComponent<Rigidbody2D>().velocity = new Vector2(xvel, moveSpeed);

        }
        else if (Input.GetKey(KeyCode.S) && rolltime == 0)
        {
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
                GetComponent<Rigidbody2D>().velocity = new Vector2(xvel, -diagMove);
            else
                GetComponent<Rigidbody2D>().velocity = new Vector2(xvel, -moveSpeed);
        }
        xvel = GetComponent<Rigidbody2D>().velocity.x;
        yvel = GetComponent<Rigidbody2D>().velocity.y;
        if (Input.GetKey(KeyCode.A) && rolltime == 0)
        {
            if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
                GetComponent<Rigidbody2D>().velocity = new Vector2(-diagMove, yvel);
            else
                GetComponent<Rigidbody2D>().velocity = new Vector2(-moveSpeed, yvel);
        }
        else if (Input.GetKey(KeyCode.D) && rolltime == 0)
        {
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
                GetComponent<Rigidbody2D>().velocity = new Vector2(diagMove, yvel);
            else
                GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed, yvel);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            
            //Activates item if you hit 'r' and the cooldown is over
            if (itemCD == itemCDTime)
            {
                itemCD = 0;
                itemActive = true;
                item.use();
            }
            //If nothing else, item cooldown will recharge
            
        }
        if (Input.GetMouseButton(0) && bulletTimer == 0)
        {
            bulletTimer = shotDelay;
            Vector2 myPos = new Vector2(transform.position.x, transform.position.y);
			//I have no idea what this does, but it seemed to be causing a warning, so I commented it out.
			//Game appears to function perfectly without it.
			//GameObject obj;
            BulletScript projectile = Instantiate(proj, myPos, Quaternion.identity);
			//Removing the line below, in the other hand, seems to cause targeting to fail.
            projectile.obj = this;
            projectile.speed = shotSpeed;            
            
        }
        if (Input.GetMouseButtonDown(1) && rolltime == 0 && rollCoolDown == 0)
        {
            rolltime = rollTimeVar;
            rollCoolDown = rollDelay;
            iFrames = rollTimeVar;
            Vector3 target = Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
            Vector3 myPoss = new Vector3(transform.position.x, transform.position.y, 0);
            Vector3 direction = target - myPoss;
            direction.z = 0;
            direction.Normalize();
            tempDir = direction;
            GetComponent<Rigidbody2D>().velocity = direction * 32;
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
        if (coll.gameObject.CompareTag("Enemy") || coll.gameObject.CompareTag("EnemyBullets"))
        {
            if (iFrames == 0)
            {
                hp--;
                iFrames = 2;
            }
        }
        if (coll.gameObject.CompareTag("Healthpack"))
        {
            if (hp < starthp*.9)
            {
                hp += starthp/10;
                Destroy(coll.gameObject);
            }
            else if (hp < starthp)
            {
                hp+= (starthp-hp);
                Destroy(coll.gameObject);
            }
        }
        if (coll.gameObject.CompareTag("ActiveItem"))
        {
            if (item != null)
                if (item.active)
                    item.revert();
           // Instantiate(item, IPos, Quaternion.identity);
            Destroy(coll.gameObject);

        }
    }
    public void OnCollisionExit2D(Collision2D coll)
    {
    }

}

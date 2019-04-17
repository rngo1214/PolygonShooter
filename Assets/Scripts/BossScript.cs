using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class BossScript : MonoBehaviour {
    public PlayerBehavior player;
    public float moveSpeed = 3.0f;
    public int hp = 70;
    public EnemyBulletScript obj;
    public int waitTime;
    public int interval;
    float angle = 0.0f;
    public LinearBullet bul;
    float mod = 1.0f;
    int modTime = 500;
    public float angleChange = 1.047f;
    public int lagTime = 100;
    int victoryTime = 100;
    public GateScript g;
    public KeyScript key;
    // Use this for initialization
    void Start () {
		player = (PlayerBehavior)FindObjectOfType(typeof(PlayerBehavior));
    }

    // Update is called once per frame
    void Update()
    {
            //Antiquated.  Keeping just in case.
       // Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, 20);
       // int i = 0;
       // while (i < hitColliders.Length)
       // {
       //     if (hitColliders[i].CompareTag("Player"))
       //         player = hitColliders[i].gameObject;
       //     i++;
       // }
        if (lagTime == 0)
        {
            Vector3 myPos = new Vector3(transform.position.x, transform.position.y, 0);
            if (hp <= 0)
            {
                KeyScript k = Instantiate(key, myPos, Quaternion.identity);
                g.k = k;
                Destroy(this.gameObject);
            }
            if (waitTime > 0)
            {
                waitTime--;
            }
            else
            {
                Vector3 playerPos = new Vector3(player.transform.position.x, player.transform.position.y, 0);
                Vector3 direction = (playerPos - GetComponent<Rigidbody2D>().transform.position);
                // EnemyBulletScript projectile = Instantiate(obj, myPos, Quaternion.identity);
                // projectile.setTarget(player);
                waitTime = interval;
                float bulletDirection = Mathf.Atan(direction.y / direction.x);
                if (direction.y >= 0 && direction.x <= 0)
                    bulletDirection += 3.141f;
                if (direction.y <= 0 && direction.x <= 0)
                    bulletDirection += 3.141f;
                LinearBullet sneaky1 = Instantiate(bul, myPos, Quaternion.identity);
                sneaky1.angle = bulletDirection + Random.Range(0.0f, 0.6f) * mod;
            }
            Vector3 playerPoss = new Vector3(player.transform.position.x, player.transform.position.y, 0);
            Vector3 directions = (playerPoss - GetComponent<Rigidbody2D>().transform.position);
            GetComponent<Rigidbody2D>().velocity = directions * moveSpeed;
            LinearBullet bullet1 = Instantiate(bul, myPos, Quaternion.identity);
            bullet1.angle = angle;
            angle += (angleChange) * mod;
            LinearBullet bullet2 = Instantiate(bul, myPos, Quaternion.identity);
            bullet2.angle = angle;
            angle += (angleChange) * mod;
            LinearBullet bullet3 = Instantiate(bul, myPos, Quaternion.identity);
            bullet3.angle = angle;
            angle += (angleChange) * mod;
            LinearBullet bullet4 = Instantiate(bul, myPos, Quaternion.identity);
            bullet4.angle = angle;
            angle += (angleChange) * mod;
            LinearBullet bullet5 = Instantiate(bul, myPos, Quaternion.identity);
            bullet5.angle = angle;
            angle += (angleChange) * mod;
            LinearBullet bullet6 = Instantiate(bul, myPos, Quaternion.identity);
            bullet6.angle = angle;
            angle += (angleChange) * mod;
            modTime--;
            if (modTime <= 0)
            {
                mod = mod * -1.00003f;
                modTime = Random.Range(200, 1000);
            }

            //Mathf.PI / 4.0f) + 0.01f
        }
        else
            lagTime--;
    }
    public void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag("PlayerBullet"))
        {
            if(lagTime == 0)
                hp--;
        }
    }
}

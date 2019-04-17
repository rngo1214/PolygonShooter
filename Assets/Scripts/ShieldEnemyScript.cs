using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldEnemyScript : MonoBehaviour
{
    public PlayerBehavior player;
    public float moveSpeed = 3.0f;
    public int hp = 7;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 playerPos = new Vector3(player.transform.position.x, player.transform.position.y, 0);
        Vector3 direction = (playerPos - GetComponent<Rigidbody2D>().transform.position).normalized;
        Quaternion lookat = Quaternion.LookRotation(playerPos);

        direction.z = 0;
        direction.Normalize();
        GetComponent<Rigidbody2D>().velocity = direction * moveSpeed;
        if (hp <= 0)
        {
            Destroy(this.gameObject);
        }
        float turnspeed = 5f;
     //   lookat = new Quaternion(0, 0, lookat.z, lookat.w);
      //  GetComponent<Rigidbody2D>().transform.rotation = Quaternion.RotateTowards(transform.rotation, lookat, Time.deltaTime*turnspeed);
        transform.rotation = lookat;

    }
    public void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag("PlayerBullet"))
        {
            hp--;
        }
    }
}



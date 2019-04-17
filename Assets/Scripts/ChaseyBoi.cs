using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseyBoi: TurretScript {
    public float moveSpeed;
	// Use this for initialization
	void Start () {
		player = (PlayerBehavior)FindObjectOfType(typeof(PlayerBehavior));
    }
	
	// Update is called once per frame
	void Update () {
        //A different way of finding the player.  Keeping it just in case.
      //  Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, 20);
      //  int i = 0;
      //  while (i < hitColliders.Length)
      //  {
      //      if (hitColliders[i].CompareTag("Player"))
      //          player = hitColliders[i].gameObject;
      //      i++;
      //  }
        if (hp <= 0)
        {
            Destroy(this.gameObject);
        }
        if (waitTime > 0)
        {
            waitTime--;
        }
        else
        {
            Vector3 myPos = new Vector3(transform.position.x, transform.position.y, 0);
            EnemyBulletScript projectile = Instantiate(obj, myPos, Quaternion.identity);
            projectile.setTarget(player);
            waitTime = interval;
        }
        Vector3 playerPos = new Vector3(player.transform.position.x, player.transform.position.y, 0);
        Vector3 direction = (playerPos - GetComponent<Rigidbody2D>().transform.position);
        direction.z = 0;
        direction.Normalize();
        GetComponent<Rigidbody2D>().velocity = direction * moveSpeed;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour {
    public PlayerBehavior player;
    public float moveSpeed = 3.0f;
    public int hp = 7;
    // Use this for initialization
    void Start (){
        player = (PlayerBehavior)FindObjectOfType(typeof(PlayerBehavior));
    }
	
	// Update is called once per frame
	void Update () {
        //Antiquated.  Keeping just in case.
       // Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, 20);
       // int i = 0;
       // while (i < hitColliders.Length)
       // {
       //     if (hitColliders[i].CompareTag("Player"))
       //         player = hitColliders[i].gameObject;
       //     i++;
       // }
		//This line causes nullpointer exceptions on entering lv. 2- Presumably, because it can't find a player
        Vector3 playerPos = new Vector3(player.transform.position.x, player.transform.position.y, 0);
        Vector3 direction = (playerPos - GetComponent<Rigidbody2D>().transform.position);
        direction.z = 0;
        direction.Normalize();
        GetComponent<Rigidbody2D>().velocity = direction * moveSpeed;
        if (hp <= 0){
            Destroy(this.gameObject);
        }
    }
    public void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag("PlayerBullet"))
        {
            hp--;
        }
    }
}



using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserScript : MonoBehaviour
{
    private PlayerBehavior p;
    public float angle = 0.0f;
    public float moveSpeed = 25f;
    private float farLeft;
    private bool hitsomething;
    // Use this for initialization
    void Start()
    {
        p = (PlayerBehavior)FindObjectOfType(typeof(PlayerBehavior));
        farLeft = transform.localPosition.x;
        // float xvel = moveSpeed * Mathf.Cos(angle);
        // float yvel = moveSpeed * Mathf.Sin(angle);
        // GetComponent<Rigidbody2D>().velocity = new Vector2(xvel, yvel);
    }

    // Update is called once per frame
    void Update()
    {
        if (!hitsomething)
        {
            transform.localScale = new Vector3(transform.localScale.x + 1, transform.localScale.y, transform.localScale.z);
            transform.localPosition = new Vector3(transform.localPosition.x + .5f, transform.localPosition.y, transform.localPosition.z);
        }
    }
    void OnTriggerEnter2D(Collider2D coll)
    {
        transform.localScale = new Vector3(coll.transform.localPosition.x - farLeft- coll.transform.localScale.x/2, transform.localScale.y, transform.localScale.z);
        transform.localPosition = new Vector3(farLeft + transform.localScale.x / 2, transform.localPosition.y, transform.localPosition.z);
        hitsomething = true;
        if (coll.gameObject.CompareTag("Player") && p.iFrames == 0)
            p.hp--;
    }
    void OnTriggerStay2D(Collider2D coll)
    {
        if (coll.gameObject.CompareTag("Player") && p.iFrames == 0)
            p.hp--;
        transform.localScale = new Vector3(coll.transform.localPosition.x - farLeft-coll.transform.localScale.x/2, transform.localScale.y, transform.localScale.z);
        transform.localPosition = new Vector3(farLeft + transform.localScale.x / 2, transform.localPosition.y, transform.localPosition.z);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        hitsomething = false;
    }
}

using System;
using UnityEngine;
public abstract class ActiveItemTemplate : MonoBehaviour {
	public PlayerBehavior p;
    //Is the item currently in use?
	public bool active = false;
    //Is this the player's current item?
	public bool trueItem = false;
	public int cooldown;
	public int activeTime;
    //How long will the item remain active when used?
    public int howLong = 50;
    //How long should we reset the cooldown to be?
    public int cdTime = 200;
	// Use this for initialization
	public void Start () {
        p = (PlayerBehavior)FindObjectOfType(typeof(PlayerBehavior));
        //Cooldown length in frames
        cooldown = cdTime;
        //Effect length in frames
        activeTime = howLong;
        gameObject.tag = "ActiveItem";

    }

    // Update is called once per frame
    public void Update () {
        //Ticks time until activity time is up, if activity time is up, turns the item off
        if (active == true)
        {
            activeTime -= 1;
            if (activeTime == 0)
            {
                activeTime = howLong;
                active = false;
                revert();
            }
        }
        //Activates item if you hit 'r' and the cooldown is over
        else if (Input.GetKeyDown(KeyCode.Space) && trueItem && cooldown == cdTime)
        {
            cooldown = 0;
            active = true;
            use();
        }
        //If nothing else, item cooldown will recharge
        else if (cooldown < cdTime)
            cooldown += 1;
	}
	//Picking up item
	public void OnCollisionEnter2D(Collision2D coll){
        if (coll.gameObject.CompareTag("Player"))
        {
            p.item = (ActiveItemTemplate)this;
            p.howLongItem = howLong;
            p.itemCDTime = cdTime;
            p.itemCD = p.itemCDTime;
            p.itemActiveTime = p.howLongItem;
            trueItem = true;
        }
    }
    //What happens when we use it?
    public abstract void use();

    //Go back to normal once it's done
    public abstract void revert();


}

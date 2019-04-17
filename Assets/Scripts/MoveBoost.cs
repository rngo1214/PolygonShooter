using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBoost : ActiveItemTemplate {


    private void Awake()
    {
        howLong = 200;
        cdTime = 200;
    }

    // Update is called once per frame

	public override void use(){
		Debug.Log ("Item Used Correctly");
		p.moveSpeed += 20;
	}
	public override void revert(){
		Debug.Log ("Item Ended Correctly");
		p.moveSpeed -= 20;
	}
}

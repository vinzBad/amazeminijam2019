using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : Entity {

	// Use this for initialization
	public override void init(){
        base.init();
    }
	
	// Update is called once per frame
	protected override void update(){
		wander();
	}

	void wander() {
		
	}
}

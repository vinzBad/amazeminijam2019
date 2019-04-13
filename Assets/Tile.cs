using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : Entity {

    public enum Type
    {
        WALKABLE,
        FREE,
        BLOCKED,
        GOAL
    }

    public Type currentType = Type.FREE;

	// Use this for initialization
	public override void init(){
        base.init();
    }
	
	// Update is called once per frame
	protected override void update(){
		
	}
}

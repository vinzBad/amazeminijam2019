using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TileState
{
	FREE,
	WALKABLE,
	BLOCKED,
	GOAL
}

public class Tile : Entity {
	public TileState State = TileState.FREE;

    public int x = 0;
    public int y = 0;

    // Use this for initialization
    public override void init(){
        base.init();
    }
	
	// Update is called once per frame
	protected override void update(){
		
	}
}

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
	// Use this for initialization
	public override void init(){

	}
	
	// Update is called once per frame
	protected override void update(){
		
	}
}

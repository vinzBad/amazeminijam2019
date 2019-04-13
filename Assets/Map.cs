using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : Entity {

    public Camera mainCam;
    public GameObject floor;

    public Tile[,] content;

	// Use this for initialization
	public override void init(){
        base.init();

        this.mainCam.gameObject.transform.position = new Vector3(0.0f, Level.TILESIZE * (Level.MAPHEIGHT / 2.0f), -10.0f);

        this.floor.transform.position = new Vector3(0.0f, Level.TILESIZE, 0.0f);
        this.floor.transform.localScale = new Vector3(Level.TILESIZE * Level.MAPWIDTH, 1.0f, 1.0f);

        this.content = new Tile[Level.MAPHEIGHT, Level.MAPWIDTH];
	}
	
	// Update is called once per frame
	protected override void update(){
		
	}
}

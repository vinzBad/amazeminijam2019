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
		debugDrawMap();
	}

	void OnDrawGizmos() {
		debugDrawMap();
	}

	void debugDrawMap() {
		var start = new Vector3();
		var end = new Vector3();

		// always skip the first line for better looks
		for(int rowIndex = 1; rowIndex < Level.MAPHEIGHT; rowIndex++) {
			start = new Vector3(0, rowIndex * Level.TILESIZE, 0);
			end = new Vector3(Level.TILESIZE * Level.MAPWIDTH, rowIndex * Level.TILESIZE, 0);
			Debug.DrawLine(start, end);
		}
		for(int colIndex = 1; colIndex < Level.MAPWIDTH; colIndex++) {
			start = new Vector3(colIndex * Level.TILESIZE,0, 0);
			end = new Vector3(colIndex * Level.TILESIZE, Level.MAPHEIGHT * Level.TILESIZE, 0);
			Debug.DrawLine(start, end);
		}
	}
}

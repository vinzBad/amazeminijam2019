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

        this.content = new Tile[Level.MAPHEIGHT, Level.MAPWIDTH];
        for (var i = 0; i < Level.MAPHEIGHT; i++)
        {
            for (var j = 0; j < Level.MAPWIDTH; j++)
            {
                GameObject newTile = (GameObject)Instantiate(this.level.resources[0]);
                this.content[i, j] = newTile.GetComponent<Tile>();
                this.content[i, j].x = i;
                this.content[i, j].y = j;
            }
        }

        this.mainCam.gameObject.transform.position = new Vector3(0.0f, Level.TILESIZE * (Level.MAPHEIGHT / 2.0f), -10.0f);

        this.floor.transform.position = new Vector3(0.0f, Level.TILESIZE, 0.0f);
        this.floor.transform.localScale = new Vector3(Level.TILESIZE * Level.MAPWIDTH, 1.0f, 1.0f);
	}

    public Tile getTileAt(int coorX, int coorY)
    {
        Tile result = null;

        for (var i = 0; i < Level.MAPHEIGHT; i++)
        {
            for (var j = 0; j < Level.MAPWIDTH; j++)
            {
                if (this.content[i,j].x == coorX && this.content[i, j].y == coorY)
                {
                    result = this.content[i, j];
                    break;
                }
            }
        }

        return result;
    }
	
	// Update is called once per frame
	protected override void update(){
		
	}
}

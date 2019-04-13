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

	void OnGUI()
    {
        debugDrawMapLabels();
    }

	void debugDrawMapLabels() {
		var worldPosition = new Vector3();
		var screenPosition = new Vector3();
		var labelDimensions = mainCam.WorldToScreenPoint(new Vector3(Level.TILESIZE, Level.TILESIZE, Level.TILESIZE));

		// always skip the first line for better looks
		for(int rowIndex = 0; rowIndex < Level.MAPHEIGHT; rowIndex++) {
			for(int colIndex = 0; colIndex < Level.MAPWIDTH; colIndex++) {
				worldPosition = new Vector3(colIndex * Level.TILESIZE, rowIndex * Level.TILESIZE, 0);
				screenPosition = mainCam.WorldToScreenPoint(worldPosition);
				
				GUI.Label(new Rect(screenPosition.x, screenPosition.y, labelDimensions.x, labelDimensions.y), this.content[rowIndex, colIndex].State.ToString());
			}
		}
		
	}
}

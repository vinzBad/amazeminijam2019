using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : Entity {

    public int x = 0;
    public int y = 0;

    public bool landed = false;

	// Use this for initialization
	public override void init(){
        base.init();

        this.gameObject.transform.position = new Vector3(this.x * Level.TILESIZE, (Level.TILESIZE * Level.MAPHEIGHT), 0.0f);

        StartCoroutine(this.updateMove());
	}
	
	// Update is called once per frame
	protected override void update(){
		
	}

    public void rotateLeft()
    {
        this.gameObject.transform.Rotate(new Vector3(0.0f, 0.0f, 90.0f), Space.World);
    }

    public void rotateRight()
    {
        this.gameObject.transform.Rotate(new Vector3(0.0f, 0.0f, -90.0f), Space.World);
    }

    private IEnumerator updateMove()
    {
        while (this.level.map == null)
        {
            yield return new WaitForEndOfFrame();
        }

        bool continued = true;

        while (continued)
        {
            if (!this.landed)
            {
                this.gameObject.transform.position += Vector3.down * Level.TILESIZE;
                this.y++;

                if(this.y == Level.MAPHEIGHT - 1)
                {
                    this.landed = true;
                }

                Tile tileBelow = this.level.map.getTileAt(this.x, this.y + 1);
                if (tileBelow != null && tileBelow.State != TileState.FREE)
                {
                    this.landed = true;
                }
            }

            if (!this.level.accelerate) {
                yield return new WaitForSeconds(Level.BLOCKSMOVELOOPRATE);
            }
            else
            {
                yield return new WaitForSeconds(Level.BLOCKSMOVELOOPRATE / 10.0f);
            }
        }
    }
}

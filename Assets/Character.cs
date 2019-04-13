using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : Entity
{

    public int rowIndex = 0;
    public int colIndex = 0;

    public Tile currentTile;

    public SpriteRenderer spriteRenderer;

    public Sprite[] sprites;
    public string currentAnimation = "idle";
    public int currentIndex = 0;
    public Sprite[] currentAnim;

    // Use this for initialization
    public override void init()
    {
        base.init();

        this.gameObject.transform.position = new Vector3(Level.TILESIZE * (Level.MAPWIDTH/2.0f), (Level.TILESIZE * 1.0f), -1.0f) + Block.fixOffset;
    }

    // Update is called once per frame
    protected override void update()
    {
        switch (this.level.currentStatus)
        {
            case GameStatus.Playing:
                this.currentTile = this.level.map.getTileAt(this.rowIndex, this.colIndex);
                wander();
                if (this.currentTile.State == TileState.GOAL)
                {
                    this.level.gameWon();
                }

                this.gameObject.transform.position += this.walkingDirection * 1.0f * Time.deltaTime;
                break;
        }
    }

    public void setAnimation(string animationName)
    {
        switch(animationName)
        {
            case "idle":
                this.currentAnim = new Sprite[]
                {
                    this.sprites[0]
                };
                break;
            case "goingRight":
                this.currentAnim = new Sprite[]
                {
                    this.sprites[0],this.sprites[1],this.sprites[2],this.sprites[3]
                };
                break;
            case "goingUp":
                this.currentAnim = new Sprite[]
                {
                    this.sprites[0],this.sprites[1],this.sprites[2],this.sprites[3]
                };
                break;
            case "goingDown":
                this.currentAnim = new Sprite[]
                {
                    this.sprites[0],this.sprites[1],this.sprites[2],this.sprites[3]
                };
                break;
            case "peeing":
                this.currentAnim = new Sprite[]
                {
                    this.sprites[0],this.sprites[1],this.sprites[2],this.sprites[3]
                };
                break;
            case "peeingLoop":
                this.currentAnim = new Sprite[]
                {
                    this.sprites[0],this.sprites[1],this.sprites[2],this.sprites[3]
                };
                break;
        }
    }

    public IEnumerator handleAnimation()
    {
        bool continued = true;

        while (continued)
        {
            this.currentIndex++;
            if (this.currentIndex > this.currentAnim.Length)
            {
                this.currentIndex = 0;
            }

            this.spriteRenderer.sprite = this.currentAnim[this.currentIndex];
            yield return new WaitForSeconds(1.0f);
        }
    }

    Vector3 walkingDirection = Vector3.zero;
    void wander()
    {
        walkingDirection = getWalkingDir(walkingDirection);
		Debug.DrawLine(this.gameObject.transform.position, this.gameObject.transform.position + walkingDirection);

    }

    Vector3 getWalkingDir(Vector3 currentDirection)
    {
        // get current tile
        var current = this.tileAtWorldPos(this.gameObject.transform.position);

        // look to the left when we are walking to the left
        if (currentDirection.x <= 0)
        {
			// Debug.Log("Walking to the left");
            var leftNeighbor = tileAtIndices(current.rowIndex, current.colIndex - 1);
            if (leftNeighbor != null)
            {
                if (leftNeighbor.State == TileState.WALKABLE || leftNeighbor.State == TileState.GOAL)
                {
                    return Vector3.left;
                }
                else if (leftNeighbor.State == TileState.BLOCKED)
                {
                    return Vector3.right;
                }
                else
                {
                    return Vector3.left;
                }
            }
            else
            { // we are at the edge of the map
                return Vector3.right;
            }
        } else {
			// we are walking to the right 
			var rightNeighbor = tileAtIndices(current.rowIndex, current.colIndex + 1);
            if (rightNeighbor != null)
            {
                if (rightNeighbor.State == TileState.WALKABLE || rightNeighbor.State == TileState.GOAL)
                {
                    return Vector3.right;
                }
                else if (rightNeighbor.State == TileState.BLOCKED)
                {
                    return Vector3.left; // bounce
                }
                else
                {
                    return Vector3.right;
                }
            }
            else
            { // we are at the edge of the map
                return Vector3.left;
            }
		}

    }

    Tile tileAtWorldPos(Vector3 pos)
    {
		//Debug.Log(pos);
        var rowIndex = (int)(Level.TILESIZE * Level.MAPHEIGHT - pos.y / Level.TILESIZE);
        var colIndex = (int)(pos.x / Level.TILESIZE);
		// Debug.Log(rowIndex + ", " + colIndex);
        return tileAtIndices(rowIndex, colIndex);
    }

    Tile tileAtIndices(int rowIndex, int colIndex)
    {
        if (areIndicesInsideMap(rowIndex, colIndex))
            return level.map.content[rowIndex, colIndex];
        return null;
    }
    bool areIndicesInsideMap(int rowIndex, int colIndex)
    {
        return rowIndex >= 0 && rowIndex < Level.MAPHEIGHT && colIndex >= 0 && colIndex < Level.MAPWIDTH;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : Entity {

    public int rowIndex = 0;
    public int colIndex = 0;

    public Tile currentTile;

    public SpriteRenderer spriteRenderer;

    public Sprite[] sprites;
    public string currentAnimation = "idle";
    public int currentIndex = 0;
    public Sprite[] currentAnim;

    // Use this for initialization
    public override void init(){
        base.init();

        this.gameObject.transform.position = new Vector3(Level.TILESIZE * (Level.MAPWIDTH/2.0f), (Level.TILESIZE * 1.0f), -1.0f) + Block.fixOffset;
    }
	
	// Update is called once per frame
	protected override void update(){
        switch (this.level.currentStatus)
        {
            case GameStatus.Playing:
                this.currentTile = this.level.map.getTileAt(this.rowIndex, this.colIndex);

                if (this.currentTile.State == TileState.GOAL)
                {
                    this.level.gameWon();
                }
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
}

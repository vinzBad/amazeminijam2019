using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : Entity
{

    public int rowIndex = 0;
    public int colIndex = 0;

    public Tile currentTile;

    // Use this for initialization
    public override void init()
    {
        base.init();
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
                break;
        }
    }

    void wander()
    {

    }

}

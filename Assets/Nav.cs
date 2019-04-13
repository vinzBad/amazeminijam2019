using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Nav : Entity
{

    Map map;

    public override void init()
    {
        base.init();
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    protected override void update()
    {
        var map = this.level.map;
        if (Input.GetMouseButtonDown(0))
        {
            var mouseScreenPosition = Input.mousePosition;
            var mouseWorldPosition = map.mainCam.ScreenToWorldPoint(mouseScreenPosition);
            var rowIndex = (int)(Level.TILESIZE * Level.MAPHEIGHT - mouseWorldPosition.y / Level.TILESIZE);
            var colIndex = (int)(mouseWorldPosition.x / Level.TILESIZE);

            if (rowIndex >= 0 && rowIndex < Level.MAPHEIGHT)
            {
                if (colIndex >= 0 && colIndex < Level.MAPWIDTH)
                {
                    var tile = map.content[rowIndex, colIndex];
                    if (tile.State == TileState.BLOCKED)
                        tile.State = TileState.FREE;
                    else if (tile.State == TileState.FREE)
                        tile.State = TileState.GOAL;
                    else if (tile.State == TileState.GOAL)
                        tile.State = TileState.WALKABLE;
                    else if (tile.State == TileState.WALKABLE)
                        tile.State = TileState.BLOCKED;
                }
            }
        }

    }
}

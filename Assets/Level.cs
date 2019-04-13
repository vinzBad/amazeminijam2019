using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : Entity
{
    public static int MAPHEIGHT = 10;
    public static int MAPWIDTH = 3;

    public static float BLOCKSMOVELOOPRATE = 1.0f;//In seconds

    public static float TILESIZE = 1.0f;

    public List<Block> blocks = new List<Block>();
    public Block activeBlock;

    public bool accelerate = false;

    // Use this for initialization
    public override void init()
    {
        base.init();
    }

    // Update is called once per frame
    protected override void update()
    {
        if(this.activeBlock != null)
        {
            if(Input.GetKeyDown(KeyCode.UpArrow))
            {

            }

            if (Input.GetKeyUp(KeyCode.DownArrow))
            {
                this.accelerate = false;
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                this.accelerate = true;
            }

            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                this.activeBlock.rotateLeft();
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                this.activeBlock.rotateRight();
            }
        }
    }
}

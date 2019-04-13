using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : Entity
{
    public static int MAPHEIGHT = 10;
    public static int MAPWIDTH = 3;

    public static float BLOCKSMOVELOOPRATE = 1.0f;//In seconds

    public static float TILESIZE = 1.0f;

    public Object[] resources;

    public Map map;
    public List<Block> blocks = new List<Block>();
    public Block activeBlock;

    public bool accelerate = false;

    // Use this for initialization
    public override void init()
    {
        base.init();

        this.map = GameObject.FindObjectOfType<Map>();

        this.spawnBlock(Level.MAPWIDTH / 2);
    }

    // Update is called once per frame
    protected override void update()
    {
        if(this.activeBlock != null)
        {
            if(Input.GetKeyDown(KeyCode.UpArrow))
            {
                this.activeBlock.rotateLeft();
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
                
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                //this.activeBlock.rotateRight();
            }
        }
    }

    public void spawnBlock(int i)
    {
        GameObject blockPrefab = (GameObject)Instantiate(this.resources[1]);
        Block block = blockPrefab.GetComponent<Block>();

        this.blocks.Add(block);

        block.y = i;
        block.init();

        this.activeBlock = block;
    }
}

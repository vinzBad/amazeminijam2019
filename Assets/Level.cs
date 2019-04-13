using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameStatus
{
    Playing,
    GameWon,
    GameOver
}

public class Level : Entity
{
    public static int MAPHEIGHT = 10;
    public static int MAPWIDTH = 6;

    public static float BLOCKSMOVELOOPRATE = 1.0f;//In seconds

    public static float TILESIZE = 1.0f;

    public static float TIMERMAXIMUM = 30.0f;//In seconds - reach goal before this time length

    public Object[] resources;

    public GameStatus currentStatus = GameStatus.Playing;

    public UI ui;

    public Map map;
    public List<Block> blocks = new List<Block>();
    public Block activeBlock;

    public bool accelerate = false;

    public float timer = 0.0f;//In seconds

    // Use this for initialization
    public override void init()
    {
        base.init();

        this.map = GameObject.FindObjectOfType<Map>();

        this.timer = Level.TIMERMAXIMUM;

        this.spawnBlock(Level.MAPWIDTH / 2);
    }

    // Update is called once per frame
    protected override void update()
    {
        switch (this.currentStatus)
        {
            case GameStatus.Playing:
                this.timer -= Time.deltaTime;
                if (this.timer <= 0.0f)
                {
                    this.gameOver();
                }

                if (this.activeBlock != null)
                {
                    if (Input.GetKeyDown(KeyCode.UpArrow))
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
                        this.activeBlock.moveLeft();
                    }
                    else if (Input.GetKeyDown(KeyCode.RightArrow))
                    {
                        this.activeBlock.moveRight();
                    }

                    if (Input.GetKeyDown(KeyCode.LeftControl))
                    {
                        this.activeBlock.rotateLeft();
                    }
                    else if (Input.GetKeyDown(KeyCode.LeftAlt))
                    {
                        this.activeBlock.rotateRight();
                    }
                }
                break;
            case GameStatus.GameOver:
                break;
        }
    }

    public void spawnBlock(int i)
    {
        int randomIndex = Random.Range(2, 6);

        GameObject blockPrefab = (GameObject)Instantiate(this.resources[randomIndex]);
        Block block = blockPrefab.GetComponent<Block>();

        this.blocks.Add(block);

        block.y = i;
        block.init();

        this.activeBlock = block;
    }

    public void gameWon()
    {
        this.currentStatus = GameStatus.GameWon;
        this.ui.handleGameWon();
    }

    public void gameOver()
    {
        this.currentStatus = GameStatus.GameOver;
        this.ui.handleGameOver();
    }
}

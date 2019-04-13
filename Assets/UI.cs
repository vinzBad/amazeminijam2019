using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : Entity
{
    public GameObject timerContent;
    public GameObject gameOverPanel;
    public GameObject gameWonPanel;

    // Use this for initialization
    public override void init()
    {
        base.init();
    }

    // Update is called once per frame
    protected override void update()
    {
        this.timerContent.GetComponent<RectTransform>().anchorMax = new Vector2((this.level.timer/Level.TIMERMAXIMUM), 1.0f);
        this.timerContent.GetComponent<RectTransform>().anchoredPosition = Vector3.zero;
    }

    public void handleGameWon()
    {
        this.gameWonPanel.SetActive(true);
    }

    public void handleGameOver()
    {
        this.gameOverPanel.SetActive(true);
    }
}

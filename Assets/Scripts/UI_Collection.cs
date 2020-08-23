using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Collection
{
    private GameObject ui_canvas;
    private Text ui_topText;
    private GameObject ui_retryButton;
    private GameObject ui_nextLevelButton;

    public UI_Collection ()
    {
        ui_canvas = GameObject.Find("Canvas");
        ui_topText = GameObject.Find("TopText").GetComponent<Text>();
        ui_retryButton = GameObject.Find("RetryButton");
        ui_nextLevelButton = GameObject.Find("NextLevelButton");
        DeactivateCanvas();
    }

    public void ActivateCanvas ()
    {
        ui_canvas.SetActive(true);
    }

    public void DeactivateCanvas ()
    {
        ui_canvas.SetActive(false);
    }

    public void RetryButton (bool status)
    {
        ui_retryButton.SetActive(status);
    }

    public void NextLevelButton (bool status)
    {
        ui_nextLevelButton.SetActive(status);
    }

    public void SetTopText (string text)
    {
        ui_topText.text = text;
    }
}

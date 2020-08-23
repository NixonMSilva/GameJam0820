using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Collection
{
    private GameObject ui_canvas;
    private Text ui_topText;
    private Text ui_buttonText;

    public UI_Collection ()
    {
        ui_canvas = GameObject.Find("Canvas");
        Debug.Log(GameObject.Find("TopText"));
        ui_topText = GameObject.Find("TopText").GetComponent<Text>();
        ui_buttonText = GameObject.Find("ButtonText").GetComponent<Text>();
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

    public void SetTopText (string text)
    {
        ui_topText.text = text;
    }

    public void SetButtonText (string text)
    {
        ui_buttonText.text = text;
    }
}

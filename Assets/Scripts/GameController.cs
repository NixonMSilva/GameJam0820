using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    private UI_Collection userInterface;

    private void Awake ()
    {
        userInterface = new UI_Collection();
        ResumeTime();
    }

    private void Start ()
    {
        GameEvent.current.onPlayerVictory += PlayerVictory;
        GameEvent.current.onEnemyVictory += EnemyVictory;
    }

    private void PlayerVictory ()
    {
        StartCoroutine(StopTimeCooldown());
        userInterface.SetTopText("Victory!");    
        userInterface.NextLevelButton(true);
        userInterface.RetryButton(false);
        userInterface.ActivateCanvas();
    }

    private void EnemyVictory ()
    {
        StartCoroutine(StopTimeCooldown());
        userInterface.SetTopText("Defeat!");
        userInterface.RetryButton(true);
        userInterface.NextLevelButton(false);
        userInterface.ActivateCanvas();
    }

    private void OnDestroy ()
    {
        GameEvent.current.onPlayerVictory -= PlayerVictory;
        GameEvent.current.onEnemyVictory -= EnemyVictory;
    }

    IEnumerator StopTimeCooldown ()
    {
        yield return new WaitForSeconds(0.15f);
        StopTime();
    }

    private void StopTime ()
    {
        Time.timeScale = 0f;
    }

    private void ResumeTime ()
    {
        Time.timeScale = 1f;
    }
}

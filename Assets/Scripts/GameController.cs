using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    private UI_Collection userInterace;

    private void Awake ()
    {
        userInterace = new UI_Collection();
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
        userInterace.SetTopText("Victory!");    
        userInterace.ActivateCanvas();    
    }

    private void EnemyVictory ()
    {
        StartCoroutine(StopTimeCooldown());
        userInterace.SetTopText("Defeat!");
        userInterace.ActivateCanvas();
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

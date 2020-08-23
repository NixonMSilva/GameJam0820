using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvent : MonoBehaviour
{

    public static GameEvent current;

    private void Awake ()
    {
        current = this;
    }

    public event Action onPlayerVictory;
    public event Action onEnemyVictory;

    public void PlayerVictory ()
    {
        if (onPlayerVictory != null)
        {
            onPlayerVictory();
        }
    }

    public void EnemyVictory ()
    {
        if (onEnemyVictory != null)
        {
            onEnemyVictory();
        }
    }
}

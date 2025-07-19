using System; 
using UnityEngine;

public static class GameEventManager
{
    public static event Action OnGameOver;

    public static void TriggerGameOver()
    {
        OnGameOver?.Invoke();
    }
}

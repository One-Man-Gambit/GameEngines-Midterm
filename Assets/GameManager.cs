using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager
{

    // ==============SINGLETON==================

    private static GameManager instance;   
    public static GameManager GetInstance() 
    {
        if (instance == null) 
        {
            instance = new GameManager();
        }

        return instance;
    }

    // =========================================

    private float baseShootingSpeed = 1.0f;
    private float shootingSpeed = 1.0f;

    public delegate void OnBossKilledDelegate();
    public OnBossKilledDelegate OnBossKilled;

    public BossBehavior BossRef;
    public Controller PlayerRef;

    private void Start() 
    {
        OnBossKilled += WinGame;
    }

    public void WinGame() 
    {
        Debug.Log("Game Has Been Won");
    }

    public float GetShootingSpeed() 
    {
        return shootingSpeed;
    }

    // Modify shooting speed by a percentage
    public IEnumerator ModifiyShootingSpeed(float amount, float duration)
    { 
        shootingSpeed -= baseShootingSpeed * amount;    // Reduce time between each shot
        yield return new WaitForSeconds(duration);
        shootingSpeed += baseShootingSpeed * amount;    // Return back to normal
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBehavior : MonoBehaviour
{
    public float Health = 100.0f;

    private void Start() 
    {
        GameManager.GetInstance().BossRef = this;
    }

    public void DealDamage(float damage) 
    {
        Health -= damage;
        UI.GetInstance().UpdateUI();

        if (Health <= 0) {
            GameManager.GetInstance().OnBossKilled?.Invoke();
            Destroy(gameObject);
        }
    }
}

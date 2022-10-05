using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    // ==============SINGLETON==================
    
    private static UI instance;
    public static UI GetInstance() 
    {
        return instance;
    }

    // =========================================

    public GameObject GameUI, WinUI;
    public Image BossHealthBar;

    private void Awake() 
    {
        if (instance == null) {
            instance = this;
        } else {
            Destroy(this.gameObject);
        }
    }

    private void Start() 
    {
        GameManager.GetInstance().OnBossKilled += OnWin;
    }

    public void UpdateUI() 
    {
        BossHealthBar.fillAmount = GameManager.GetInstance().BossRef.Health / 100.0f; // 100.0f represents the starting health of the boss.  Should be replaced with a variable
    }

    public void OnWin() 
    {
        GameUI.SetActive(false);
        WinUI.SetActive(true);
    }
}

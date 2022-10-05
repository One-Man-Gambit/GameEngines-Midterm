using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BellPowerup : MonoBehaviour
{
    public float AttackSpeedModifier = 0.5f;
    public float BuffDuration = 6.0f;
    
    public SpriteRenderer sprite1, sprite2;

    public void Activate() 
    {        
        GetComponent<BoxCollider2D>().isTrigger = true;        
        
        // Generate random color
        Color c = Color.white;
        int r = Random.Range(0, 3);
        if (r == 0) c = Color.red;
        if (r == 1) c = Color.blue;
        if (r == 2) c = Color.green;

        sprite1.color = c;
        sprite2.color = c;

        // Can change the functionality of the powerup based on color generated 
        // For now, all bells, regardless of color, will just increase attack speed
    }

    public void Use(Controller user) 
    {        
        user.StartCoroutine(GameManager.GetInstance().ModifiyShootingSpeed(AttackSpeedModifier, BuffDuration));
        Destroy(gameObject);
    }
}

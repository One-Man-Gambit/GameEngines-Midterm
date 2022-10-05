using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private float lifetime = 6.0f;
    public float ProjectileSpeed = 1.0f;
    public float Damage = 5.0f;

    private void Update() 
    {
        // Movement - 1 directional, always going up like in Twin Bee
        transform.position += Vector3.up * ProjectileSpeed * Time.deltaTime;

        // Counter for Lifetime
        lifetime -= Time.deltaTime;
        if (lifetime <= 0) {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.gameObject.tag == "Enemy") 
        {
            BossBehavior enemyScript = other.gameObject.GetComponent<BossBehavior>();
            enemyScript.DealDamage(Damage);
            Destroy(gameObject);
        }

        if (other.gameObject.tag == "Collectible") 
        {
            BellPowerup powerupScript = other.gameObject.GetComponent<BellPowerup>();
            powerupScript.Activate();
            Destroy(gameObject);
        }
    }
}

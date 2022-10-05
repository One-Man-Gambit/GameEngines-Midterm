using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public KeyCode ShootKey = KeyCode.Space;
    private bool canShoot = true;
    private float shootDelayTimer = 0.0f;

    public GameObject ProjectilePrefab;
    public Transform ProjectileOrigin;

    public float MovementSpeed = 1.0f;

    private bool HasWon = false;

    private void Start() 
    {
        GameManager.GetInstance().PlayerRef = this;
        GameManager.GetInstance().OnBossKilled += OnWin;        
    }

    private void Update() 
    {   
        if (HasWon) {
            transform.Rotate(0, 0, 45 * Time.deltaTime);
            return;
        }

        // Handle Movement
        Move();

        // Handle Shooting
        if (Input.GetKey(ShootKey)) {            
            Shoot();
        }

        // Delay Shooting
        if (shootDelayTimer > 0 && canShoot == false) {
            shootDelayTimer -= Time.deltaTime;            
        } else if (shootDelayTimer < 0) {
            shootDelayTimer = 0.0f;
            canShoot = true;
        }
    }

    private void Move() 
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(x, y, 0);
       
        transform.position += direction * MovementSpeed * Time.deltaTime;
    }

    private void Shoot() 
    {
        if (!canShoot) return;

        GameObject projetile = Instantiate(ProjectilePrefab, ProjectileOrigin.position, Quaternion.identity);   
        shootDelayTimer = GameManager.GetInstance().GetShootingSpeed();  
        canShoot = false;   
    }   

    public void OnWin() 
    {
        HasWon = true;
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        Debug.Log("Trigger Entered");

        if (other.gameObject.tag == "Collectible") 
        {
            BellPowerup powerup = other.gameObject.GetComponent<BellPowerup>();
            powerup.Use(this);        
        }    
    }
}

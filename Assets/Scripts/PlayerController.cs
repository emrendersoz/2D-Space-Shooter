using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public GameOverScript GameOverScreen;
    public float speed = 5f;
    public int bullet;
    public Text ammoDisplay;
    bool canAttack;
    public float minY, maxY;
    [SerializeField]
    GameObject playerBullet, playerBullet2;
    [SerializeField]
    Transform attackPoint;

   
    public void GameOver()
    {
        GameOverScreen.Setup(bullet);
    }

    private void Update()
    {
        ammoDisplay.text = bullet.ToString() + " /10";
    }
    public void Attack()
    {
        if (bullet > 0)
        {
            Instantiate(playerBullet2, attackPoint.position, Quaternion.identity);
            bullet--;
        }
    }
    public void Attack2()
    {
        Instantiate(playerBullet, attackPoint.position, Quaternion.identity);
    }

    private void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "Enemy" || target.tag == "Bullet")
        {
            Time.timeScale = 0f;
            GameOver();
        }

    }
}


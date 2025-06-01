using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public static float scaleSpeed = .25f; //20 -> +5f speed
    public static float speed = 7f;
    public float rotateSpeed = 50f;
    public bool canShoot;
    public bool canRotate;
    public bool canMove = true;
    public float boundX = -11f;
    public float health = 100f;
    public Transform attackPoint;
    public GameObject laserPrefab;
    Animator anim;
    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    private void Update()
    {
        Move();
        Rotate();
    }
    private void Start()
    {
        if (canRotate)
        {
            if (Random.Range(0, 2) > 0)
            {
                rotateSpeed = Random.Range(rotateSpeed, rotateSpeed + 20f);
                rotateSpeed *= -1f;
            }
            else
            {
                rotateSpeed = Random.Range(rotateSpeed, rotateSpeed + 20f);
            }
        }
        if (canShoot)
            Invoke("Shooting", Random.Range(1f, 3f));
    }
    void Move()
    {
        if (canMove)
        {
            Vector3 temp = transform.position;
            temp.x -= (speed+scaleSpeed) * Time.deltaTime;
            transform.position = temp;
            if (temp.x < boundX)
                gameObject.SetActive(false);
        }
    }
    void Rotate()
    {
        if (canRotate)
        {
            transform.Rotate(new Vector3(0f, 0f, rotateSpeed * Time.deltaTime), Space.World);
        }
    }
    void Shooting()
    {
        GameObject bullet = Instantiate(laserPrefab, attackPoint.position, Quaternion.identity);
        bullet.GetComponent<LaserScript>().isEnemyBullet = true;
        if (canShoot)
            Invoke("Shooting", Random.Range(1f, 3f));
    }

    private void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "Bullet")
        {
            health -= 34;
        }
        if (health <= 0 || target.tag=="YellowBullet")
        {
            Score.scoreValue += 1;
            Destroy(gameObject);
            scaleSpeed += .25f;
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserScript : MonoBehaviour
{
    public float speed = 5f;
    public float destroyTime = .1f;
    [HideInInspector]
    public bool isEnemyBullet = false;
    private void Start()
    {
        if (isEnemyBullet)
            speed *= -1f;
        Invoke("DestroyGameObject", destroyTime);

    }
    private void Update()
    {
        Move();
    }
    void Move()
    {
        Vector3 temp = transform.position;
        temp.x += speed * Time.deltaTime;
        transform.position = temp;
    }
    void DestroyGameObject()
    {
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "Bullet" || target.tag == "Enemy")
        {
            Destroy(gameObject);
        }
    }
}

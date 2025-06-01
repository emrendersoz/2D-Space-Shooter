using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bgScroll : MonoBehaviour
{
    public float speed = 5f;
    private Vector3 startPosition;
    private void Start()
    {
        startPosition = transform.position;
    }
    private void Update()
    {
        transform.Translate(translation: Vector3.left * speed * Time.deltaTime);
        if (transform.position.x < -15f)
        {
            transform.position = startPosition;
        }
    }
}

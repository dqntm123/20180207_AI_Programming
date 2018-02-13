using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBullet : MonoBehaviour
{

    public float bulletSpeed;
    void Start()
    {
        Destroy(gameObject, 2.0f);
    }

    void Update()
    {
        transform.Translate(0, 0, bulletSpeed);
    }
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour {

    public int bulletSpeed;

    void Update()
    {
        transform.Translate(0, 0, bulletSpeed * Time.deltaTime);
        Destroy(gameObject, 2f);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TTower : MonoBehaviour {

    public float fireCool;
    public float fireDelay;
    public GameObject bullet;
    public Transform firePosition;
    public List<GameObject> lookObj;
    public float rotationSpeed = 60.0f;
    void Start()
    {

    }

    void Update()
    {
        if (lookObj.Count > 0)
        {
            if (lookObj[0] != null)
            {
                Vector3 dir = lookObj[0].transform.position - transform.position;
                dir.y = 0.0f;
                dir.Normalize();
                transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(dir), rotationSpeed * Time.deltaTime);
                fireCool += Time.deltaTime;

                if (fireCool > fireDelay)
                {
                    fireCool = 0;
                    GameObject towerBullet = Instantiate(bullet) as GameObject;
                    firePosition.transform.LookAt(lookObj[0].transform);
                    towerBullet.transform.position = firePosition.position;
                    towerBullet.transform.localRotation = firePosition.rotation;
                }
            }
            else
            {
               lookObj.RemoveAt(0);
            }
        }
	}

    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Enemy")
        {
            //Debug.Log(col.name);
            lookObj.Add(col.gameObject);
        }
     
    }

    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            //Debug.Log(col.name);
            lookObj.Remove(col.gameObject);
        }
    }
}

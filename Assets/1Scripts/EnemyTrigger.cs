using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTrigger : MonoBehaviour {

    private void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "EnemyGoal")
        {
           
            Destroy(gameObject);
        }
        if (col.gameObject.tag == "Bullet")
        {
            Debug.Log("총알 맞음 ");
            Destroy(gameObject);

        }
    }
}

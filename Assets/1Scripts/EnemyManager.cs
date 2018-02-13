using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour {

    public float respawnCool;
    public float respawnDelay;
    public GameObject enemy;
    public Transform enemyPosition;
    public int enemyCnt;

	void Start ()
    {
		
	}
	
	void Update ()
    {
        respawnCool += Time.deltaTime;
     
        if(respawnCool > respawnDelay)
            
        {
            respawnCool = 0;
            enemyCnt++;
            GameObject instanceEnemy = Instantiate(enemy) as GameObject;
            instanceEnemy.name = "Enemy_" + enemyCnt;
            instanceEnemy.transform.position = enemyPosition.position;
            instanceEnemy.GetComponent<CrowdAgent>().target = GameObject.FindGameObjectWithTag("EnemyGoal").transform;
        }
	}
}

using UnityEngine;
using System.Collections;

//using UnityEngine.AI;   -- 상단에 삽입하고 아래 문단의 코드를 사용해야 함

//[RequireComponent(typeof(NavMeshAgent))]
//public class CrowdAgent : MonoBehaviour
//{

//    public Transform target;

//    private NavMeshAgent agent;

//    void Start()
//    {
//        agent = GetComponent<NavMeshAgent>();
//        agent.speed = Random.Range(4.0f, 5.0f);
//        agent.SetDestination(target.position);
//    }

//}


[RequireComponent(typeof(UnityEngine.AI.NavMeshAgent))]
public class CrowdAgent : MonoBehaviour {
       
    public Transform target;

    private UnityEngine.AI.NavMeshAgent agent;

	void Start () {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        agent.speed = Random.Range(5.0f, 4.0f);
        agent.SetDestination(target.position);
	}
	
}


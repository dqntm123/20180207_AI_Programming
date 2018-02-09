using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;//네비메쉬를 사용할때는 이 부분을 적어주어야된다.

public class TankAi : MonoBehaviour {

    private GameObject player;
    private Animator animator;
    private Ray ray;//엑스레이 선
    private RaycastHit hit;//그선에 맞은애
    private float maxDistanceToCheck = 6f;//체크할수있는 최대치의 거리값
    private float currentDistance;//현재거리를 의미 
    private Vector3 checkDirection;//체크해야될 좌표값

    public Transform pointA;
    public Transform pointB;
    public NavMeshAgent navMeshAgent;//Agent는 인공지능이 달려잇는 객체를 의미한다.

    private int currentTarget;//현재타겟
    private float distanceFromTarget;//타겟과의 거리
    private Transform[] waypoints = null;

    private void Awake()//Awake는 Start보다 먼저 실행되는함수,시작전에 초기화값을 넣어주고 할때 주로 사용함
    {
        player = GameObject.FindWithTag("Player");//플레이어가 누군지 찾아라
        animator = gameObject.GetComponent<Animator>();//애니메이터를 가져와서 찾아주겟다
        pointA = GameObject.Find("p1").transform;
        pointB = GameObject.Find("p2").transform;
        navMeshAgent = gameObject.GetComponent<NavMeshAgent>();//네비매쉬가 누군지 알려줘야됨
        waypoints = new Transform[2]{ pointA,pointB};//아래 스크립트와 같은 의미
        //waypoints = new Transform[2];
        //waypoints[0] = pointA;
        //waypoints[1] = pointB;
        currentTarget = 0;
        navMeshAgent.SetDestination(waypoints[currentTarget].position);
        //퍼블릭으로 선언한 네비매쉬에이전트의 경로값을 매순간 업데이트 해준다는의미
    }
    private void FixedUpdate()
    {
        currentDistance = Vector3.Distance(player.transform.position, transform.position);
        animator.SetFloat("distanceFromPlayer", currentDistance);

        checkDirection = player.transform.position - transform.position;//플레이어 위치에 현재나의 위치를 뺀값을 접목시킨다.
        ray = new Ray(transform.position, checkDirection);//레이안에다가 현재 나의 위치값과 플레이어 위치값으로 레이를 쏜다 
        if(Physics.Raycast(ray,out hit,maxDistanceToCheck))
        {//
            if(hit.collider.gameObject==player)
            {
                animator.SetBool("isPlayerVisible", true);//ray에 부딫힌 오브젝트가 플레이어일경우
                //애니메이터에 셋불의 이름값인"isPlayerVisible"가 트루로 선언한다.
            }
            else
            {
                animator.SetBool("isPlayerVisible", false);
            }
        }
        else
        {
            animator.SetBool("isPlayerVisible", false);
        }

        distanceFromTarget = Vector3.Distance(waypoints[currentTarget].position, transform.position);
        animator.SetFloat("distanceFromWayPoint", distanceFromTarget);
    }

    public void SetNextPoint()
    {
        switch (currentTarget)
        {
            case 0:
                currentTarget = 1;
                break;
            case 1:
                currentTarget = 0;
                break;
        }
        navMeshAgent.SetDestination(waypoints[currentTarget].position);
    }
}

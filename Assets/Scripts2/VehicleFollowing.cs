using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleFollowing : MonoBehaviour {

    public Path path;//Path 가 누군지 알려준다.
    public float speed = 20f;
    public float mass = 5f;
    public bool isLooping = true;

    private float curSpeed;
    private int curPathindex;//현재의 값을 의미
    private float pathLength;
    private Vector3 targetPoint;

    Vector3 velocity;

    void Start()
    {
        pathLength = path.length;
        curPathindex = 0;//0값부터 시작하는걸로 초기화시킴
        velocity = transform.forward;//시작점 위치를 z축을 기준으로 시작한다는의미.
    }
    void Update()
    {
        curSpeed = speed * Time.deltaTime;
        targetPoint = path.getPoint(curPathindex);
        if (Vector3.Distance(transform.position, targetPoint) < path.radius)//현재 포지션에서 다음 타겟포인트의 거리가 2보다 작아진다면
        {
            if (curPathindex < pathLength - 1) curPathindex++;
            //인덱스값은 시작이0 이고 패스랭쓰의 배열값은 6으로 선언햇기때문에 0이 5보다 작아질때까지 인덱스값을 계속 더해준다는 의미
            else if (isLooping) curPathindex = 0;//isLooping값이 트루일때 인덱스값을 0으로 되돌린다.
            else return;
        }
        if (curPathindex >= pathLength) return;//인덱스 값이 패스렝스값보다 커지거나 같아진다면 다시 되돌린다.
        if (curPathindex >= pathLength - 1 && !isLooping)//인덱스값이 패스렝스에 1을 뺸값 그리고 isLooping이 폴스라면
            velocity += Steer(targetPoint, true);
        else velocity += Steer(targetPoint);

        transform.position += velocity;
        transform.rotation = Quaternion.LookRotation(velocity);//바라보는 방향으로 고정시켜준다.
    }
    public Vector3 Steer(Vector3 target, bool bFinalpoint = false)
    {
        Vector3 desiredVelocity = (target - transform.position);
        float dist = desiredVelocity.magnitude;
        desiredVelocity.Normalize();
        if (bFinalpoint && dist < 10f) desiredVelocity *= (curSpeed * (dist / 10f));
        else desiredVelocity *= curSpeed;
        Vector3 steeringForce = desiredVelocity - velocity;
        Vector3 acceleration = steeringForce / mass;

        return acceleration;
    }
}

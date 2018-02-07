using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Perspective : Sense {

    public int FieldOfView = 45;
    public int ViewDistance = 100;

    private Transform playerTrans;
    private Vector3 rayDirection;

    protected override void Initialize()
    {
        playerTrans = GameObject.FindGameObjectWithTag("Player").transform;
    }
    protected override void UpdateSense()
    {
        elapsedTime += Time.deltaTime;
        if (elapsedTime >= detectionRate)
        DetectAspect();
    }
    void DetectAspect()
    {
        RaycastHit hit;
        rayDirection = playerTrans.position - transform.position;
        if((Vector3.Angle(rayDirection,transform.forward))<FieldOfView)
        { //레이다이렉션값과 현재 위치z값이 필드오브뷰보다 작을때(Angle은 각도를 측정하는 함수)
            if(Physics.Raycast(transform.position,rayDirection,out hit,ViewDistance))
            {
                Aspect aspect = hit.collider.GetComponent<Aspect>();//맞은애가 누구인지 확인하기위한 함수
                if(aspect !=null)
                {
                    if(aspect.aspectName == aspectName)//아스펙트 네임이 아스펙트네임과 같다면 (Sense 에 선언한 아스펙트네임값음 에너미)
                    {
                        print("Enemy Detected");
                    }
                }
            }
        }
    }
    void OnDrawGizmos()
    {
        if (playerTrans == null) return;
        Debug.DrawLine(transform.position, playerTrans.position, Color.red);
        Vector3 frontRayPoint = transform.position + (transform.forward * ViewDistance);

        Vector3 leftRayPoint = frontRayPoint;
        leftRayPoint.x += FieldOfView * 0.5f;

        Vector3 rightRayPoint = frontRayPoint;
        rightRayPoint.x -= FieldOfView * 0.5f;

        Debug.DrawLine(transform.position, frontRayPoint, Color.green);
        Debug.DrawLine(transform.position, leftRayPoint, Color.green);
        Debug.DrawLine(transform.position, rightRayPoint, Color.green);
    }
}

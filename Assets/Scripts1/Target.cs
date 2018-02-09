using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour {

    public Transform targetMarker;

    void Update()
    {
        int button = 0;//0은 왼쪽버튼 1은 가운데 휠 2는 오른쪽버튼
        if(Input.GetMouseButtonDown(button))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);//카메라에서 레이를 쏘는데 내가 찍은위치로 쏜다.
            RaycastHit hitInfo;//찍은순간 히트를 받는다.
            if(Physics.Raycast(ray.origin,ray.direction,out hitInfo))//origin은 내가쏜방향 ,레이의방향 을 out hitinfo로 받는다.
            {
                Vector3 targetPosition = hitInfo.point;//타겟포지션의 위치값을 hitinfo의 포지션값으로 받는다.
                targetMarker.position = targetPosition;//타겟마커 포지션을 타겟포지션으로 받는다.
            }
        }
    }
}

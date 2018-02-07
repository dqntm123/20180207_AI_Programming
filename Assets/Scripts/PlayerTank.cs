using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTank : MonoBehaviour {

    public Transform targetTransform;
    private float movementSpeed;
    private float rotSpeed;

    void Start()
    {
        movementSpeed = 10f;//스피드값을10으로 초기화
        rotSpeed = 3f;
        targetTransform = GameObject.Find("Target").transform;
    }

    void Update()
    {
        if (Vector3.Distance(transform.position, targetTransform.position) < 2.5f)//위치가 3보다 작을경우 동작을 하지않게한다.
            return;
        Vector3 tarPos = targetTransform.position;//벡터3 의 타겟포지션값안에 타겟의 위치값을 넣는다.
        tarPos.y = transform.position.y;
        Vector3 dirRot = tarPos - transform.position;

        Quaternion tarRot = Quaternion.LookRotation(dirRot);
        transform.rotation = Quaternion.Slerp(transform.rotation, tarRot, rotSpeed * Time.deltaTime);
        transform.Translate(new Vector3(0, 0, movementSpeed * Time.deltaTime));//돌아간 방향으로 이동한다.
    }
}

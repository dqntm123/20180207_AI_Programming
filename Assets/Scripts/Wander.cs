using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wander : MonoBehaviour {

    public Vector3 tarPos;

    private float movementSpeed = 5f;
    private float rotSpeed = 2f;
    private float minX, maxX, minZ, maxZ;

    void Start()
    {
        minX = -45f;
        maxX = 45f;
        minZ = -45f;
        maxZ = 45f;

        GetNextPosition();
    }
    void Update()
    {
        if(Vector3.Distance(tarPos,transform.position)<=5f)//벡터3의 디스턴스의 타겟포지션과 현재 포지션값이 5보다 작거나 같다면
        GetNextPosition();//이 함수를 호출한다

        Quaternion tarRot = Quaternion.LookRotation(tarPos - transform.position);

        transform.rotation = Quaternion.Slerp(transform.rotation, tarRot, rotSpeed * Time.deltaTime);//방향을 돌릴때 사용 (Slerp)

        transform.Translate(new Vector3(0, 0, movementSpeed * Time.deltaTime));//방향을 돌린후 그방향으로 이동
        
    }
    void GetNextPosition()
    {
        tarPos = new Vector3(Random.Range(minX, maxX), 0.5f, Random.Range(minZ, maxZ));
    }
}

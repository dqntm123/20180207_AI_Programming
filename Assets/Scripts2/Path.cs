using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path : MonoBehaviour {

    public bool bDebug = true;
    public float radius = 2f;
    public Vector3[] pointA;

    public float length
    {
        get
        {
            return pointA.Length;
        }
    }
    public Vector3 getPoint(int index)//인자로 받은 인트의 인덱스 값을 벡터3의 겟포인트값으로 선언한다.
    {
        return pointA[index];//반환한다 포인트A안에 있는 배열 index 값을
    }
    void OnDrawGizmos()
    {
        if (!bDebug) return;

        for (int i = 0; i < pointA.Length; i++)//배열을 정한숫자만큼 더해준다
        {
            if(i+1<pointA.Length)//처음 i값에 1을 더한 값이 배열보다 작을때까지
            {
                Debug.DrawLine(pointA[i], pointA[i + 1], Color.red);//포인트A의 첫번째 배열에서 포인트A의 그다음 배열순으로 빨간색선을 그린다
            }
        }
    }
}

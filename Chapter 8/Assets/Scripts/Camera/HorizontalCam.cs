using UnityEngine;
using System.Collections;

//카메라의 목표지점을 모든 축에 대해 현재 위치와 모두 동일하게 설정했다.
//다만 이후 목표 지점의 Z축을 우리의 타깃과 동일하게 재지정했다.
//인스펙터를 보면 탱크의 트랜스폼으로 설정된 것을 볼 수 있다. 
// 이후 선형 보간법(Vector3.Lerp)을 사용해서 부드럽게 카메라를 현재위치에서 목표위치로 매 프레임 이동시키면 된다. 
public class HorizontalCam : MonoBehaviour {
    [SerializeField]
    private Transform target;

    private Vector3 targetPositon;

    private void Update() {
        targetPositon = transform.position;
        targetPositon.z = target.transform.position.z;
        transform.position = Vector3.Lerp(transform.position, targetPositon, Time.deltaTime);
    }
}

using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

    //bullet 게임 오브젝트는 단순하다. 단지 밝은 노란색 구 형태일 뿐이다.
    //여기에 구 형태의 콜라이더가 연결돼 있다. 
    // Is Trigger가 true여야 하고 연결된 Rigidbody(gravity는 off)를 가져야 한다. 
    //bullet 프리팹에 연결된 Projectile 컴포넌트도 가져야 한다.  이는 충돌 로직을 처리하는데 코드로 살펴보자.

    [SerializeField]
    private GameObject explosionPrefab;

	void Start () {	}

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Player" || other.tag == "Environment") {
            if (explosionPrefab == null) {
                return;
            }
            GameObject explosion = Instantiate(explosionPrefab, transform.position, Quaternion.identity) as GameObject;
            Destroy(this.gameObject);            
        }
    }
}
//스크립트는 매우 직관적이다. 
//우리지형에서 모든 바닥과 벽은 "Environment"라는 태그를 달고 있으므로 OnTriggerEnter 메소드에서 포탄이 플레이어 또는 환경과 충돌했는지 검사한다. 
//만일 충돌했다면 explosion 프리팹을 인스턴스화하고 포탄을 소멸시킨다. 

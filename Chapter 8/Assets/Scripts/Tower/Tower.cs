using UnityEngine;
using System.Collections;

public class Tower : MonoBehaviour {
    [SerializeField]
    private Animator animator;

    [SerializeField]//fireSpeed, fireCounter, canFire 3개 모두 타워의 발사 로직과 관련이 있다. 
    private float fireSpeed = 3f;
    private float fireCounter = 0f;
    private bool canFire = true;

    [SerializeField]
    private Transform muzzle;
    [SerializeField]
    private GameObject projectile;

    private bool isLockedOn = false;//isLockedOn은 LockedOn을 통해서 얻고 설정할 수 있다. 

    public bool LockedOn {
        get { return isLockedOn; }
        set { isLockedOn = value; }
    }

    private void Update() {
        if (LockedOn && canFire) {
            StartCoroutine(Fire());
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Player") {
            animator.SetBool("TankInRange", true);
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.tag == "Player") {
            animator.SetBool("TankInRange", false);
        }
    }

    private void FireProjectile() {
        GameObject bullet = Instantiate(projectile, muzzle.position, muzzle.rotation) as GameObject;
        bullet.GetComponent<Rigidbody>().AddForce(muzzle.forward * 300);
    }

    private IEnumerator Fire() {
        canFire = false;
        FireProjectile();
        while (fireCounter < fireSpeed) {
            fireCounter += Time.deltaTime;
            yield return null;
        }
        canFire = true;
        fireCounter = 0f;
    }
}
//타워 로직을 구현하는데 필요한 모든 메소드와 필수요소를 갖췄으며, Update 루프 안에서 2가지를 검사하면 된다.
// 목표물을 발견했는가? 목표물에 발사할 수 있는가?
//두 조건이 모두 참이면 Fire() 코루틴을 사용해서 발사하면 된다.
//OnTrigger 메시지를 살펴보기 전에 왜 Fire()를 코루틴으로 만드는지 살펴볼 것이다. 
// 우리는 타워가 탱크를 향해 미친 발사 기계처럼 무한히 발사하길 원하지는 않기 때문에 앞에서 정의한 변수를 사용해서 각 발사간에 간격을 두기로 하자. 
//FireProjectile()을 호출한 후 canFire를 false로 설정하고 0부터 fireSpeed까지 카운트를 센후 다시 canFire를 true로 설정하면 된다. 
//FireProjectile() 메소드는 포탄의 인스턴스화와 Rigidbody.AddForce를 사용한 발사를 처리한다.  실제 총알 로직은 다른 곳에서 처리하는데 나중에 살펴보자.
//마지막으로 2개의 OnTrigger 이벤트가 있다. 
//하나는 이 컴포넌트에 연결된 트리거에 진입할때이며 나머지는 이 트리거를 떠날때다. 
//TankInRange 불 변수가 상태기계의 상태 전이를 유도한다는 걸 기억할 필요가 있다.
// 이 변수는 트리거에 진입할 때 true가 되고 떠날때 false가 된다.  
//기본적으로 탱크가 총의 구 영역인 시야에 들어오면 즉각적으로 탱크를 조준하고 탱크가 영역을 벗어나면 더 이상 탱크를 추적하지 않는다. 

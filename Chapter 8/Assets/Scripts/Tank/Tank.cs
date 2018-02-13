using UnityEngine;
using System.Collections;

public class Tank : MonoBehaviour {
    //하나의 목적을 갖는 에이전트다. 목적은 미로의 끝에 도달하는 것이다.
    //플레이어는 탱크가 길을 따라 이동하면서 능력을 활용해 타워의 포격으로부터 벗어나 안전하게 이동하도록 해야 한다. 

    [SerializeField]
    private Transform goal;
    private UnityEngine.AI.NavMeshAgent agent;
    [SerializeField]
    private float speedBoostDuration = 3;
    [SerializeField]
    private ParticleSystem boostParticleSystem;
    [SerializeField]
    private float shieldDuration = 3f;
    [SerializeField]
    private GameObject shield;

    private float regularSpeed = 3.5f;
    private float boostedSpeed = 7.0f;
    private bool canBoost = true;
    private bool canShield = true;

    // 조작을 쉽게 하려면 다양한 값이 필요하므로 각 변수부터 선언한다.
    // 능력의 지속시간부터 이와 관련한 이펙트를 우선 설정한다.

    private bool hasShield = false;

    //Start 메소드는 탱크를 위한 약간의 설정을 처리한다. NavMeshAgent 컴포넌트를 가지고 목적지를 우리의 목적지 변수와 동일하게 만든다. 
    //탱크이 능력 기능 입력을 캐치하기 위해 Update 메소드를 사용한다. 
    //B는 boost, S는 shield로 설정했다. 타워의 발사기능과 마찬가지로 시간 제한이 있는 능력이므로 코루틴을 사용해서 구현했다.
    private void Start() {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        agent.SetDestination(goal.position);
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.B)) {
            if (canBoost) {
                StartCoroutine(Boost());
            }
        }
        if (Input.GetKeyDown(KeyCode.S)) {
            if (canShield) {
                StartCoroutine(Shield());
            }
        }
    }

    private IEnumerator Shield() {
        canShield = false;
        shield.SetActive(true);
        float shieldCounter = 0f;
        while (shieldCounter < shieldDuration) {
            shieldCounter += Time.deltaTime;
            yield return null;
        }
        canShield = true;
        shield.SetActive(false);
    }

    private IEnumerator Boost() {
        canBoost = false;
        agent.speed = boostedSpeed;
        boostParticleSystem.Play();
        float boostCounter = 0f;
        while (boostCounter < speedBoostDuration) {
            boostCounter += Time.deltaTime;
            yield return null;
        }
        canBoost = true;
        boostParticleSystem.Pause();
        agent.speed = regularSpeed;
    }
}
// 두 능력의 로직은 매우 유사하다. 
//shield는 우리가 인스펙터에 정의한 변수인 shield 게임 오브젝트를 활성화하거나 비활성화한다.
//그리고 shieldDuration만큼의 시간이 흐른 후 이를 비활성화시키고 다시 플레이어가 shield를 사용할 수 있게 한다.
//Boost 코드의 가장 큰 차이는 게임오브젝트를 활성화하거나 비활성화하는 것이 아니며, 
//boost는 인스펙트를 통해 지정한 파티클 시스템의 play를 호출하고 NaavMeshAgent의 속도를 2배로 일정시간 동안 유지한다는 점이다. 
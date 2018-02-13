using UnityEngine;
using System.Collections;

public class ExplosionState : StateMachineBehaviour {

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    //OnStateEnter는 전환이 시작되고 상태 시스템이이 상태를 평가하기 시작할 때 호출됩니다.
    //override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    //
    //}

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    //OnStateUnit은 OnStateEnter 콜백과 OnStateExit 콜백 사이의 각 Update 프레임에서 호출됩니다.
    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    //
    //}

    //------------------------------------------------------------------------
    //IsTrigger가 true인 구 콜라이더가 있다. 가장 큰 차이는 animator 컴포넌트다. 
    //이 explosion이 인스턴스화되면 폭발처럼 확장된다. 그리고 상태기계를 사용해서 폭발 상태가 끝나면 인스턴스를 제거한다. 

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    // 상태 전이가 끝나면 OnStateExit가 호출되고, 상태 기계는 이 상태 평가를 종료한다.
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        Destroy(animator.gameObject, 0.1f);
    }
    //애니메이션이 끝났을때 상태를 벗어나면서 오브젝트의 인스턴스를 제거하는 일이다. 

    //------------------------------------------------------------------------

    // OnStateMove is called right after Animator.OnAnimatorMove(). 
    //OnStateMove는 Animator.OnAnimatorMove () 직후에 호출됩니다.
    // Code that processes and affects root motion should be implemented here
    // 루트 모션을 처리하고 영향을주는 코드를 여기에 구현해야합니다.
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    //
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK(). Code that sets up animation IK (inverse kinematics) should be implemented here.
    //OnStateIK는 Animator.OnAnimatorIK () 직후에 호출됩니다. 애니메이션 IK (inverse kinematics)를 설정하는 코드를 여기에 구현해야합니다.
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    //
    //}
}

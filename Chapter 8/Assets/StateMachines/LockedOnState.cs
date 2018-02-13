using UnityEngine;
using System.Collections;

public class LockedOnState : StateMachineBehaviour {

    GameObject player;
    Tower tower;

	 // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
     //OnStateEnter는 상태 전이가 시작될때 호출되고 상태기계는 이 상태를 평가하기 시작한다. 
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        player = GameObject.FindWithTag("Player");
        tower = animator.gameObject.GetComponent<Tower>();
        tower.LockedOn = true;
    }

     //OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
     //OnStateUpdate는 OnStateEnter와 OnStateExit 콜백 사이에서 매 Update 프레임에 호출된다. 
	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        animator.gameObject.transform.LookAt(player.transform);
	}

	// OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //OnStateExit는 상태전이가 끝나고 상태 기계가 이 상태에 대한 평가를 마쳤을때 호출된다. 
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        animator.gameObject.transform.rotation = Quaternion.identity;
        tower.LockedOn = false;
    }
}

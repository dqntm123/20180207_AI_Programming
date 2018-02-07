using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankPatrolState : StateMachineBehaviour {

	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) 
    {
        TankAi tankAi = animator.gameObject.GetComponent<TankAi>();
        tankAi.SetNextPoint();
    }
    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    //base.OnStateUpdate(nimator,statinfo,layerindex)
    //}
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    //base.OnStateExit(nimator,statinfo,layerindex)
    //}
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    //base.OnStateMove(nimator,statinfo,layerindex)
    //}
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    //base.OnStateIK(nimator,statinfo,layerindex)
    //}
}

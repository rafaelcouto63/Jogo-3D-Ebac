using UnityEngine;
using System.Collections;
using System.Collections.Generic;



public class FSMExample : MonoBehaviour
{
    public enum ExempleEnum
    {
        STATE_ONE,
        STATE_TWO,
        STATE_THREE
    }


    public StateMachine<ExempleEnum> stateMachine;

    public void Start()
    {
        stateMachine = new StateMachine<ExempleEnum>();
        stateMachine.Init();
        stateMachine.RegisterStates(ExempleEnum.STATE_ONE, new StateBase());
        stateMachine.RegisterStates(ExempleEnum.STATE_TWO, new StateBase());
    }
}

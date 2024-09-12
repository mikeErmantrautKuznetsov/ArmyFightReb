using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class StateMachinePlayer
{
    public State IStateCurrent { get; set; }

    public void firstState(State EnterState)
    {
        IStateCurrent = EnterState;
        IStateCurrent.Enter();
    }

    public void finishState(State ExitState)
    {
        IStateCurrent.Exit();
        IStateCurrent = ExitState;
        IStateCurrent.Enter();
    }
}

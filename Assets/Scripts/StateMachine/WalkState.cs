using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkState : State
{
    public void EnterWalk(State state)
    {
        state.Enter();
        Debug.Log("I Walk!!!");
    }

    public void ExitWalk(State state)
    {
        state.Exit();
        Debug.Log("I DON Walk!!!");
    }
}

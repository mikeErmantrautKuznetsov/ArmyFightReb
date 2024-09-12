using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankState : State
{
    public void EnterTank(State state)
    {
        state.Enter();
        Debug.Log("� � �����");
    }

    public void ExitTank(State state) 
    { 
        state.Exit();
        Debug.Log("� ������� ���k");
    }

    public void UpdateTank(State state)
    {
        state.Update();
        Debug.Log("I Tank");
    }
}

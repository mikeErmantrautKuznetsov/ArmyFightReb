using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerChangeState : MonoBehaviour
{
    private StateMachinePlayer _stateMachinePlayer;
    private RunState _runState;
    [SerializeField]
    private GameObject tankActive;
    [SerializeField]
    private GameObject personActive;
    [SerializeField]
    private Transform playerMain;
    private PlayerMovement playerMovement;
    private TankMoveRaed tankMoveRaed;
    private TankPlayerMove tankPlayerMove;
    [SerializeField]
    private GameObject mainCamera;
    private bool isTank = true;

    void Start()
    {
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
        tankMoveRaed = GetComponent<TankMoveRaed>();
        tankPlayerMove = GetComponent<TankPlayerMove>();
        playerMovement = GetComponent<PlayerMovement>();
        _stateMachinePlayer = new StateMachinePlayer();
        _stateMachinePlayer.firstState(new IdleState());
        _stateMachinePlayer = GetComponent<StateMachinePlayer>();
        _runState = GetComponent<RunState>();
    }

    void Update()
    {
        _stateMachinePlayer.IStateCurrent.Update();

        if (Input.GetKey(KeyCode.W) || (Input.GetKey(KeyCode.S)))
        {
            EventBus.Run?.Invoke();
            _stateMachinePlayer.finishState(new RunState());
        }
        else if (Input.GetKey(KeyCode.A) || (Input.GetKey(KeyCode.D)))
        {
            EventBus.Run?.Invoke();
            _stateMachinePlayer.finishState(new RunState());
        }

        else if (Input.GetKey(KeyCode.Space))
        {
            EventBus.Jump?.Invoke();
            _stateMachinePlayer.finishState(new JumpState());
        }

        else if (Input.GetMouseButton(0))
        {
            EventBus.Shoot?.Invoke();
            _stateMachinePlayer.finishState(new ShootState());
        }

        else if (Input.GetKeyDown(KeyCode.C) && isTank == true)
        {
            Debug.Log("I'm Person");
            _stateMachinePlayer.finishState(new IdleState());
            OnDisable();
            isTank = false;
        }

        else if (Input.GetKeyDown(KeyCode.G) && isTank == false)
        {
            Debug.Log("I'm Tank");
            _stateMachinePlayer.finishState(new TankState());
            OnEnable();
            isTank = true;
        }

        else
        {
            EventBus.Idle?.Invoke();
            _stateMachinePlayer.finishState(new IdleState());
        }
    }

    private void OnEnable()
    {
        mainCamera.SetActive(true);
        personActive.SetActive(true);
        tankActive.SetActive(false);
        playerMovement.enabled = true; 
        tankMoveRaed.enabled = false;
        tankPlayerMove.enabled = false;
    }

    private void OnDisable()
    {
        tankActive.SetActive(true);
        mainCamera.SetActive(false);
        personActive.SetActive(false);
        playerMovement.enabled = false;
        tankMoveRaed.enabled = true;
        tankPlayerMove.enabled = true;
    }
}

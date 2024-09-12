using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AnimationController : MonoBehaviour
{
    private Animator animatorPlayer;

    private void Start()
    {
        animatorPlayer = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        EventBus.Run += RunPlayer;
        EventBus.Idle += IdlePlayer;
        EventBus.Jump += JumpPlayer;
        EventBus.Shoot += ShootPlayer;
    }

    private void OnDisable()
    {
        EventBus.Run -= RunPlayer;
        EventBus.Idle -= IdlePlayer;
        EventBus.Jump -= JumpPlayer;
        EventBus.Shoot -= ShootPlayer;
    }

    public void RunPlayer()
    {
        animatorPlayer.SetBool("IsShoot", false);
        animatorPlayer.SetBool("IsIdle", false);
        animatorPlayer.SetBool("IsJump", false);
        animatorPlayer.SetBool("IsRun", true);
    }

    public void IdlePlayer()
    {
        animatorPlayer.SetBool("IsRun", false);
        animatorPlayer.SetBool("IsShoot", false);
        animatorPlayer.SetBool("IsJump", false);
        animatorPlayer.SetBool("IsIdle", true);
    }

    public void JumpPlayer()
    {
        animatorPlayer.SetBool("IsRun", false);
        animatorPlayer.SetBool("IsIdle", false);
        animatorPlayer.SetBool("IsShoot", false);
        animatorPlayer.SetBool("IsJump", true);
    }

    public void ShootPlayer()
    {
        animatorPlayer.SetBool("IsRun", false);
        animatorPlayer.SetBool("IsIdle", false);
        animatorPlayer.SetBool("IsJump", false);
        animatorPlayer.SetBool("IsShoot", true);
    }
}

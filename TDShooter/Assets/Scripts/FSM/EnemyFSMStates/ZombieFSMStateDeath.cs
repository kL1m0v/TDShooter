using System.Collections;
using System.Collections.Generic;
using TopDownShooter;
using UnityEngine;

public class ZombieFSMStateDeath : EnemyFSMStateBase
{
    public ZombieFSMStateDeath(FSM fsm, Animator animator, EnemyBase enemyBase, AudioSource audioSource) : base(fsm, animator, enemyBase, audioSource) { }
    
    public override void Enter() 
    {
        _animator.SetInteger("NumState", (int)NumStateAnimation.Death);
        _audioSource.clip = _enemyBase.GetAudioClip("Death");
        _audioSource.Play();
    }
}

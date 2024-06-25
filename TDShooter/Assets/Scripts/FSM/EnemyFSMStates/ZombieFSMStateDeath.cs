using System.Collections;
using System.Collections.Generic;
using TopDownShooter;
using UnityEngine;

public class ZombieFSMStateDeath : EnemyFSMStateBase
{
    public ZombieFSMStateDeath(FSM fsm, Animator animator) : base(fsm, animator) { }
    
    public override void Enter() 
    {
        _animator.SetInteger("NumState", (int)NumStateAnimation.Death);
    }
}

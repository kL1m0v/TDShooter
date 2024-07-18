using System.Collections;
using System.Collections.Generic;
using TopDownShooter;
using Unity.VisualScripting;
using UnityEngine;

public static class Extensions 
{
    public static float GetDistanceToPlayer(this EnemyBase enemy)
    {
        return Vector3.Distance(enemy.transform.position, PlayerManager.PlayerPosition);
    }
}

public enum NumStateAnimation
{
    Idle,
    Move,
    Attack,
    Death,
    SpetialAttack
}

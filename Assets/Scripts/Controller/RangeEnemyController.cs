using System;
using UnityEngine;

public class RangeEnemyController : EnemyController
{
    [SerializeField][Range(0f, 100f)] private float followRange = 15f;
    [SerializeField][Range(0f, 100f)] private float shootRange = 10f;

    private int layerMaskTarget;

    protected override void Start()
    {
        base.Start();
        // TODO :: CharacterStat.cs 추가
        // layerMaskTarget = stats.CurrentStat.attackSO.target;
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        float distanceToTarget = DistanceToTarget();
    }
}
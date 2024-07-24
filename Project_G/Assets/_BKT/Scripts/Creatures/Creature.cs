using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creature : BaseObject
{
    #region Stat
    public float Speed { get; protected set; } = 1.0f;
    public float Hp { get; protected set; } = 100.0f; 
    #endregion

    public Define.ECreatureType CreatureType { get; protected set; } = Define.ECreatureType.None;
    protected Define.ECreatureState _creatureState = Define.ECreatureState.None;
    public Define.ECreatureState CreatureState 
    {
        get { return _creatureState; }
        set 
        {
            _creatureState = value;
        }
    }

    public override bool Init()
    {
        if (base.Init() == false)
            return false;

        ObjectType = Define.EObjectType.Creature;

        Collider.isTrigger = true;
        Rigidbody.isKinematic = false;
        Rigidbody.useGravity = false;

        return true;
    }

    public virtual void SetInfo() 
    {
        Hp = 100.0f;

        // 상태에 따른 동작 시작
        StartCoroutine(CoUpdateState());
        // 셀 좌표 이동 시작
        StartCoroutine(CoLerpToCellPos());
    }

    #region UpdateState
    public float UpdateStateTick { get; protected set; } = Define.UpdateStateTick;

    protected IEnumerator CoUpdateState()
    {
        while (true)
        {
            switch (CreatureState)
            {
                case Define.ECreatureState.Idle:
                    UpdateIdle();
                    break;
                case Define.ECreatureState.Move:
                    UpdateMove();
                    break;
                case Define.ECreatureState.Die:
                    UpdateDie();
                    break;
            }

            if (UpdateStateTick > 0)
                yield return new WaitForSeconds(UpdateStateTick);
            else
                yield return null;
        }
    }

    protected virtual void UpdateIdle() { }
    protected virtual void UpdateMove() {/*Debug.Log($"{this.name} UpdateMove");*/}
    protected virtual void UpdateDie() { }
    #endregion

    // 오브젝트 탐색
    protected BaseObject FindClosestObject(IEnumerable<BaseObject> objs)
    {
        BaseObject target = null;
        float bestDistanceSqr = float.MaxValue;

        foreach (BaseObject obj in objs)
        {
            Vector3 dir = obj.transform.position - transform.position;
            float distToTargetSqr = dir.sqrMagnitude;

            // 이미 더 좋은 후보를 찾았으면 스킵.
            if (distToTargetSqr > bestDistanceSqr)
                continue;

            target = obj;
            bestDistanceSqr = distToTargetSqr;
        }

        return target;
    }

    #region Map
    public bool LerpCellPosCompleted { get; protected set; }

    Vector3Int _cellPos;
    public Vector3Int CellPos
    {
        get { return _cellPos; }
        protected set
        {
            _cellPos = value;
            LerpCellPosCompleted = false;
        }
    }

    public void SetCellPos(Vector3Int cellPos, bool forceMove = false)
    {
        CellPos = cellPos;
        LerpCellPosCompleted = false;

        if (forceMove)
        {
            transform.position = Managers.Map.Cell2World(CellPos);
            LerpCellPosCompleted = true;
        }
    }

    public void LerpToCellPos(float moveSpeed)
    {
        if (LerpCellPosCompleted)
            return;

        Vector3 destPos = Managers.Map.Cell2World(CellPos);
        Vector3 dir = destPos - transform.position;
        Quaternion targetRotation = Quaternion.LookRotation(dir);

        if (dir.magnitude < 0.01f)
        {
            transform.position = destPos;
            LerpCellPosCompleted = true;
            return;
        }

        float moveDist = Mathf.Min(dir.magnitude, moveSpeed * Time.deltaTime);
        transform.position += dir.normalized * moveDist;

        if (dir != Vector3.zero)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, moveSpeed * Time.deltaTime);
        }
    }

    public Define.EFindPathResult FindPathAndMoveToCellPos(Vector3 destWorldPos)
    {
        Vector3Int destCellPos = Managers.Map.World2Cell(destWorldPos);
        return FindPathAndMoveToCellPos(destCellPos);
    }

    public Define.EFindPathResult FindPathAndMoveToCellPos(Vector3Int destCellPos)
    {
        if (LerpCellPosCompleted == false)
            return Define.EFindPathResult.Fail_LerpCell;

        // A*
        List<Vector3Int> path = Managers.Map.FindPath(CellPos, destCellPos);
        if (path.Count < 2)
            return Define.EFindPathResult.Fail_NoPath;

        Vector3Int dirCellPos = path[1] - CellPos;
        Vector3Int nextPos = CellPos + dirCellPos;

        if (Managers.Map.MoveTo(this, nextPos) == false)
            return Define.EFindPathResult.Fail_MoveTo;

        return Define.EFindPathResult.Success;
    }

    protected IEnumerator CoLerpToCellPos()
    {
        while (true)
        {
            LerpToCellPos(Speed);

            yield return null;
        }
    }
    #endregion
}

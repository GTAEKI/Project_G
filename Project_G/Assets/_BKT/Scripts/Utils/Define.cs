using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Define
{
    #region Enum
    public enum EObjectType
    {
        None,
        Creature,
        Building,
    }

    public enum ECreatureType
    {
        None,
        Hero,
        Enemy,
    }

    public enum EBuildingType 
    {
        None,
        TargetBuilding,
        EnemyBuilding,
    }

    public enum ECreatureState
    {
        None,
        Idle,
        Move,
        Die,
    }

    public enum EScene
    {
        TitleScene,
        BaseScene,
        BattleScene,
    }

    public enum ECellCollisionType
    {
        None,
        Wall,
    }

    public enum EFindPathResult
    {
        Fail_LerpCell,
        Fail_NoPath,
        Fail_MoveTo,
        Success,
    }

    public enum EVirtualCamera 
    {
        TopViewCamera,
        GameViewCamera
    }
    #endregion

    #region Hard Coding
    public const char MAP_TOOL_WALL = '0';
    public const char MAP_TOOL_NONE = '1';

    public const string HeroRespawn = "HeroRespawn";
    public const string EnemyRespawn = "EnemyRespawn";
    public const string TargetBuilding = "TargetBuilding";
    public const string RespawnPoint = "RespawnPoint";
    //public const string TopViewCamera = "TopViewCamera";
    //public const string GameViewCamera = "GameViewCamera";

    public const float UpdateStateTick = 0.02f;
    #endregion
}
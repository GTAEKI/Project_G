using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Define
{
    #region Enum
    public enum EScene
    {
        TitleScene,
        BaseScene,
        BattleScene,
        Dev_BKT,
        Test_BaseScene_HSJ,
        TestScene_HSJ,
    }

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

    public enum ECellCollisionType
    {
        None,
        Wall,
        Building,
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

    public enum EColorType
    {
        None,
        Red,
        White,
        Yellow,
    }

    public enum EUIName 
    {
        MissionProgressBar,
    }
    #endregion

    #region Hard Coding
    public const char MAP_TOOL_WALL = '0';
    public const char MAP_TOOL_NONE = '1';
    public const char MAP_TOOL_BUILDING = '2';

    public const string HeroRespawn = "HeroRespawn";
    public const string EnemyRespawn = "EnemyRespawn";
    public const string TargetBuilding = "TargetBuilding";
    public const string RespawnPoint = "RespawnPoint";
    //public const string TopViewCamera = "TopViewCamera";
    //public const string GameViewCamera = "GameViewCamera";

    public const float UpdateStateTick = 0.02f;
    #endregion
}
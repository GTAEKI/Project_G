using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Define
{
    public enum EObjectType 
    {
        None,
        Creature,
        Construction,
    }

    public enum ECreatureType 
    {
        None,
        Hero,
        Enemy,
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

	// 하드코딩
	public const char MAP_TOOL_WALL = '0';
	public const char MAP_TOOL_NONE = '1';

    public const string HeroRespawn = "HeroRespawn";
    public const string EnemyRespawn = "EnemyRespawn";
}
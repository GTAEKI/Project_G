using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ObjectManager
{
    public HashSet<Hero> Heroes { get; } = new HashSet<Hero>();
    public HashSet<Enemy> Enemies { get; } = new HashSet<Enemy>();
    public HashSet<Building> Buildings { get; } = new HashSet<Building>();

    #region Make Root
    public Transform GetRootTransform(string name)
    {
        GameObject root = GameObject.Find(name);
        if (root == null)
            root = new GameObject { name = name };

        return root.transform;
    }

    public Transform HeroRoot { get { return GetRootTransform("@Heroes"); } }
    public Transform EnemyRoot { get { return GetRootTransform("@Enemies"); } }
    public Transform BuildingRoot { get { return GetRootTransform("@BuildingRoot"); } }
    #endregion

    // 등록
    public bool Register<T>(T obj) where T : BaseObject
    {
        if (obj.ObjectType == Define.EObjectType.Creature)
        {
            Creature creature = obj as Creature;
            switch (creature.CreatureType)
            {
                case Define.ECreatureType.Hero:
                    obj.transform.parent = HeroRoot;
                    Hero hero = creature as Hero;
                    Heroes.Add(hero);
                    break;
                case Define.ECreatureType.Enemy:
                    obj.transform.parent = EnemyRoot;
                    Enemy enemy = creature as Enemy;
                    Enemies.Add(enemy);
                    break;
                default:
                    return false;
            }
            creature.SetInfo();
        }
        else if (obj.ObjectType == Define.EObjectType.Building)
        {
            Building construction = obj as Building;
            Buildings.Add(construction);
        }
        else
        {
            return false;
        }

        return true;
    }

    // 생성
    public T Spawn<T>(Vector3 position) where T : BaseObject
    {
        string prefabName = typeof(T).Name;

        GameObject go = Managers.Resource.Instantiate<GameObject>(prefabName);
        go.name = prefabName;
        go.transform.position = position;

        BaseObject obj = go.GetComponent<BaseObject>();

        if (Register(obj) == false) 
        {
            // 등록 실패시 오류 알림
            Debug.LogError("Object Register Failed");
        };

        return obj as T;
    }

    // 파괴
    public void Despawn<T>(T obj) where T : BaseObject
    {
        Define.EObjectType objectType = obj.ObjectType;

        if (obj.ObjectType == Define.EObjectType.Creature)
        {
            Creature creature = obj as Creature;
            switch (creature.CreatureType)
            {
                case Define.ECreatureType.Hero:
                    obj.transform.parent = HeroRoot;
                    Hero hero = creature as Hero;
                    Heroes.Remove(hero);
                    break;
                case Define.ECreatureType.Enemy:
                    obj.transform.parent = EnemyRoot;
                    Enemy enemy = creature as Enemy;
                    Enemies.Remove(enemy);
                    break;
            }
        }
        else if (obj.ObjectType == Define.EObjectType.Building)
        {
            Building construction = obj as Building;
            Buildings.Remove(construction);
        }

        Managers.Resource.Destroy(obj.gameObject);
    }
}

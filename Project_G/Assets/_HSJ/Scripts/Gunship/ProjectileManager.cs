using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileManager
{
    private Queue<GameObject> bullets;
    private const string BULLET = "Bullet";

    public ProjectileManager()
    {
        Init();
    }
    private void Init()
    {
        bullets = new Queue<GameObject>();
    }

    private GameObject CreateBullet()
    {
        GameObject go = Managers.Resource.Instantiate(BULLET);
        bullets.Enqueue(go);
        return go;
    }
    public void Enqueue(GameObject go)
    {
        go.SetActive(false);
        go.transform.position = Vector3.zero;
        go.transform.rotation = Quaternion.identity;
        bullets.Enqueue(go);
    }

    public GameObject Dequeue(Vector3 pos, Quaternion rot)
    {
        GameObject go;
        if (bullets.Count == 0)
        {
            go = CreateBullet();
        }
        else
        {
            go = bullets.Dequeue();
        }

        go.transform.position = pos;
        go.transform.rotation = rot;
        go.SetActive(true);
        return go;
    }

    public void Clear()
    {
        bullets.Clear();
    }
}

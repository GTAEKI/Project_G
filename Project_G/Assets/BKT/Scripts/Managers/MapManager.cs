using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using UnityEngine;
using UnityEngine.Tilemaps;
using static Define;

public class MapManager
{
    public GameObject Map { get; private set; }
    public Grid CellGrid { get; private set; }

    // (CellPos, BaseObject) 셀 위치에 따른 BaseObject
    Dictionary<Vector3Int, BaseObject> _cells = new Dictionary<Vector3Int, BaseObject>();

    private int MinX;
    private int MaxX;
    private int MinY;
    private int MaxY;

    // 셀 좌표는 float가아닌 Int로 관리
    public Vector3Int World2Cell(Vector3 worldPos) { return CellGrid.WorldToCell(worldPos); }
    public Vector3 Cell2World(Vector3Int cellPos) { return CellGrid.CellToWorld(cellPos); }

    ECellCollisionType[,] _collision;

    public void LoadMap(string mapName)
    {
        GameObject map = GameObject.Find(mapName);

        Map = map;
        CellGrid = Util.FindChild<Grid>(map, "Grid", true);

        ParseCollisionData(map, mapName);
    }

    void ParseCollisionData(GameObject map, string mapName, string tilemap = "TileMap_MovableArea")
    {
        GameObject collision = Util.FindChild(map, tilemap, true);
        if (collision != null)
            collision.SetActive(false);

        // 갈 수 있는 지역 읽어오기
        TextAsset txt = Managers.Resource.LoadFromData<TextAsset>($"{tilemap}Collision");
        StringReader reader = new StringReader(txt.text);

        MinX = int.Parse(reader.ReadLine());
        MaxX = int.Parse(reader.ReadLine());
        MinY = int.Parse(reader.ReadLine());
        MaxY = int.Parse(reader.ReadLine());

        int xCount = MaxX - MinX + 1;
        int yCount = MaxY - MinY + 1;
        _collision = new ECellCollisionType[xCount, yCount];

        for (int y = 0; y < yCount; y++)
        {
            string line = reader.ReadLine();
            for (int x = 0; x < xCount; x++)
            {
                switch (line[x])
                {
                    case Define.MAP_TOOL_WALL:
                        _collision[x, y] = ECellCollisionType.Wall;
                        break;
                    case Define.MAP_TOOL_NONE:
                        _collision[x, y] = ECellCollisionType.None;
                        break;
                }
                Debug.Log(_collision[x , y]);
            }
        }
    }
}

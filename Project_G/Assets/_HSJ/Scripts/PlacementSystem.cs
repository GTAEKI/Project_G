using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacementSystem : MonoBehaviour
{
    [SerializeField]
    private GameObject mouseIndicator, cellIndicator;
    [SerializeField]
    private GameInput gameInput;
    [SerializeField]
    private Grid grid;

    [SerializeField]
    private ObjectDatabaseSO database;
    private int selectedObjectIndex = -1;

    [SerializeField]
    private GameObject gridVisualization;

    void Start()
    {
        StopPlacement();
    }
    public void StartPlacement(int ID)
    {
        selectedObjectIndex = database.objectData.FindIndex(data => data.ID == ID);
        // not selected
        if(selectedObjectIndex < 0)
        {
            Debug.LogError($"No ID Found {ID} ");
            return;
        }
        gridVisualization.SetActive(true);
        cellIndicator.SetActive(true);
        gameInput.OnClicked += PlaceStructure;
        gameInput.OnExit += StopPlacement;
    }

    private void PlaceStructure()
    {
        if(gameInput.isPointerOverUI())
        {
            return;
        }

        Vector3 mousePosition = gameInput.GetMousePosition();
        Vector3Int gridPosition = grid.WorldToCell(mousePosition);
        GameObject newObject = Instantiate(database.objectData[selectedObjectIndex].Prefab);        
        newObject.transform.position = grid.CellToWorld(gridPosition);
    }

    private void StopPlacement()
    {
        selectedObjectIndex = -1;
        gridVisualization.SetActive(false);
        cellIndicator.SetActive(false);
        gameInput.OnClicked -= PlaceStructure;
        gameInput.OnExit -= StopPlacement;
    }

    void Update()
    {
        Vector3 mousePosition = gameInput.GetMousePosition();
        Vector3Int gridPosition = grid.WorldToCell(mousePosition);

        mouseIndicator.transform.position = mousePosition;
        cellIndicator.transform.position = grid.CellToWorld(gridPosition);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseMapManager
{
    // HSJ basemap 
    public GridData BaseMapData { get; private set; }
    

    public void GetGridData(GridData gridData)
    {
        BaseMapData = gridData;
    }
    public void UpdateGridData(GridData gridData)
    {
        BaseMapData = gridData; 
    }


}

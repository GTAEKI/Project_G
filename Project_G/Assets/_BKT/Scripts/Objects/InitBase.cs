using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitBase : MonoBehaviour
{
    protected bool _init = false;

    public virtual bool Init() 
    {
        if (_init) return false;

        _init = true;
        return true;
    }

    private void Awake()
    {
        if (Init() == false)
        {
            Debug.Log($"{gameObject.name} init failed, Destroy");
            Destroy(gameObject);
        }
    }
}

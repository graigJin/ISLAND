using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildMenu : MonoBehaviour
{
    public bool IsActive { get; set; }

    private void Start()
    {
        IsActive = gameObject.activeSelf;
    }

    public void SwitchState()
    {
        if (IsActive)
        {
            IsActive = false;
        }
        else
        {
            IsActive = true;
        }
        
        gameObject.SetActive(IsActive);
    }
}

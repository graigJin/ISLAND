using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldManager : MonoBehaviour
{
    [SerializeField] private int width;
    [SerializeField] private int height;

    public int Width => width;
    public int Height => height;
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private bool[] keys = { false, false, false };

    public void TakeKey(int i)
    {
        keys[i] = true;
    }

    public bool CheckKey(int i)
    {
        return keys[i];
    }
}

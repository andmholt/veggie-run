using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public int level;

    void Start()
    {

    }

    public void ButtonAction()
    {
        int _level = level;

        Debug.Log(_level);
        GameManager.Instance.Load(_level);
    }
}

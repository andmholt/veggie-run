using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RanchBottom : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
            GameManager.Instance.LevelComplete();
    }
}

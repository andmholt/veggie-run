using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    private PlayerUI playerUI;

    private void Start()
    {
        playerUI = GameObject.Find("Player UI").GetComponent<PlayerUI>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Coin")
        {
            GameObject coin = other.gameObject;
             int value = coin.GetComponent<Coin>().value;
            Destroy(coin);

            playerUI.UpdateScore(value);
        }
    }
}

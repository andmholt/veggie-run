using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public int value;

    public float floatForce;
    public float floatRadius;
    private float startingYPos;

    private Rigidbody2D coinRb;

    private void Start()
    {
        coinRb = GetComponent<Rigidbody2D>();
        startingYPos = transform.position.y;

        transform.position += Vector3.up * Random.value * floatRadius;
        coinRb.AddForce(Vector2.down * floatForce, ForceMode2D.Impulse);
    }

    private void Update()
    {
        float floatBoundUp = startingYPos + floatRadius;
        float floatBoundDown = startingYPos - floatRadius;

        if (transform.position.y >= floatBoundUp)
        {
            coinRb.velocity = Vector2.zero;
            coinRb.AddForce(Vector2.down * floatForce, ForceMode2D.Impulse);
        }
        else if (transform.position.y <= floatBoundDown)
        {
            coinRb.velocity = Vector2.zero;
            coinRb.AddForce(Vector2.up * floatForce, ForceMode2D.Impulse);
        }
    }
}

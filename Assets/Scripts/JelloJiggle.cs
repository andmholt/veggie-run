using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JelloJiggle : MonoBehaviour
{
    GameObject jello;

    private void Start()
    {
        jello = gameObject.transform.parent.gameObject;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.tag == "Player")
            jello.GetComponent<Jello>().jiggle = true;
        Debug.Log("jiggle");
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.gameObject.tag == "Player")
            jello.GetComponent<Jello>().jiggle = false;
        Debug.Log("no jiggle");
    }
}

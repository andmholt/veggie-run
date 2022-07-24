using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JelloJump : MonoBehaviour
{
    GameObject jello;

    private void Start()
    {
        jello = gameObject.transform.parent.gameObject;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.tag == "Player")
        {
            StartCoroutine(JumpDetected());
        }
    }

    IEnumerator JumpDetected()
    {
        jello.GetComponent<Jello>().jump = true;

        yield return new WaitForSeconds(1);
        jello.GetComponent<Jello>().jump = false;
    }
}

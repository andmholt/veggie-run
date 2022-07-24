using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;

    public float playerWiggleRoomRight;
    public float playerWiggleRoomLeft;
    public float playerWiggleRoomUp;
    public float playerWiggleRoomDown;
    public float leftBoundary;
    public float upperBoundary;

    // Update is called once per frame
    void Update()
    {
        // left - right
        if (player.position.x >= transform.position.x - playerWiggleRoomRight)
            transform.position = new Vector3(player.position.x + playerWiggleRoomRight, transform.position.y, offset.z);
        else if (player.position.x <= transform.position.x - playerWiggleRoomLeft)
            transform.position = new Vector3(player.position.x + playerWiggleRoomLeft, transform.position.y, offset.z);
        if (transform.position.x < leftBoundary)
            transform.position = new Vector3(leftBoundary, transform.position.y, offset.z);

        // up - down
        if (player.position.y >= transform.position.y - playerWiggleRoomUp)
            transform.position = new Vector3(transform.position.x, player.position.y + playerWiggleRoomUp, offset.z);
        else if (player.position.y <= transform.position.y - playerWiggleRoomDown)
            transform.position = new Vector3(transform.position.x, BottomCheck(), offset.z);
        if (transform.position.y > upperBoundary)
            transform.position = new Vector3(transform.position.x, upperBoundary, offset.z);
    }

    float BottomCheck()
    {
        if (player.position.y + playerWiggleRoomDown > offset.y)
            return player.position.y + playerWiggleRoomDown;
        else return offset.y;
    }
}

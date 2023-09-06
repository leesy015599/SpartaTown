using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private GameObject player;
    private void Update()
    {
        FollowPlayer(player);
    }

    private void FollowPlayer(GameObject player)
    {
        Vector3 playerPos = player.transform.position;
        playerPos.z = transform.position.z;
        transform.position = playerPos;
    }
}

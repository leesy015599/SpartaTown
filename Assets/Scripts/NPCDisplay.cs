using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCDisplay : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private SpriteRenderer NPCRenderer;

    private void Update()
    {
        LookPlayer(player);
        BehindPlayer(player);
    }

    private void LookPlayer(GameObject player)
    {
        NPCRenderer.flipX = player.transform.position.x - transform.position.x > 0;
    }

    private void BehindPlayer(GameObject player)
    {
        NPCRenderer.sortingOrder = player.transform.position.y < transform.position.y ? 9 : 11;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCDirection : MonoBehaviour
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
        // 기본이 왼쪽.
        // 플레이어x값과 NPC x값의 차이가 양수일 때 flipx true
        NPCRenderer.flipX = player.transform.position.x - transform.position.x > 0;
    }

    private void BehindPlayer(GameObject player)
    {
        // 기본이 플레이어보다 앞에 있을 때. Order In Layer 가 더 높다.
        // 뒤에 있을 경우 낮게.
        NPCRenderer.sortingOrder = player.transform.position.y < transform.position.y ? 9 : 11;
    }
}

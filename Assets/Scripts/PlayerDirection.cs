using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDirection : MonoBehaviour
{
    private PlayerEventController _controller;
    [SerializeField] private SpriteRenderer characterRenderer;

    private void Awake()
    {
        _controller = GetComponent<PlayerEventController>();
    }

    void Start()
    {
        _controller.OnLookEvent += Look;
    }

    public void Look(Vector2 newDirection)
    {
        LookOpposite(newDirection);
    }

    private void LookOpposite(Vector2 direction)
    {
        float degree = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        characterRenderer.flipX = (Mathf.Abs(degree) > 90f);
    }
}

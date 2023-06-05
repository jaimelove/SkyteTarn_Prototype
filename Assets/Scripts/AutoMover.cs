using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoMover : MonoBehaviour
{
    [SerializeField]
    private float _moveSpeed;

    [SerializeField]
    private Vector2 _moveDirection;

    void FixedUpdate()
    {
        if (ModeSwitcher.Instance.IsDefendMode())
            return;

        transform.Translate(_moveDirection * _moveSpeed * Time.deltaTime);
    }
}

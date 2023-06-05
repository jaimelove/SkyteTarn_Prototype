using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerMover : MonoBehaviour
{
    [SerializeField] 
    private float _speed;

    void FixedUpdate()
    {
        if (ModeSwitcher.Instance.IsDefendMode())
            return;

        if (Input.GetKey(KeyCode.W))
        {
            transform.position += Vector3.up * Time.deltaTime * _speed;
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += Vector3.left * Time.deltaTime * _speed;
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position += Vector3.down * Time.deltaTime * _speed;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += Vector3.right * Time.deltaTime * _speed;
        }
    }
}

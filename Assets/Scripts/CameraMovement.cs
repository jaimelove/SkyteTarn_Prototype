using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public bool placing;

    [SerializeField] private Camera defenderCamera;
    [SerializeField] private float speed;

    void Update()
    {
        if (ModeSwitcher.Instance.IsAttackMode())
            return;

        UpdateCameraMovement();
    }

    private void UpdateCameraMovement()
    {
        if (Input.GetKey(KeyCode.W))
        {
            defenderCamera.transform.position += Vector3.up * Time.deltaTime * speed;
        }
        if (Input.GetKey(KeyCode.A))
        {
            defenderCamera.transform.position += Vector3.left * Time.deltaTime * speed;
        }
        if (Input.GetKey(KeyCode.S))
        {
            defenderCamera.transform.position += Vector3.down * Time.deltaTime * speed;
        }
        if (Input.GetKey(KeyCode.D))
        {
            defenderCamera.transform.position += Vector3.right * Time.deltaTime * speed;
        }
    }
}

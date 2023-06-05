using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretPreview : MonoBehaviour
{
    private bool isValid;

    [SerializeField] private SpriteRenderer spriteRenderer;

    public void SetPos(Vector3 pos)
    {
        transform.position = pos;
    }

    public void SetValid(bool valid)
    {
        if (isValid == valid)
        {
            return;
        }

        if (valid)
        {
            spriteRenderer.color = Color.green;
        }
        else
        {
            spriteRenderer.color = Color.red;
        }
    }
}

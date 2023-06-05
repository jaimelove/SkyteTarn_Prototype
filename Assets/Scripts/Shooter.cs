using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] 
    private GameObject _bulletPref;

    [SerializeField] 
    private float _shootVelocity;

    void Update()
    {
        if (ModeSwitcher.Instance.IsDefendMode())
            return;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        GameObject go = Instantiate(_bulletPref, transform.position + transform.right * 1f, transform.rotation);
        go.GetComponent<Bullet>().Setup(transform.right, _shootVelocity);
    }
}

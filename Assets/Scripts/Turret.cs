using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public enum ShootMode { Straight, LockOn, RotateTowards}

public class Turret : MonoBehaviour
{
    [SerializeField] private GameObject bulletPref;

    [SerializeField] private float shootInterval;
    private float currentShootTime;

    [SerializeField] private float shootVelocity;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private ShootMode shootMode;

    [SerializeField]
    private int costToBuild = 50;

    [SerializeField]
    private int rewardForDestroy = 30;

    [SerializeField]
    private float _distancenumbergood;

    public bool _isActive = false;

    private void Awake()
    {
        _isActive = false;
    }

    private void Update()
    {
        if (ModeSwitcher.Instance.IsDefendMode())
            return;

        currentShootTime += Time.deltaTime;

        switch (shootMode)
        {
            case ShootMode.LockOn:
                AimAtInstant(FindObjectOfType<Player>().transform.position);
                break;
            case ShootMode.RotateTowards:
                AimAtRotateTowards(FindObjectOfType<Player>().transform.position);
                break;
        }

        if (currentShootTime > shootInterval)
        {
            Shoot();
            currentShootTime = 0;
        }


        CheckActiveDistance();
    }

    private void CheckActiveDistance()
    {
        if ((FindObjectOfType<Player>().transform.position - transform.position).magnitude < _distancenumbergood)
        {
            _isActive = true;
            Debug.Log("active true");
        }
        else
        {
            _isActive = false;
        }
    }

    private void Shoot()
    {
        if (!_isActive)
            return;

        Debug.Log("pew");

        GameObject go = Instantiate(bulletPref, transform.position + (Vector3)transform.right * 1f, transform.rotation);
        go.GetComponent<Bullet>().Setup(transform.right, shootVelocity);
    }

    private void AimAtRotateTowards(Vector3 target)
    {
        Vector2 dir = target - transform.position;                  //delta
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;    //radians til grader
        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.AngleAxis(angle, Vector3.forward), rotationSpeed * Time.deltaTime);   //Roter mot, men ikke gå over speed
    }

    private void AimAtInstant(Vector3 target)
    {
        Vector2 dir = target - transform.position;      //delta
        transform.right = dir;                          //muzzle towards delta
    }

    
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawRay(transform.position, (FindObjectOfType<Player>().transform.position - transform.position).normalized * _distancenumbergood);
    }
    
}

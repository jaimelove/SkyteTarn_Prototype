using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Owie : MonoBehaviour
{
    [SerializeField]
    private int _amountOfOwie = 2;

    [SerializeField]
    private bool _canHurtAttacker = false;

    [SerializeField]
    private bool _canHurtDefender = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        bool applyDamage = false;

        if (collision.gameObject.GetComponent<Player>() && _canHurtAttacker)
        {
            //Debug.Log("shall attack attacker");
            applyDamage = true;
        }

        if (collision.gameObject.GetComponent<Turret>() && _canHurtDefender)
        {
            //Debug.Log("shall attack defender");
            applyDamage = true;
        }

        if (applyDamage)
        {
            collision.gameObject.GetComponent<Health>()?.TakeDamage(_amountOfOwie);
            Destroy(gameObject);
        }
    }
}

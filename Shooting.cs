using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class Shooting : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _delay;
    [SerializeField] private Bullet _bullet;
    [SerializeField] private Transform _target;

    void Start()
    {
        StartCoroutine(Shoot());
    }

    private IEnumerator Shoot()
    {
        var shootDelay = new WaitForSeconds(_delay);

        while (true)
        {
            Vector3 bulletDirection = (_target.position - transform.position).normalized;

            var NewBullet = Instantiate(_bullet, transform.position + bulletDirection, Quaternion.identity);

            NewBullet.GetComponent<Rigidbody>().transform.up = bulletDirection;
            NewBullet.GetComponent<Rigidbody>().velocity = bulletDirection * _speed;

            yield return new WaitForSeconds(_delay);

        }
    }
}

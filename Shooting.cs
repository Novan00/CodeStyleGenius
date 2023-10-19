using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class Shooting : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _delay;
    [SerializeField] private Bullet _bullet;
    [SerializeField] private Transform _target;

    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

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

            var newBullet = Instantiate(_bullet, transform.position + bulletDirection, Quaternion.identity);

            newBullet.transform.up = bulletDirection;
            _rigidbody.velocity = bulletDirection * _speed;

            yield return shootDelay;
        }
    }
}

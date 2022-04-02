using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponLook : MonoBehaviour
{
    [SerializeField] private Transform TopArea;
    [SerializeField]private Transform muzzle;
    [SerializeField] private GameObject bullet;
    [SerializeField] private GameObject target;
    [SerializeField] private float FireRate;

    private void Start()
    {
        InvokeRepeating("Fire", 0f, FireRate);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            target = other.gameObject;
            Vector3 direction = target.transform.position - TopArea.position;
            Quaternion rot = Quaternion.LookRotation(direction);
            Vector3 rota = rot.eulerAngles;
            TopArea.rotation = Quaternion.Euler(0f, rota.y, 0f);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        target = null;
    }

    private void Fire()
    {
        if (target != null)
        {
            GameObject newBullet = Instantiate(bullet, muzzle.position, muzzle.rotation);

            Bullet b = newBullet.GetComponent<Bullet>();
            b.GetTarget(target.transform);

            newBullet.transform.localPosition = muzzle.transform.position;
        }
    }
}

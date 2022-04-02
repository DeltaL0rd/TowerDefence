using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    [SerializeField] private Transform TopArea;
    [SerializeField]private Transform muzzle;
    [SerializeField] private GameObject bullet;
    [SerializeField] private GameObject target;
    [SerializeField] private float FireRate;
    [SerializeField] private PoolBase bulletPool;

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

            // TODO: use BulletPool.GetObject();

            var newBullet = bulletPool.GetObject();
            Bullet b = newBullet.GetComponent<Bullet>();
            b.SetStatus(true);
            b.GetTarget(target.transform);

            newBullet.transform.localPosition = muzzle.transform.position;
        }
    }
}

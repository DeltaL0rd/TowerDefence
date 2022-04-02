using UnityEngine;

public class Bullet : PoolObject
{
    [SerializeField] private Transform target;
    public float speed = 50f;

    public void GetTarget(Transform Target)
    {
        target = Target;
    }

    private void Update()
    {
        if(target == null || !target.gameObject.activeInHierarchy)
        {
            SetStatus(false);
            return;
        }
        Vector3 dir = target.position - transform.position;
        float dis = speed * Time.deltaTime;
        transform.Translate(dir.normalized * dis, Space.World);
    }

    protected override void CheckActive()
    {
       
    }
}

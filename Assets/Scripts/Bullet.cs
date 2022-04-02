using UnityEngine;

public class Bullet : MonoBehaviour
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
            Destroy(gameObject);
            return;
        }
        Vector3 dir = target.position - transform.position;
        float dis = speed * Time.deltaTime;
        transform.Translate(dir.normalized * dis, Space.World);
    }
}

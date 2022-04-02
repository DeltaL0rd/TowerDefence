using UnityEngine;

public abstract class PoolObject : MonoBehaviour
{
    public bool isActive;
    protected abstract void CheckActive();
    public void SetStatus(bool status)
    {
        isActive = status;
        gameObject.SetActive(status);
    }
}

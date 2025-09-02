using UnityEngine;

public class HitableObj : MonoBehaviour, IHitable
{
    public void Hit()
    {
        Destroy(gameObject);
    }

    
}

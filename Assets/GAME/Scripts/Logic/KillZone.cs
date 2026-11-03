using UnityEngine;

public class KillZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<MoverToTarget>(out _))
        {
            Destroy(other.gameObject);
        }
    }
}
using UnityEngine;

public class KillZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<MoveToTarget>(out _))
        {
            Destroy(other.gameObject);
        }
    }
}
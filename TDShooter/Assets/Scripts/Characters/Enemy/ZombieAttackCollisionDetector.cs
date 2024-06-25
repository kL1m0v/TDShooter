using TopDownShooter;
using UnityEngine;

public class ZombieAttackCollisionDetector : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<PlayerManager>(out PlayerManager player))
        {
            player.TakeDamage(1);
            Debug.Log("Player Take Damage");
        }
    }
}

using Player;
using UnityEngine;

namespace Level_1
{
    public class DeadZones : MonoBehaviour
    {
        [SerializeField] private Respawn player;

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
                player.respawn();
        }
    }
}
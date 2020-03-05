using UnityEngine;

namespace Level_1.RandomZone
{
    public class RandomZoneController : MonoBehaviour
    {
        [SerializeField] private Transform spawnerLow1;
        [SerializeField] private Transform spawnerLow2;
        [SerializeField] private Transform spawnerLow3;
        [SerializeField] private Transform spawnerLow4;
        [SerializeField] private Transform spawnerHigh1;
        [SerializeField] private Transform spawnerHigh2;
        [SerializeField] private Transform spawnerHigh3;
        [SerializeField] private Transform spawnerHigh4;

        [SerializeField] private GameObject lowBlockPrefab;
        [SerializeField] private GameObject highBlockPrefab;
    

        private bool _spawned;

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player") && !_spawned)
            {
                SpawnObstacles();
                _spawned = true;
            }
        }

        private void SpawnObstacles()
        {
            if (Random.value >= 0.5)
                Instantiate(lowBlockPrefab, spawnerLow1.position, Quaternion.identity, spawnerLow1);
            if (Random.value >= 0.5)
                Instantiate(lowBlockPrefab, spawnerLow2.position, Quaternion.identity, spawnerLow2);
            if (Random.value >= 0.5)
                Instantiate(lowBlockPrefab, spawnerLow3.position, Quaternion.identity, spawnerLow3);
            if (Random.value >= 0.5)
                Instantiate(lowBlockPrefab, spawnerLow4.position, Quaternion.identity, spawnerLow4);
            if (Random.value >= 0.5)
                Instantiate(highBlockPrefab, spawnerHigh1.position, Quaternion.identity, spawnerHigh1);
            if (Random.value >= 0.5)
                Instantiate(highBlockPrefab, spawnerHigh2.position, Quaternion.identity, spawnerHigh2);
            if (Random.value >= 0.5)
                Instantiate(highBlockPrefab, spawnerHigh3.position, Quaternion.identity, spawnerHigh3);
            if (Random.value >= 0.5)
                Instantiate(highBlockPrefab, spawnerHigh4.position, Quaternion.identity, spawnerHigh4);
        }
    }
}
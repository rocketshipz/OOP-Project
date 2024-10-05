using UnityEngine;

namespace PonyAttack
{
    public class Obstacle : MonoBehaviour
    {
        public float damage = 10f;
        public float radius = 1f;

        private void OnCollisionEnter(Collision collision)
        {
            // Check if the collision is with the player
            if (collision.gameObject.CompareTag("Player"))
            {
                // Apply damage to the player
                collision.gameObject.GetComponent<Player>().TakeDamage(damage);
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            // Check if the trigger is with the player
            if (other.gameObject.CompareTag("Player"))
            {
                // Apply damage to the player
                other.gameObject.GetComponent<Player>().TakeDamage(damage);
            }
        }
    }
}
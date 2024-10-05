using System.Diagnostics;
using UnityEngine;

namespace PonyAttack
{
    public class PonySwarm : MonoBehaviour
    {
        public float speed = 2.0f;
        public float health = 50.0f;

        private Vector3 targetPosition;

        void Start()
        {
            // Find the player
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            targetPosition = player.transform.position;
        }

        void Update()
        {
            // Move towards the player
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, step);

            // Check if the pony has reached the player
            if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
            {
                // Attack the player
                Player playerScript = targetPosition.GetComponent<Player>();
                if (playerScript != null)
                {
                    playerScript.TakeDamage(10f);
                }
            }
        }

        public void TakeDamage(float damage)
        {
            health -= damage;
            if (health <= 0)
            {
                Die();
            }
        }

        void Die()
        {
            // Handle zombie death
            Debug.Log("Pony died");
            Destroy(gameObject);
        }
    }
}
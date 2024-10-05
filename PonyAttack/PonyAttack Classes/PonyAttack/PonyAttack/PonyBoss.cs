using UnityEngine;

namespace PonyAttack
{
    public class PonyBoss : PonySwarm
    {
        public float speed = 3.0f;
        public float health = 200.0f;

        void Update()
        {
            // Move towards the player
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, step);

            // Check if the pony boss has reached the player
            if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
            {
                // Attack the player
                Player playerScript = targetPosition.GetComponent<Player>();
                if (playerScript != null)
                {
                    playerScript.TakeDamage(20f);
                }
            }
        }
    }
}
using System.Diagnostics;
using UnityEngine;

namespace PonyAttack
{
    public class PlayerMovement : MonoBehaviour
    {
        public float speed = 5.0f;
        public float jumpForce = 5.0f;
        public float health = 100.0f;

        private CharacterController controller;
        private Vector3 playerVelocity;
        private bool groundedPlayer;

        void Start()
        {
            controller = gameObject.AddComponent<CharacterController>();
        }

        void Update()
        {
            groundedPlayer = controller.isGrounded;
            if (groundedPlayer && playerVelocity.y < 0)
            {
                playerVelocity.y = 0f;
            }

            Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

            controller.Move(move * Time.deltaTime * speed);

            if (Input.GetButtonDown("Jump") && groundedPlayer)
            {
                playerVelocity.y += Mathf.Sqrt(jumpForce * -3.0f * Physics.gravity.y);
            }

            playerVelocity.y += Physics.gravity.y * Time.deltaTime;

            controller.Move(playerVelocity * Time.deltaTime);

            // Shooting
            if (Input.GetButtonDown("Fire1"))
            {
                Shoot();
            }
        }

        void Shoot()
        {
            // Raycast from the camera
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, 100f))
            {
                // Check if the hit object is a pony
                Pony pony = hit.transform.GetComponent<Pony>();
                if (pony != null)
                {
                    // Damage the pony
                    pony.TakeDamage(10f);
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
            // Handle player death
            Debug.Log("Player died");
        }
    }
}
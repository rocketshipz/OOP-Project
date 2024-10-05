using UnityEngine;

namespace PonyAttack
{
    public class PlayerWeapon : MonoBehaviour
    {
        public float damage = 10f;
        public float range = 100f;

        void Update()
        {
            // Check if the fire button is pressed
            if (Input.GetButtonDown("Fire1"))
            {
                // Shoot
                Shoot();
            }
        }

        void Shoot()
        {
            // Raycast from the camera
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, range))
            {
                // Check if the hit object is a pony
                Pony pony = hit.transform.GetComponent<Pony>();
                if (pony != null)
                {
                    // Damage the pony
                    pony.TakeDamage(damage);
                }
            }
        }
    }
}
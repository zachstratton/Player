using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public int damagePerAttack = 20;                // The damage inflicted by each Attack.
    public float timeBetweenAttacks = 0.15f;        // The time between each Attack.
    public float range = 5f;                        // The distance of attack

    //float timer;                                    // A timer to determine when to Attack.
    Ray attackRay;                                  // A ray from the gun end forwards.
    RaycastHit attackHit;                           // A raycast hit to get information about what was hit.
    int attackableMask;                             // A layer mask so the raycast only hits things on the shootable layer.
    //ParticleSystem gunParticles;                    // Reference to the particle system.
    //LineRenderer gunLine;                           // Reference to the line renderer.
    //AudioSource gunAudio;                           // Reference to the audio source.
    //Light gunLight;                                 // Reference to the light component.
    //float effectsDisplayTime = 0.2f;                // The proportion of the timeBetweenBullets that the effects will display for.

    void Awake()
    {
        // Create a layer mask for the Shootable layer.
        attackableMask = LayerMask.GetMask("Attackable"); //a Layer to set everything you can attack as

        // Set up the referenc
        //gunParticles = GetComponent<ParticleSystem>();
        //gunLine = GetComponent<LineRenderer>();
        //gunAudio = GetComponent<AudioSource>();
        //gunLight = GetComponent<Light>();
    }

    void Update()
    {
        // Add the time since Update was last called to the timer.
        //timer += Time.deltaTime;

        // If the Fire1 button is being press and it's time to fire...
        //if (Input.GetButton("Fire1") && timer >= timeBetweenAttacks)
        //{
            // ... shoot the gun.
            //Attack ();
        //}

        // If the timer has exceeded the proportion of timeBetweenBullets that the effects should be displayed for...
        //if (timer >= timeBetweenAttacks * effectsDisplayTime)
        //{
            // ... disable the effects.
            //DisableEffects();
        //}
    }

    //public void DisableEffects()
    //{
        // Disable the line renderer and the light.
        //gunLine.enabled = false;
        //gunLight.enabled = false;
    //}

    public void Attack (Vector3 attackDir)
    {
        // Reset the timer.
        //timer = 0f;

        // Play the gun shot audioclip.
        //gunAudio.Play();

        // Enable the light.
        //gunLight.enabled = true;

        // Stop the particles from playing if they were, then start the particles.
        //gunParticles.Stop();
        //gunParticles.Play();

        // Enable the line renderer and set it's first position to be the end of the gun.
        //gunLine.enabled = true;
        //gunLine.SetPosition(0, transform.position);

        // Set the shootRay so that it starts at the end of the gun and points forward from the barrel.
        attackRay.origin = transform.position;
        attackRay.direction = attackDir;

        // Perform the raycast against gameobjects on the shootable layer and if it hits something...
        if (Physics.Raycast(attackRay, out attackHit, range, attackableMask))
        {
            // Try and find an EnemyHealth script on the gameobject hit.
            EnemyHealth enemyHealth = attackHit.collider.GetComponent<EnemyHealth>();

            // If the EnemyHealth component exist...
            if (enemyHealth != null)
            {
                // ... the enemy should take damage.
                enemyHealth.TakeDamage(damagePerAttack);
            }

            // Set the second position of the line renderer to the point the raycast hit.
            //gunLine.SetPosition(1, attackHit.point);
        }
        // If the raycast didn't hit anything on the shootable layer...
        //else
        //{
            // ... set the second position of the line renderer to the fullest extent of the gun's range.
            //gunLine.SetPosition(1, shootRay.origin + shootRay.direction * range);
        //}
    }
}
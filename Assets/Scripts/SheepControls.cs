using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SheepControls : MonoBehaviour
{
    private Rigidbody rb;

    [Header("Movement")]
    [Tooltip("How fast to move GameObject Forward.")]
    public float forwardSpeed = 4.0f;
    private float speedIncrease = 0.2f;
    [Tooltip("Apply this much force to Rigidbody.")]
    public float jumpForce = 5.0f;
    private Button jumpButton;

    [Header("Game Info")]
    [SerializeField] private float groundY;
    [Space]
    public bool isJumping;
    [SerializeField] private bool isDestroyed;
    [SerializeField] private bool isSaved;

    [Header("VFX")]
    public ParticleSystem explosionParticles;
    public ParticleSystem bloodParticles;
    public GameObject explodingParts;

    private SFXController sfxC;

    private Counter counter;
    private CameraShake cameraShake;

    private int randomBah;
    private int randomDeath;

    private Timer timer;
    private Animator sheepAnimator;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        groundY = (transform.position.y)+0.02f;
        counter = FindObjectOfType<Counter>();   
        sfxC = FindObjectOfType<SFXController>();
        cameraShake = FindObjectOfType<CameraShake>();
        timer = FindObjectOfType<Timer>();
        jumpButton = FindObjectOfType<Button>();
        jumpButton.onClick.AddListener(Jump);
        sheepAnimator = GetComponent<Animator>();
        AdjustSpeed();
    }

    void Update()
    {
        transform.Translate(forwardSpeed * Time.deltaTime * Vector3.forward);
        
        if (Input.GetKeyDown(KeyCode.Space) && !isJumping)
        {
            Jump();
        }
        isJumping = false;
        sheepAnimator.SetBool("isJumping", false);
    }

    public void Jump()
    {
        if (transform.position.y < groundY)
        {
            isJumping = true;
            sheepAnimator.SetBool("isJumping", true);
            BahSFX();
            rb.AddForce(Vector3.up * jumpForce);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ExplosiveWire"))
        {
            if (isDestroyed) return;
            else
            {
                Debug.Log("Hit Wire");
                KillSheep();
            } 
        }

        if (other.CompareTag("Goal"))
        {
            if (isSaved) return;
            else
            {
                Debug.Log("Reached Goal");
                SaveSheep();
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Sheep"))
        {
            Physics.IgnoreCollision(this.GetComponent<Collider>(),
                collision.gameObject.GetComponent<Collider>());
        }
    }

    private void KillSheep()
    {
        cameraShake.Shake(.2f, 2, 2, 2, 0);
        CallDeathSFX();
        isDestroyed = true;
        Destroy(gameObject);
        InstantiateVFX();
        counter.AddDeadSheep();
    }

    private void SaveSheep()
    {
        isSaved = true;
        sfxC.sheepAudioSource.PlayOneShot(sfxC.goalSound);
        Destroy(gameObject);
        counter.AddSavedSheep();
    }

    private void RandomBah()
    {
        randomBah = (Random.Range(0, sfxC.bahSounds.Length));
    }

    private void RandomDeathSound()
    {
        randomDeath = (Random.Range(0, sfxC.deathSounds.Length));
    }

    private void CallDeathSFX()
    {
        sfxC.sheepAudioSource.PlayOneShot(sfxC.explosionSound);
        sfxC.sheepAudioSource.PlayOneShot(sfxC.bloodSound);
        RandomDeathSound();
        sfxC.sheepAudioSource.PlayOneShot(sfxC.deathSounds[randomDeath]);
    }

    private void InstantiateVFX()
    {
        Instantiate(explosionParticles, transform.position,
            explosionParticles.transform.rotation);
        Instantiate(bloodParticles, transform.position,
            bloodParticles.transform.rotation);
        Instantiate(explodingParts, transform.position,
            explodingParts.transform.rotation);
    }

    private void BahSFX()
    {
        sfxC.sheepAudioSource.PlayOneShot(sfxC.jumpSound);
        RandomBah();
        sfxC.sheepAudioSource.PlayOneShot(sfxC.bahSounds[randomBah]);
    }

    private void AdjustSpeed()
    {
        if (counter.savedCount >= 10)
        {
            forwardSpeed = 4.2f;
        }
        else if (counter.savedCount >= 20)
        {
            forwardSpeed = 4.4f;
        }
        else if (counter.savedCount >= 30)
        {
            forwardSpeed = 4.6f;
        }
        else if (counter.savedCount >= 40)
        {
            forwardSpeed = 4.8f;
        }
        else if (counter.savedCount >= 50)
        {
            forwardSpeed = 5.0f;
        }

        switch (counter.savedCount)
        {
            case 10:
                timer.countDown += 10;
                break;
            case 20:
                timer.countDown += 10;
                break;
            case 30:
                timer.countDown += 10;
                break;
            case 40:
                timer.countDown += 10;
                break;
            case 50:
                timer.countDown += 10;
                break;
        }
    }
}

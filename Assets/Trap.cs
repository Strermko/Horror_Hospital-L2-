using UnityEngine;

public class Trap : MonoBehaviour
{
    [SerializeField] DummyController dummy;
    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            audioSource.Play();
            dummy.Awakening();
        }
    }
}

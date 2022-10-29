using System;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    public static event Action OnCollected;
    public static int total; 
    public AudioClip collectibleSound;

    void Awake() => total++;

    void Update()
    {
        transform.Rotate(new Vector3 (0f, 1f, 0f));
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            AudioSource.PlayClipAtPoint(collectibleSound, transform.position,0.5f);
            OnCollected?.Invoke();
            Destroy(gameObject);
        }
    }
}

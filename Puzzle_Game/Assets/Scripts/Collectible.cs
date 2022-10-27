using System;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    public static event Action OnCollected;
    public static int total; 
    AudioSource source;


    void Awake()
    {
       source = GetComponent<AudioSource>(); 
       total++;
    }
    void Update()
    {
        transform.Rotate(new Vector3 (0f, 1f, 0f));
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            OnCollected?.Invoke();
            source.Play();
            Destroy(gameObject);
            

            
        }
    }
}

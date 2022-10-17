using System;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    public static event Action OnCollected;
    public static int total; 

    void Awake() => total++;

    void Update()
    {
        transform.Rotate(new Vector3 (0f, 0.1f, 0f));
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            OnCollected?.Invoke();
            Destroy(gameObject);
        }
    }
}

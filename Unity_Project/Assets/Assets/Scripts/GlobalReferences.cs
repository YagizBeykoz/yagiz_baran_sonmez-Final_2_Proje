using UnityEngine;

public class GlobalReferences : MonoBehaviour
{
    public static GlobalReferences Instance { get; set; }

    public GameObject bulletImpactEffectPrefab;
    public AudioSource bulletImpactSound;

    void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(gameObject);
            bulletImpactSound.Play();
        }
        else
        {
            Instance = this;
        }
    }
}

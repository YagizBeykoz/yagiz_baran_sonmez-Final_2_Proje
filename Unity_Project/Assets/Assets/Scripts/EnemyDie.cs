using UnityEngine;

public class EnemyDie : MonoBehaviour
{
    public GameObject enemy;
    public AudioSource dying;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            Object.Destroy(enemy);
            dying.Play();
        }
    }
}

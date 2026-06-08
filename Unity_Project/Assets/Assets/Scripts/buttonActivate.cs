using UnityEngine;

public class buttonActivate : MonoBehaviour
{
    public GameObject button;
    public GameObject door;
    public AudioSource buttonPush;

    private void OnCollisionEnter (Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            Object.Destroy(button);
            Object.Destroy(door);
            buttonPush.Play();
        }
    }
}

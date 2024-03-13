using UnityEngine;

public class Heal : MonoBehaviour
{
    [SerializeField] private int healCount;
    [SerializeField] private GameObject healEffectGameObject;
    [SerializeField] private AudioClip healClip;

    private bool checking = false;
    private void Start()
    {
        Invoke(nameof(InvokeChecking), 1);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.GetComponent<Target>() != null && checking)
        {
            collision.gameObject.GetComponent<Target>().Heal(healCount);
            EffectManager.PlayEffect("Heal Effect");
            GameObject audioInstance = Instantiate(new GameObject(), transform.position, transform.rotation);
            AudioSource audioSource = audioInstance.AddComponent<AudioSource>();
            audioSource.clip = healClip;
            audioSource.Play();

            Destroy(audioInstance, audioSource.clip.length);

            Destroy(Instantiate(healEffectGameObject, transform.position, transform.rotation), 1.5f);
            Destroy(gameObject);
        }
    }

    private void InvokeChecking()
    {
        checking = true;
    }
}

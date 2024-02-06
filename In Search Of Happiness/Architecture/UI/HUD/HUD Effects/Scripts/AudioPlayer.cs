using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    private AudioSource audioSource;

    private void OnEnable()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    public void Play()
    {
        audioSource.Play();
    }

    public void Play(AudioClip clip)
    {
        audioSource.clip = clip;
        audioSource.Play();
    }
}

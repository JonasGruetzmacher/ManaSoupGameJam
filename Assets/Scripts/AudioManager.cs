using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [SerializeField] Slider volumeSlider;

    [SerializeField] AudioSource audioSourcePrefab;

    [SerializeField] AudioClip[] audioClips;
    [SerializeField] int[] numberOfAudioClips;

    List<AudioSource> allAudioClips = new List<AudioSource>();

    public float sfxVolume = 1f;
    public float musicVolume = 1f;

    public void setVolume()
    {
        sfxVolume = volumeSlider.value;
        musicVolume = volumeSlider.value;
    }

    void InitSFX()
    {
        for (int i = 0; i < audioClips.Length; i++)
        {
            for (int j = 0; j < numberOfAudioClips[i]; j++)
            {
                AudioSource spawned = transform.AddComponent<AudioSource>();
                spawned.clip = audioClips[i];
                allAudioClips.Add(spawned);
            }
        }
    }

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        InitSFX();

    }

    public void PlayAudio(int index)
    {
        int indexToSpawn = 0;
        int maxIndexToSpawn = 0;

        for (int i = 0; i < index; i++)
        {
            indexToSpawn += numberOfAudioClips[i];
        }

        maxIndexToSpawn = indexToSpawn + numberOfAudioClips[index];

        for (int k = indexToSpawn; k < maxIndexToSpawn; k++)
        {
            if (!allAudioClips[k].gameObject.activeSelf || !allAudioClips[k].isPlaying)
            {
                allAudioClips[k].gameObject.SetActive(true);
                allAudioClips[k].volume = sfxVolume;
                allAudioClips[k].clip = audioClips[index];
                allAudioClips[k].Play();
                return;
            }
        }
    }

    public IEnumerator FadeInSound(AudioSource source, float time = 1f)
    {
        for (int i = 0; i < 1000; i++)
        {
            source.volume += 0.001f;
            yield return new WaitForSeconds(time / 1000f);
        }
        source.volume = 1;
    }
    public IEnumerator FadeOutSound(AudioSource source, float time = 1f)
    {
        for (int i = 0; i < 1000; i++)
        {
            source.volume -= 0.001f;
            yield return new WaitForSeconds(time / 1000f);
        }
        source.volume = 0;
    }
}

public enum Audio
{
    Beam,
    PickUp,
    GhostDie
}

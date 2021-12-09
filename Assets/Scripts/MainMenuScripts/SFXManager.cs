using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public enum SFXID
{
    ShootLaser,
    UIClick,
    PlayerHit,
    ShieldHit
}
public class SFXManager : MonoBehaviour
{
    private SFXManager() { }

    private static SFXManager instance = null;
    public static SFXManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<SFXManager>();
                DontDestroyOnLoad(instance.transform.root);
            }
            return instance;
        }
        private set { instance = value; }
    }

    [SerializeField] List<AudioClip> sfxTracks;
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioMixer mixer;
    public void PlaySFX(SFXID id)
    {
        audioSource.PlayOneShot(sfxTracks[(int)id]);
    }
    void DestoryAllClones()
    {
        SFXManager[] clones = FindObjectsOfType<SFXManager>();
        foreach (SFXManager clone in clones)
        {
            if (clone != Instance)
            {
                Destroy(clone.gameObject);
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        DestoryAllClones();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void setVolume(float volumeDB)
    {
        mixer.SetFloat("VolumeMusic", volumeDB);
    }

}

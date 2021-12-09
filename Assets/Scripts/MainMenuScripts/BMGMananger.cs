using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
public enum TrackID
{
    StartMenu,
    MissionMenu,
    BattleMusic,
}
public class BMGMananger : MonoBehaviour
{   
    private BMGMananger() { }

    private static BMGMananger instance = null;
    public static BMGMananger Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<BMGMananger>();
                DontDestroyOnLoad(instance.transform.root);
            }
            return instance;
        }
        private set { instance = value; }
    }

    [SerializeField] List<AudioClip> musicTracks;
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioMixer mixer;
    public void PlayTrack(TrackID id)
    {
        audioSource.clip = musicTracks[(int)id];
        audioSource.Play();

    }

    void DestoryAllClones()
    {
        BMGMananger[] clones = FindObjectsOfType<BMGMananger>();
        foreach (BMGMananger clone in clones)
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
        Instance.PlayTrack(TrackID.StartMenu);
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

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour
{
    [Header("UI Components")]
    [SerializeField] private Dropdown musicDropdown;

    [Header("Music Settings")]
    [SerializeField] private AudioClip[] musicTracks;
    [SerializeField] private AudioSource backgroundMusicSource;

    private static MusicManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);

            if (backgroundMusicSource == null)
            {
                backgroundMusicSource = gameObject.AddComponent<AudioSource>();
                backgroundMusicSource.loop = true;
                backgroundMusicSource.playOnAwake = false;
            }

            // Load saved music index
            int savedTrackIndex = PlayerPrefs.GetInt("MusicTrack", 0);
            PlayMusic(savedTrackIndex);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
        TryFindDropdown();
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        TryFindDropdown();
    }

    private void TryFindDropdown()
    {
        musicDropdown = FindObjectOfType<Dropdown>();
        if (musicDropdown != null)
        {
            int savedTrackIndex = PlayerPrefs.GetInt("MusicTrack", 0);
            musicDropdown.value = savedTrackIndex;
            musicDropdown.onValueChanged.RemoveAllListeners();
            musicDropdown.onValueChanged.AddListener(ChangeMusic);
        }
    }

    public void ChangeMusic(int index)
    {
        PlayMusic(index);
        PlayerPrefs.SetInt("MusicTrack", index);
        PlayerPrefs.Save();
    }

    private void PlayMusic(int index)
    {
        if (index >= 0 && index < musicTracks.Length)
        {
            backgroundMusicSource.clip = musicTracks[index];
            backgroundMusicSource.Play();
        }
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
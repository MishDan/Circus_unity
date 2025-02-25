using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class VolumeControl : MonoBehaviour
{
    [SerializeField] private Slider volumeSlider;

    private static VolumeControl instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void Start()
    {
        LoadVolume();
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        TryFindSlider();
    }

    private void TryFindSlider()
    {
        volumeSlider = FindObjectOfType<Slider>();
        if (volumeSlider != null)
        {
            volumeSlider.value = AudioListener.volume;
            volumeSlider.onValueChanged.RemoveAllListeners();
            volumeSlider.onValueChanged.AddListener(UpdateVolume);
        }
    }

    private void LoadVolume()
    {
        float savedVolume = PlayerPrefs.GetFloat("Volume", 1f);
        AudioListener.volume = savedVolume;
    }

    public void UpdateVolume(float volume)
    {
        AudioListener.volume = volume;
        PlayerPrefs.SetFloat("Volume", volume);
        PlayerPrefs.Save();
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
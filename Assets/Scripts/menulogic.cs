using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class menulogic : MonoBehaviour
{
    public GameObject MapSelectPanel;
    public GameObject MainButtons;
    public GameObject SettingsPanel;
    public GameObject MonkeyPanel;
    
    public AudioSource musicSource;
    public Slider musicSlider;
    public Slider gameSoundsSlider;
    public static float temporaryGameVolume = 1f; //tymczasowe

    void Start()
    {
        musicSlider.value = 1f;
        musicSource.volume = 1f;
        gameSoundsSlider.value = 1f;
        temporaryGameVolume = 1f;
    }

    public void OpenMapSelectPanel()
    {
        MapSelectPanel.SetActive(true);
        MainButtons.SetActive(false);
    }

    public void CloseMapSelectPanel()
    {
        MapSelectPanel.SetActive(false);
        MainButtons.SetActive(true);
    }

    public void LoadMap(string mapName)
    {
        SceneManager.LoadScene(mapName);
    }

    public void OpenSettings()
    {
        SettingsPanel.SetActive(true);
        MainButtons.SetActive(false);
    }

    public void CloseSettings()
    {
        SettingsPanel.SetActive(false);
        MainButtons.SetActive(true);
    }

    public void OpenMonkeyPanel()
    {
        MonkeyPanel.SetActive(true);
        MainButtons.SetActive(false);
    }

    public void CloseMonkeyPanel()
    {
        MonkeyPanel.SetActive(false);
        MainButtons.SetActive(true);
    }

    public void ChangeMusicVolume(float volume)
    {
        musicSource.volume = volume;
    }

    public void ChangeGameSoundsVolume(float volume)
    {
        temporaryGameVolume = volume; 
    }

    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }
}

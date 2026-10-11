using UnityEngine;
using UnityEngine.SceneManagement;

public class menulogic : MonoBehaviour
{
    public GameObject MapSelectPanel;
    public GameObject MainButtons;

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
}

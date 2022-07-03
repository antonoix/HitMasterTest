using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Button _restart;
    [SerializeField] private Slider _progress;

    public void ActivateRestart()
    {
        _restart.gameObject.SetActive(true);
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void UpdateProgress(int current, int total)
    {
        _progress.value = (float)current / total;
    }
}

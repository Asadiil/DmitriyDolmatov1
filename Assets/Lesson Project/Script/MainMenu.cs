
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Button _startGameButton;
    [SerializeField] private Button _quitGameButton;
    public Slider _sl;

    private void Awake()
    {
        _quitGameButton.onClick.AddListener(() => { Application.Quit(); });
        _startGameButton.onClick.AddListener(StartGame);

        _sl.onValueChanged.AddListener((float value)=>
        {
            Debug.Log(value);
        });
    }

    private void StartGame()
    {
        SceneManager.LoadScene(1);
    }
}

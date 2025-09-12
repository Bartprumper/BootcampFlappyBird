using UnityEngine;
using UnityEngine.UIElements;

public class MainMenuEvents : MonoBehaviour
{
    private UIDocument uiDocument;
    private Button startButton;
    private Button quitButton;
    public GameObject player;
    public GameObject obstacles;

    private void Awake()
    {
        uiDocument = GetComponent<UIDocument>();
        startButton = uiDocument.rootVisualElement.Q("StartGame") as Button;
        quitButton = uiDocument.rootVisualElement.Q("QuitGame") as Button;
        startButton.RegisterCallback<ClickEvent>(OnStartGameClick);
        quitButton.RegisterCallback<ClickEvent>(OnQuitGameClick);

    }

    private void OnStartGameClick(ClickEvent evt)
    {
        player.SetActive(true);
        obstacles.SetActive(true);
        //scoreText.gameObject.SetActive(true);
        transform.gameObject.SetActive(false);
    }

    private void OnQuitGameClick(ClickEvent evt)
    {
        Application.Quit();
    }

    private void OnDisable()
    {
        startButton.UnregisterCallback<ClickEvent>(OnStartGameClick);
        quitButton.UnregisterCallback<ClickEvent>(OnQuitGameClick);
    }
}

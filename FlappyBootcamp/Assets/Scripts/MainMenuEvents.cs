using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

public class MainMenuEvents : MonoBehaviour
{
    private UIDocument uiDocument;
    private Button startButton;
    private Button quitButton;
    private Label title;
    public GameObject player;
    public GameObject obstacles;
    public GameObject tunnel;

    private void Awake()
    {
        uiDocument = GetComponent<UIDocument>();
        startButton = uiDocument.rootVisualElement.Q("StartGame") as Button;
        quitButton = uiDocument.rootVisualElement.Q("QuitGame") as Button;
        title = uiDocument.rootVisualElement.Q<Label>("Title") as Label;
        startButton.RegisterCallback<ClickEvent>(OnStartGameClick);
        quitButton.RegisterCallback<ClickEvent>(OnQuitGameClick);

    }

    private void OnStartGameClick(ClickEvent evt)
    {
        tunnel.SetActive(true);
        obstacles.SetActive(true);
        title.text = "Ready?";
        startButton.style.display = DisplayStyle.None;
        quitButton.style.display = DisplayStyle.None;
        StartCoroutine(ActivatePlayer());
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

    private IEnumerator ActivatePlayer()
    {
        yield return new WaitForSeconds(2f);
        player.SetActive(true);
        transform.gameObject.SetActive(false);
    }
}

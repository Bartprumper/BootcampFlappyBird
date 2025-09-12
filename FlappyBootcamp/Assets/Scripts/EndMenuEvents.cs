using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class EndMenuEvents : MonoBehaviour
{
    private UIDocument uIDocument;
    private Button restartButton;
    private Button quitButton;
    private void Awake()
    {
        uIDocument = GetComponent<UIDocument>();
        restartButton = uIDocument.rootVisualElement.Q<Button>("RestartGame") as Button;
        quitButton = uIDocument.rootVisualElement.Q<Button>("QuitGame") as Button;
        restartButton.RegisterCallback<ClickEvent>(OnRestartGameClick);
        quitButton.RegisterCallback<ClickEvent>(OnQuitGameClick);
    }

    private void OnRestartGameClick(ClickEvent evt)
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void OnQuitGameClick(ClickEvent evt)
    {
        Application.Quit();
    }

    private void OnDisable()
    {
        restartButton.UnregisterCallback<ClickEvent>(OnRestartGameClick);
        quitButton.UnregisterCallback<ClickEvent>(OnQuitGameClick);
    }
}

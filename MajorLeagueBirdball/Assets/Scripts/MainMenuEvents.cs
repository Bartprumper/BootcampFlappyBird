using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MainMenuEvents : MonoBehaviour
{
    private UIDocument uiDocument;
    private Button startButton;
    private Button quitButton;
    private Button rulesButton;
    private Button returnButton;
    private Label title;
    private Label rulesText;
    public GameObject player;
    public GameObject obstacles;
    public GameObject tunnel;
    public AudioClip startSFX;
    public AudioClip buttonSFX;
    private List<Button> allButtons = new List<Button>();

    private void Awake()
    {
        uiDocument = GetComponent<UIDocument>();
        startButton = uiDocument.rootVisualElement.Q("StartGame") as Button;
        quitButton = uiDocument.rootVisualElement.Q("QuitGame") as Button;
        rulesButton = uiDocument.rootVisualElement.Q("Rules") as Button;
        returnButton = uiDocument.rootVisualElement.Q("Return") as Button;
        returnButton.style.display = DisplayStyle.None;
        title = uiDocument.rootVisualElement.Q<Label>("Title") as Label;
        rulesText = uiDocument.rootVisualElement.Q<Label>("RulesText") as Label;
        rulesText.style.display = DisplayStyle.None;
        startButton.RegisterCallback<ClickEvent>(OnStartGameClick);
        quitButton.RegisterCallback<ClickEvent>(OnQuitGameClick);
        rulesButton.RegisterCallback<ClickEvent>(OnRulesClick);
        returnButton.RegisterCallback<ClickEvent>(OnReturnClick);

        allButtons = uiDocument.rootVisualElement.Query<Button>().ToList();
        for (int i = 0; i < allButtons.Count; i++)
        {
            allButtons[i].RegisterCallback<ClickEvent>(OnAllButtonClicks);
        }
    }

    private void OnAllButtonClicks(ClickEvent evt)
    {
        SFXManager.instance.PlaySFXClip(buttonSFX, transform, 1f, 1f);
    }

    private void OnStartGameClick(ClickEvent evt)
    {
        tunnel.SetActive(true);
        obstacles.SetActive(true);
        title.text = "Ready?";
        startButton.style.display = DisplayStyle.None;
        quitButton.style.display = DisplayStyle.None;
        rulesButton.style.display = DisplayStyle.None;
        StartCoroutine(ActivatePlayer());
        SFXManager.instance.PlaySFXClip(startSFX, transform, 1f, 1f);
    }

    private void OnRulesClick(ClickEvent evt)
    {
        title.style.display = DisplayStyle.None;
        rulesButton.style.display = DisplayStyle.None;
        startButton.style.display = DisplayStyle.None;
        quitButton.style.display = DisplayStyle.None;
        rulesText.style.display = DisplayStyle.Flex;
        returnButton.style.display = DisplayStyle.Flex;
    }

    private void OnReturnClick(ClickEvent evt)
    {
        title.style.display = DisplayStyle.Flex;
        rulesButton.style.display = DisplayStyle.Flex;
        startButton.style.display = DisplayStyle.Flex;
        quitButton.style.display = DisplayStyle.Flex;
        rulesText.style.display = DisplayStyle.None;
        returnButton.style.display = DisplayStyle.None;
    }

    private void OnQuitGameClick(ClickEvent evt)
    {
        Application.Quit();
    }

    private void OnDisable()
    {
        startButton.UnregisterCallback<ClickEvent>(OnStartGameClick);
        quitButton.UnregisterCallback<ClickEvent>(OnQuitGameClick);
        rulesButton.UnregisterCallback<ClickEvent>(OnRulesClick);
        returnButton.UnregisterCallback<ClickEvent>(OnReturnClick);

        for (int i = 0; i < allButtons.Count; i++)
        {
            allButtons[i].UnregisterCallback<ClickEvent>(OnAllButtonClicks);
        }
    }

    private IEnumerator ActivatePlayer()
    {
        yield return new WaitForSeconds(2f);
        player.SetActive(true);
        
        transform.gameObject.SetActive(false);
    }
}

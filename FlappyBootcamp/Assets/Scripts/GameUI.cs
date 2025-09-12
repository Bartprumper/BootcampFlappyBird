using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

public class GameUI : MonoBehaviour
{
    private Label speedText;
    private Label scoreText;
    private UIDocument uiDocument;
    void Awake()
    {
        uiDocument = GetComponent<UIDocument>();
        speedText = uiDocument.rootVisualElement.Q<Label>("SpeedText") as Label;
        speedText.style.display = DisplayStyle.None;
        scoreText = uiDocument.rootVisualElement.Q<Label>("ScoreText") as Label;
    }

    public void UpdateScore(float score)
    {
        scoreText.text = "Score: " + Mathf.FloorToInt(score).ToString();
    }

    public void ShowSpeedText()
    {
        speedText.style.display = DisplayStyle.Flex;
        StartCoroutine("HideSpeedText");
    }

    private IEnumerable HideSpeedText()
    {
        yield return new WaitForSeconds(2);
        speedText.style.display = DisplayStyle.None;
    }
    



}

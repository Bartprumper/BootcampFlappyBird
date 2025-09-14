using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

public class GameUI : MonoBehaviour
{
    private Label speedText;
    private Label scoreText;
    private Label bonusScore;
    private UIDocument uiDocument;
    private float finalScoreYPos;
    void Awake()
    {
        uiDocument = GetComponent<UIDocument>();
        speedText = uiDocument.rootVisualElement.Q<Label>("SpeedIncrease") as Label;
        speedText.style.display = DisplayStyle.None;
        scoreText = uiDocument.rootVisualElement.Q<Label>("ScoreCounter") as Label;
        scoreText.style.display = DisplayStyle.None;
        bonusScore = uiDocument.rootVisualElement.Q<Label>("BonusScore") as Label;
        bonusScore.style.display = DisplayStyle.None;
        finalScoreYPos = scoreText.transform.position.y + 250;
    }

    public void UpdateScore(float score)
    {
        if (scoreText.style.display == DisplayStyle.None)
        {
            scoreText.style.display = DisplayStyle.Flex;
        }
        scoreText.text = "Score: " + Mathf.FloorToInt(score).ToString();
    }

    public void ShowSpeedText()
    {
        speedText.style.display = DisplayStyle.Flex;
        StartCoroutine(HideText(speedText, 2f));
    }

    public void ShowBonusScore()
    {
        bonusScore.style.display = DisplayStyle.Flex;
        StartCoroutine(HideText(bonusScore, 1f));
    }

    public void FinalScore(float score)
    {
        scoreText.style.fontSize = 65;
        scoreText.transform.position = new Vector3(scoreText.transform.position.x, finalScoreYPos, scoreText.transform.position.z);
    }

    private IEnumerator HideText(Label text, float delay)
    {
        yield return new WaitForSeconds(delay);
        text.style.display = DisplayStyle.None;
    }
    



}

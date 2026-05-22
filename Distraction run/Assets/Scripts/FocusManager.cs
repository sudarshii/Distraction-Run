using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class FocusManager : MonoBehaviour
{
    public static FocusManager instance;

    public Slider focusBar;

    public GameObject startPanel;
    public TMP_Text startText;

    public TMP_Text pointText;

    public GameObject endPanel;
    public TMP_Text endText;

    public int focusPoints = 100;
    public int maxFocus = 200;
    public int winPoint = 160;
    public int losePoint = 40;

    private bool gameEnded = false;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        Time.timeScale = 1;

        focusBar.minValue = 0;
        focusBar.maxValue = maxFocus;
        focusBar.value = focusPoints;

        startPanel.SetActive(false);
        pointText.gameObject.SetActive(false);
        endPanel.SetActive(false);

        StartCoroutine(StartMessage());
    }

    IEnumerator StartMessage()
    {
        startPanel.SetActive(true);
        startText.text = "Interact with the things that will make you smart.";

        yield return new WaitForSeconds(4f);

        startPanel.SetActive(false);
    }

    public void ChangeFocus(int amount)
    {
        if (gameEnded) return;

        focusPoints += amount;
        focusPoints = Mathf.Clamp(focusPoints, 0, maxFocus);

        focusBar.value = focusPoints;

        StartCoroutine(ShowPoints(amount));

        if (focusPoints >= winPoint)
        {
            StartCoroutine(EndGame("Great job. You'll pass the exam."));
        }
        else if (focusPoints <= losePoint)
        {
            StartCoroutine(EndGame("You need to focus more on your studies."));
        }
    }

    IEnumerator ShowPoints(int amount)
    {
        pointText.gameObject.SetActive(true);

        if (amount > 0)
            pointText.text = "+" + amount + " Focus";
        else
            pointText.text = amount + " Focus";

        yield return new WaitForSeconds(2f);

        pointText.gameObject.SetActive(false);
    }

    IEnumerator EndGame(string message)
    {
        gameEnded = true;

        endPanel.SetActive(true);
        endText.text = message;

        yield return new WaitForSeconds(4f);

        Time.timeScale = 0;
    }
}
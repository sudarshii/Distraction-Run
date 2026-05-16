using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class FocusManager : MonoBehaviour
{
    public static FocusManager instance;

    public Slider focusBar;
    public TMP_Text messageText;

    public int focusPoints = 50;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        UpdateUI();

        messageText.text = "";
        messageText.gameObject.SetActive(false);
    }

    public void ChangeFocus(int amount)
    {
        focusPoints += amount;

        focusPoints = Mathf.Clamp(focusPoints, 0, 100);

        UpdateUI();

        StartCoroutine(ShowMessage(amount));
    }

    void UpdateUI()
    {
        focusBar.value = focusPoints;
    }

    IEnumerator ShowMessage(int amount)
    {
        messageText.gameObject.SetActive(true);

        if (focusPoints <= 0)
        {
            messageText.text = "You need to focus more on your studies.";
        }
        else if (focusPoints >= 100)
        {
            messageText.text = "Keep going. You can pass the exam.";
        }
        else
        {
            if (amount > 0)
            {
                messageText.text = "+" + amount + " Focus";
            }
            else
            {
                messageText.text = amount + " Focus";
            }
        }

        yield return new WaitForSeconds(2f);

        messageText.gameObject.SetActive(false);
    }
}
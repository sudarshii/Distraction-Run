using UnityEngine;
using TMPro;

public class BookInteraction : MonoBehaviour
{
    public Transform book;
    public GameObject interactText;
    public TMP_Text pointText;

    public float interactionDistance = 3f;
    public int focusPoints = 100;
    public int focusGain = 15;

    private bool bookUsed = false;

    void Start()
    {
        interactText.SetActive(false);
        pointText.text = "";
    }

    void Update()
    {
        float distance = Vector3.Distance(transform.position, book.position);

        if (distance <= interactionDistance && !bookUsed)
        {
            interactText.SetActive(true);

            if (Input.GetKeyDown(KeyCode.E))
            {
                focusPoints += focusGain;

                pointText.text = "+" + focusGain + " Focus";

                interactText.SetActive(false);

                bookUsed = true;
            }
        }
        else
        {
            interactText.SetActive(false);
        }
    }
}
using UnityEngine;
using TMPro;

public class GameInteraction : MonoBehaviour
{
    public Transform gameObjectItem;
    public GameObject interactText;
    public TMP_Text pointText;

    public float interactionDistance = 3f;
    public int focusPoints = 100;
    public int focusLoss = 15;

    private bool gameUsed = false;

    void Start()
    {
        interactText.SetActive(false);
        pointText.text = "";
    }

    void Update()
    {
        float distance = Vector3.Distance(transform.position, gameObjectItem.position);

        if (distance <= interactionDistance && !gameUsed)
        {
            interactText.SetActive(true);

            if (Input.GetKeyDown(KeyCode.E))
            {
                focusPoints -= focusLoss;

                pointText.text = "-" + focusLoss + " Focus";

                interactText.SetActive(false);

                gameUsed = true;
            }
        }
        else
        {
            interactText.SetActive(false);
        }
    }
}
using UnityEngine;
using TMPro;
using System.Collections;

public class GameInteraction : MonoBehaviour
{
    public Transform gameObjectItem;
    public GameObject interactText;
    public TMP_Text PlayText;

    public float interactionDistance = 3f;

    public int focusPoints = 100;
    public int focusLoss = 30;

    private bool gameUsed = false;

    void Start()
    {
        interactText.SetActive(false);

        PlayText.text = "";
        PlayText.gameObject.SetActive(false);
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

                StartCoroutine(ShowPoints());

                interactText.SetActive(false);

                gameUsed = true;
            }
        }
        else
        {
            interactText.SetActive(false);
        }
    }

    IEnumerator ShowPoints()
    {
        PlayText.gameObject.SetActive(true);

        PlayText.text = "-" + focusLoss + " Focus";

        yield return new WaitForSeconds(2f);

        PlayText.gameObject.SetActive(false);
    }
}
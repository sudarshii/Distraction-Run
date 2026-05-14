using UnityEngine;
using TMPro;
using System.Collections;

public class BookInteraction : MonoBehaviour
{
    public Transform book;
    public GameObject interactText;
    public TMP_Text KitabText;

    public float interactionDistance = 3f;
    public int focusPoints = 100;
    public int focusGain = 40;

    private bool bookUsed = false;

    void Start()
    {
        interactText.SetActive(false);

        KitabText.text = "";
        KitabText.gameObject.SetActive(false);
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

                StartCoroutine(ShowPoints());

                interactText.SetActive(false);

                bookUsed = true;
            }
        }
        else
        {
            interactText.SetActive(false);
        }
    }

    IEnumerator ShowPoints()
    {
        KitabText.gameObject.SetActive(true);

        KitabText.text = "+" + focusGain + " Focus";

        yield return new WaitForSeconds(2f);

        KitabText.gameObject.SetActive(false);
    }
}
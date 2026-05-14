using UnityEngine;
using TMPro;
using System.Collections;

public class LaptopInteraction : MonoBehaviour
{
    public Transform laptop;
    public GameObject interactText;
    public TMP_Text LappyText;

    public float interactionDistance = 3f;
    public int focusPoints = 100;
    public int laptopPoints = 30;

    private bool laptopUsed = false;

    void Start()
    {
        interactText.SetActive(false);

        LappyText.text = "";
        LappyText.gameObject.SetActive(false);
    }

    void Update()
    {
        float distance = Vector3.Distance(transform.position, laptop.position);

        if (distance <= interactionDistance && !laptopUsed)
        {
            interactText.SetActive(true);

            if (Input.GetKeyDown(KeyCode.E))
            {
                focusPoints -= laptopPoints;

                StartCoroutine(ShowPoints());

                interactText.SetActive(false);

                laptopUsed = true;

                Debug.Log("Laptop Used!");
            }
        }
        else
        {
            interactText.SetActive(false);
        }
    }

    IEnumerator ShowPoints()
    {
        LappyText.gameObject.SetActive(true);

        LappyText.text = "-" + laptopPoints + " Focus";

        yield return new WaitForSeconds(2f);

        LappyText.gameObject.SetActive(false);
    }
}
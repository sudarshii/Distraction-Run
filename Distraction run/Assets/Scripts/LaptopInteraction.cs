using UnityEngine;
using TMPro;

public class LaptopInteraction : MonoBehaviour
{
    public Transform laptop;
    public GameObject interactText;
    public TMP_Text pointText;

    public float interactionDistance = 3f;
    public int focusPoints = 100;
    public int laptopPoints = 20;

    private bool laptopUsed = false;

    void Start()
    {
        interactText.SetActive(false);
        pointText.text = "";
    }

    void Update()
    {
        float distance = Vector3.Distance(transform.position, laptop.position);

        if (distance <= interactionDistance && !laptopUsed)
        {
            interactText.SetActive(true);

            if (Input.GetKeyDown(KeyCode.E))
            {
                focusPoints += laptopPoints;

                pointText.text = "+" + laptopPoints + " Focus";

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
}
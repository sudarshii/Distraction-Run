using UnityEngine;
using TMPro;

public class PhoneInteraction : MonoBehaviour
{
    public Transform phone;
    public GameObject interactText;
    public TMP_Text pointText;

    public float interactionDistance = 3f;
    public int focusPoints = 100;
    public int phoneDeduction = 10;

    private bool phoneUsed = false;

    void Start()
    {
        interactText.SetActive(false);
        pointText.text = "";
    }

    void Update()
    {
        float distance = Vector3.Distance(transform.position, phone.position);

        if (distance <= interactionDistance && !phoneUsed)
        {
            interactText.SetActive(true);

            if (Input.GetKeyDown(KeyCode.E))
            {
                focusPoints -= phoneDeduction;
                pointText.text = "-" + phoneDeduction + " Focus | Focus Left: " + focusPoints;
                interactText.SetActive(false);
                phoneUsed = true;

                Debug.Log("Phone used. -" + phoneDeduction + " Focus. Focus Left: " + focusPoints);
            }
        }
        else
        {
            interactText.SetActive(false);
        }
    }
}
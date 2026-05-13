using UnityEngine;
using TMPro;

public class BedInteraction : MonoBehaviour
{
    public Transform bed;
    public GameObject interactText;
    public TMP_Text pointText;

    public float interactionDistance = 3f;
    public int focusPoints = 100;
    public int focusLoss = 20;

    private bool bedUsed = false;

    void Start()
    {
        interactText.SetActive(false);
        pointText.text = "";
    }

    void Update()
    {
        float distance = Vector3.Distance(transform.position, bed.position);

        if (distance <= interactionDistance && !bedUsed)
        {
            interactText.SetActive(true);

            if (Input.GetKeyDown(KeyCode.E))
            {
                focusPoints -= focusLoss;

                pointText.text = "-" + focusLoss + " Focus";

                interactText.SetActive(false);

                bedUsed = true;
            }
        }
        else
        {
            interactText.SetActive(false);
        }
    }
}
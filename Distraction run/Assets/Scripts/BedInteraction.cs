using UnityEngine;

public class BedInteraction : MonoBehaviour
{
    public Transform bed;
    public GameObject interactText;

    public float interactionDistance = 3f;

    private bool bedUsed = false;

    void Start()
    {
        interactText.SetActive(false);
    }

    void Update()
    {
        float distance = Vector3.Distance(transform.position, bed.position);

        if (distance <= interactionDistance && !bedUsed)
        {
            interactText.SetActive(true);

            if (Input.GetKeyDown(KeyCode.E))
            {
                FocusManager.instance.ChangeFocus(-30);

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
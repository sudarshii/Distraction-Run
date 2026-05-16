using UnityEngine;

public class GameInteraction : MonoBehaviour
{
    public Transform gameObjectItem;
    public GameObject interactText;

    public float interactionDistance = 3f;

    private bool gameUsed = false;

    void Start()
    {
        interactText.SetActive(false);
    }

    void Update()
    {
        float distance = Vector3.Distance(transform.position, gameObjectItem.position);

        if (distance <= interactionDistance && !gameUsed)
        {
            interactText.SetActive(true);

            if (Input.GetKeyDown(KeyCode.E))
            {
                FocusManager.instance.ChangeFocus(-30);

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
using System.Collections;
using UnityEngine;

namespace SojaExiles
{
    public class opencloseStallDoor : MonoBehaviour
    {
        public Animator openandclose;
        public bool open;
        public Transform Player;

        void Start()
        {
            open = false;
        }

        void Update()
        {
            if (Player)
            {
                float dist = Vector3.Distance(Player.position, transform.position);

                if (dist < 2)
                {
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        if (open == false)
                        {
                            StartCoroutine(opening());
                        }
                        else
                        {
                            StartCoroutine(closing());
                        }
                    }
                }
            }
        }

        IEnumerator opening()
        {
            print("Opening Door");
            openandclose.Play("OpeningStall");
            open = true;
            yield return new WaitForSeconds(0.5f);
        }

        IEnumerator closing()
        {
            print("Closing Door");
            openandclose.Play("ClosingStall");
            open = false;
            yield return new WaitForSeconds(0.5f);
        }
    }
}
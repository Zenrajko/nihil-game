using UnityEngine;

public class DialogTrigger : MonoBehaviour
{
    [SerializeField] string[] messages;
    [SerializeField] HelmetLog helmetLog;

    bool hasFired = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && helmetLog != null && !hasFired)
        {
            hasFired = true;
            helmetLog.Play(messages);
        }
    }
}
using UnityEngine;
using System.Collections;
using StarterAssets;

public class DialogTrigger : MonoBehaviour
{
    [SerializeField] string[] messages;
    [SerializeField] HelmetLog helmetLog;
    [SerializeField] GameObject cutCam;
    [SerializeField] Letterbox letterbox;
    [SerializeField] FirstPersonController controller;
    [SerializeField] float faceYaw;
    [SerializeField] float facePitch;

    bool hasFired = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && helmetLog != null && !hasFired)
        {
            hasFired = true;
            LockControl();
            if (letterbox != null)
                letterbox.Show();
            StartCoroutine(PlayAndRelease());
        }
    }

    IEnumerator PlayAndRelease()
    {
        yield return helmetLog.PlayRoutine(messages);
        if (cutCam != null)
            cutCam.SetActive(false);
        if (controller != null)
            controller.SetLookRotation(facePitch, faceYaw);
        UnlockControl();
        if (letterbox != null)
            letterbox.Hide();
    }

    void LockControl() => controller.enabled = false;
    void UnlockControl() => controller.enabled = true;
}
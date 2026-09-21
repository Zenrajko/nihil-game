using UnityEngine;
using TMPro;

public class TargetCompass : MonoBehaviour
{
    [SerializeField] Transform playerCamera;
    [SerializeField] Transform target;
    [SerializeField] RectTransform arrow;

    void Update()
    {
        if (playerCamera == null || target == null || arrow == null)
            return;

        Vector3 dir = target.position - playerCamera.position;
        dir.y = 0f;
        float angle = Vector3.SignedAngle(playerCamera.forward, dir, Vector3.up);
        arrow.localRotation = Quaternion.Euler(0f, 0f, angle);
    }
}
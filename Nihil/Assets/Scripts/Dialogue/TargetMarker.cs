using UnityEngine;

public class TargetMarker : MonoBehaviour
{
    [SerializeField] Camera playerCamera;
    [SerializeField] Transform target;
    [SerializeField] RectTransform marker;

    const float margin = 20f;

    [SerializeField] float appearDur = 0.35f;
    [SerializeField] float appearScale = 2f;

    CanvasGroup group;
    float appearT = -1f;

    void Start()
    {
        if (marker == null)
            return;
        group = marker.GetComponent<CanvasGroup>();
        if (group == null)
            group = marker.gameObject.AddComponent<CanvasGroup>();
    }

    public void SetVisible(bool visible)
    {
        if (!visible)
        {
            marker.gameObject.SetActive(false);
            return;
        }
        if (marker.gameObject.activeSelf)
            return;

        marker.gameObject.SetActive(true);
        marker.localScale = Vector3.one * appearScale;
        group.alpha = 0f;
        appearT = 0f;
    }

    void Update()
    {
        if (playerCamera == null || target == null || marker == null)
            return;

        RectTransform canvas = (RectTransform)transform;
        Vector3 vp = playerCamera.WorldToViewportPoint(target.position);
        Vector2 half = canvas.rect.size * 0.5f;

        Vector2 off;
        if (vp.z < 0f)
        {
            // Behind the camera: mirror to the "turn around" side, then push
            // the marker onto the border ring so it always says which way to turn.
            off = new Vector2(1f - vp.x - 0.5f, 1f - vp.y - 0.5f) * canvas.rect.size;
            float rx = Mathf.Abs(off.x) > 0.1f ? (half.x - margin) / Mathf.Abs(off.x) : float.PositiveInfinity;
            float ry = Mathf.Abs(off.y) > 0.1f ? (half.y - margin) / Mathf.Abs(off.y) : float.PositiveInfinity;
            float seek = Mathf.Min(rx, ry);
            if (float.IsInfinity(seek))
                off = new Vector2(0f, -(half.y - margin)); // dead behind: fall back to the bottom edge
            else
                off *= seek;
        }
        else
        {
            off = new Vector2(vp.x - 0.5f, vp.y - 0.5f) * canvas.rect.size;
        }

        off.x = Mathf.Clamp(off.x, -half.x + margin, half.x - margin);
        off.y = Mathf.Clamp(off.y, -half.y + margin, half.y - margin);
        marker.anchoredPosition = off;

        if (appearT >= 0f)
        {
            appearT += Time.deltaTime;
            float k = Mathf.Clamp01(appearT / appearDur);
            k = k * k * (3f - 2f * k); // smoothstep ease
            marker.localScale = Vector3.Lerp(Vector3.one * appearScale, Vector3.one, k);
            group.alpha = Mathf.Lerp(0f, 1f, k);
            if (appearT >= appearDur)
                appearT = -1f;
        }
    }
}
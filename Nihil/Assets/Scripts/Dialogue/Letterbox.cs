using UnityEngine;

public class Letterbox : MonoBehaviour
{
    public RectTransform topBar;
    public RectTransform bottomBar;
    public float barHeight = 100f;
    public float slideTime = 0.5f;

    float from;
    float to;
    float t;
    bool sliding;

    public void Show() => StartSlide(barHeight);
    public void Hide() => StartSlide(0f);

    void StartSlide(float target)
    {
        from = topBar.sizeDelta.y;
        to = target;
        t = 0f;
        sliding = true;
    }

    void Update()
    {
        if (!sliding)
            return;
        t += Time.deltaTime / slideTime;
        float h = Mathf.SmoothStep(from, to, Mathf.Clamp01(t));
        topBar.sizeDelta = new Vector2(topBar.sizeDelta.x, h);
        bottomBar.sizeDelta = new Vector2(bottomBar.sizeDelta.x, h);
        if (t >= 1f)
            sliding = false;
    }
}
using System.Collections;
using UnityEngine;
using TMPro;

public class HelmetLog : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI [] lines;
    [SerializeField] TextMeshProUGUI playerChat;

    [SerializeField] float charDelay = 0.06f;
    [SerializeField] float holdSeconds = 1.5f;
    [SerializeField] float fadeSeconds = 1f;

    [SerializeField] TargetMarker targetMarker;

    [SerializeField] AudioClip typeBeep;
    AudioSource beepSource;

    void Start()
    {
        beepSource = gameObject.AddComponent<AudioSource>();
        beepSource.playOnAwake = false;
        beepSource.pitch = 3;

        for (int i = 0; i < lines.Length; i++)
        {
            lines[i].gameObject.SetActive(true);
            lines[i].text = "";
        }
        //return; // Disable for now to speed up testing
        Play(new string[]
        {
            "#Landing completed. All indicators nominal.",
            "#Welcome to Nihil-01, Cole",
            "#..What are you wearing?",
            "It's an open channel, Maggie",
            "#Sorry ;D",
            "@targetMarker:on",
            "#The energy source should be on your scope now",
            "#We placed you as close as we could",
            "#The rest is up to you",
            "#Good luck cowboy"
        });
    }

    private IEnumerator Log(string text)
    {
        for (int i = lines.Length - 1; i > 0; i--)
        {
            lines[i].text = lines[i - 1].text;
        }
        yield return TypeWriter(lines[0], text);
    }

    public void Play(string[] messages)
    {
        StopAllCoroutines();
        StartCoroutine(PlaySequence(messages));
    }

    public IEnumerator PlayRoutine(string[] messages) => PlaySequence(messages);

    private IEnumerator PlaySequence(string[] messages)
    {
        if (targetMarker != null)
            targetMarker.SetVisible(false);

        foreach (string msg in messages)
        {
            if (msg == "@targetMarker:on")
            {
                targetMarker.SetVisible(true);
                continue;
            }
            if (msg.Substring(0, 1) == "#")
            {
                playerChat.text = "";
                yield return Log(msg.Substring(1));
            } else
                playerChat.text = msg;
            yield return new WaitForSeconds(holdSeconds);
        }
        yield return new WaitForSeconds(holdSeconds);
        for (int i = 0; i < lines.Length; i++)
        {
            lines[i].text = "";
        }
        playerChat.text = "";

        if (targetMarker != null)
            targetMarker.SetVisible(true);
    }

    IEnumerator TypeWriter(TextMeshProUGUI line, string message)
    {
        for (int i = 0; i <= message.Length; i++)
        {
            line.text = message.Substring(0, i);
            beepSource.PlayOneShot(typeBeep);
            yield return new WaitForSeconds(charDelay);
        }
        //StartCoroutine(FadeOut(line));
    }

    IEnumerator FadeOut(TextMeshProUGUI line)
    {
        yield return new WaitForSeconds(5f - fadeSeconds);
        float t = 0f;
        while (t < 1f)
        {
            t += Time.deltaTime / fadeSeconds;
            var c = line.color;
            c.a = Mathf.Lerp(1f, 0f, t);
            line.color = c;
            yield return null;
        }
    }
}
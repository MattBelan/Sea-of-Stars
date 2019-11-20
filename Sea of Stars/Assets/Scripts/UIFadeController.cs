using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIFadeController : MonoBehaviour
{

    public CanvasGroup someUIThing;

    // Start is called before the first frame update
    void Start()
    {
        Fader(someUIThing, 0, 1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator Fader(CanvasGroup UIS, float startPoint, float endPoint, float fadeTime = 1.0f)
    {
        float timefading = Time.time;
        float timeSinceStart;
        float percentComplete;

        while (true)
        {
            timeSinceStart = Time.time - timefading;
            percentComplete = timeSinceStart / fadeTime;

            float currentValue = Mathf.Lerp(startPoint, endPoint, percentComplete);

            UIS.alpha = currentValue;

            if (percentComplete >= 1) break;

            yield return new WaitForEndOfFrame();
        }

        Debug.Log("Did it shitlord"); //I insult myself with my code, not anyone else reading it, you're great
    }

    public void FadeIn()
    {
        StartCoroutine(Fader(someUIThing, someUIThing.alpha, 1));
    }

    public void FadeOut()
    {
        StartCoroutine(Fader(someUIThing, someUIThing.alpha, 0));
    }
}

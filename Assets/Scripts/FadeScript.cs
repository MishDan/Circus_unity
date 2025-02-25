using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;

public class FadeScript : MonoBehaviour
{
    Image img;
    Color tempColor;
    // Start is called before the first frame update
    void Start()
    {
        img = GetComponent<Image>();
        tempColor = img.color;
        tempColor.a = 1f;
        StartCoroutine(FadeOut(0.15f));
    }

   public IEnumerator FadeOut(float seconds)
    {
        for (float a = 1f; a>=-0.05f; a -= 0.05f)
        {
            tempColor = img.color;
            tempColor.a = a;
            img.color = tempColor;
            yield return new WaitForSeconds(seconds);
        }
        img.raycastTarget = false;
    }

    public IEnumerator FadeIn(float seconds)
    {
        for (float a = 0.05f; a <= 1.05f; a += 0.05f)
        {
            tempColor = img.color;
            tempColor.a = a;
            img.color = tempColor;
            yield return new WaitForSeconds(seconds);
        }
        img.raycastTarget = true;
    }

}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI[] texts;
    public IEnumerator ShowTutorial()
    {
        foreach (TextMeshProUGUI text in texts)
        {
            text.alpha = 0;
            text.enabled = true;
            while (text.alpha < 1.0f)
            {
                Debug.Log(text.alpha);
                text.alpha += 0.02f;
                yield return new WaitForSeconds(0.01f);
            }
            text.alpha = 1;
            yield return new WaitForSeconds(2f);
            while (text.alpha > 0)
            {
                text.alpha -= 0.05f;
                yield return new WaitForSeconds(0.01f);
            }
            text.alpha = 0;
            text.enabled = false;
        }
        

        yield return null;
    }
}

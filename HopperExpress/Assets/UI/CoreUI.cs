using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CoreUI : MonoBehaviour
{
    public TMP_Text CoreHPText;

    void Start()
    {
        CoreHPText = GetComponent<TMP_Text>();
        if (CoreHPText == null)
        {
            Debug.LogError("CoreHPText not found!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (CoreHPText != null)
        {
            CoreHPText.text = string.Format("Core HP: {0}", Core.HP_core);

        }
    }
}

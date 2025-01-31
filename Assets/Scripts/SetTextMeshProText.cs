using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SetTextMeshProText : MonoBehaviour
{
    public Slider slider;
    public TMP_Text text;
    public void SetText()
    {
        text.text = ((float)slider.value).ToString();
    }
}

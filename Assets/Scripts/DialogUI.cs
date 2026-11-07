using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogUI : MonoBehaviour
{
    public static DialogUI Instance;
    public GameObject box;
    public Image portrait;
    public TMP_Text text;

    void Awake()
    {
        Instance = this;
        box.SetActive(false);
    }

    public void Show(Sprite pic, string line)
    {
        portrait.sprite = pic;
        text.text = line;
        box.SetActive(true);
    }

    public void Hide() => box.SetActive(false);
}
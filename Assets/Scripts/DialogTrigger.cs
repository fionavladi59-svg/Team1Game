using UnityEngine;
using UnityEngine.InputSystem;

[System.Serializable]
public class DialogLine
{
    public Sprite portrait;
    [TextArea] public string text;
}

public class DialogTrigger : MonoBehaviour
{
    public DialogLine[] lines;

    bool playerInRange;
    int index = -1;

    void Update()
    {
        if (!playerInRange || !Keyboard.current.eKey.wasPressedThisFrame) return;

        index++;
        if (index >= lines.Length)
        {
            DialogUI.Instance.Hide();
            index = -1;
            return;
        }

        DialogUI.Instance.Show(lines[index].portrait, lines[index].text);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) playerInRange = true;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;
        playerInRange = false;
        if (index >= 0) DialogUI.Instance.Hide();
        index = -1;
    }
}
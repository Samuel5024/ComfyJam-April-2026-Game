using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class VNPlayer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private TextMeshProUGUI dialogueText;
    [SerializeField] private TextAsset Dialogue;
    [SerializeField] private string nextScene;

    private string[] lines;
    private int lineNumber = 0;
    InputAction advance;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        lines = Dialogue.text.Split("\n");

        advance = InputSystem.actions.FindAction("Attack");
        AdvanceDialogue();
    }

    // Update is called once per frame
    void Update()
    {
        if (advance.triggered)
        {
            AdvanceDialogue();
        }
    }

    private void AdvanceDialogue()
    {
        if (lineNumber >= lines.Length)
        {
            SceneManager.LoadScene(nextScene);
            return;
        }
        string[] textLine = lines[lineNumber].Split(":");
        nameText.text = textLine[0];
        dialogueText.text = textLine[1];
        lineNumber++;
    }
}

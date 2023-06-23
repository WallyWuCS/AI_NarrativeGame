using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Ink.Runtime;

public class DialogueManager : MonoBehaviour
{
    [Header("Dialogue UI")]

    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private TextMeshProUGUI dialogueText;
    [SerializeField] private TextAsset inkText;
    [SerializeField] private MaskableGraphic imageToToggle;

    [Header("Choices UI")]

    [SerializeField] private GameObject[] choices;
    private TextMeshProUGUI[] choicesText;

    public float interval = 1f;
	public float startDelay = 0.3f;
	public bool currentState = true;
	public bool defaultState = true;
	bool isBlinking = false;    

    private Story currentStory;

    private bool dialogueIsPlaying;

    private static DialogueManager instance;


    private void Awake() {
        if (instance != null) {
            Debug.LogWarning("Found more than one Dialogue Manager in the scene");
        }
        instance = this;
    }

    public static DialogueManager GetInstance() {
        return instance;
    }

    private void Start() {
        dialogueIsPlaying = false;
        dialoguePanel.SetActive(false);
        EnterDialogueMode(inkText);
        imageToToggle.enabled = defaultState;
		StartBlink();

        choicesText = new TextMeshProUGUI[choices.Length];
        int index = 0;
        foreach (GameObject choice in choices) {
            choicesText[index] = choice.GetComponentInChildren<TextMeshProUGUI>();
            index++;
        }
    }

    public void ToggleState()
	{
		imageToToggle.enabled = !imageToToggle.enabled;
	}

    public void StartBlink()
	{
		// do not invoke the blink twice - needed if you need to start the blink from an external object
		if (isBlinking)
			return;

		if (imageToToggle !=null)
		{
			isBlinking = true;
			InvokeRepeating("ToggleState", startDelay, interval);
		}
	}

    private void Update() {
        if (Input.GetMouseButtonDown(0))
        {
            ContinueStory();
        }
    }

    public void EnterDialogueMode(TextAsset inkJSON) {
        currentStory = new Story(inkJSON.text);
        dialogueIsPlaying = true;
        dialoguePanel.SetActive(true);

        ContinueStory();
        
    }

    private void ExitDialogueMode() {
        dialogueIsPlaying = false;
        // dialoguePanel.SetActive(false);
        dialogueText.text = "";
    }

    public void ContinueStory() {
        if (currentStory.canContinue) {
            Debug.Log("Can continue");
            
            dialogueText.text = currentStory.Continue();

            DisplayChoices();
        }
        else
        {
            Debug.Log("Cant continue");
            CancelInvoke();
            ExitDialogueMode();
        }
    }

    private void DisplayChoices() {
        List<Choice> currentChoices = currentStory.currentChoices;

        if (currentChoices.Count > choices.Length) {
            Debug.LogError("More choices were given than the UI can support");
        }

        int index = 0;
        foreach(Choice choice in currentChoices) {
            choices[index].gameObject.SetActive(true);
            choicesText[index].text = choice.text;
            index++;
        }

        for (int i = index;  i < choices.Length; i++) {
            choices[i].gameObject.SetActive(false);
        }
    }
}

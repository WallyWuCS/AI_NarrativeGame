using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using HuggingFace.API;

public class HuggingFaceAPIManager : MonoBehaviour
{
    [Header("HuggingFaceAPI UI")]

    [SerializeField] private GameObject AIPanel;
    [SerializeField] private TextMeshProUGUI AIText;

    private static HuggingFaceAPIManager instance;
    // private bool AIIsPlaying;


    private void Awake() {
        if (instance != null) {
            Debug.LogWarning("Found more than one AI Dialogue Manager in the scene");
        }
        instance = this;
    }

    public static HuggingFaceAPIManager GetInstance() {
        return instance;
    }

    private void Start() {
        // AIIsPlaying = false;
        AIPanel.SetActive(false);
        EnterAIMode(AIText);
    }

    public void EnterAIMode(TextMeshProUGUI textIn) {
        // AIIsPlaying = true;
        AIPanel.SetActive(true);

        Query();
        textIn.text = "trial for text generation";
    }

    public void Query() {
        string inputText = "I'm on my way to the forest.";
        // string[] candidates = {
        //     "The player is going to the city",
        //     "The player is going to the wilderness",
        //     "The player is wandering aimlessly"
        // };
        HuggingFaceAPI.TextGeneration(inputText, OnSuccess, OnError);

    }

    private void OnSuccess(string result) {
        // foreach(float value in result) {
        //     Debug.Log(value);
        // }
        Debug.Log(result);
    }

    private void OnError(string error) {
        Debug.LogError(error);
    }
}

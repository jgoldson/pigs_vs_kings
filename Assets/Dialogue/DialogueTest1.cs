using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.UI;


public class DialogueControl : MonoBehaviour
{

    [SerializeField] Dialogue dialogue;
    [SerializeField] Text SpeakerText, DialogueText;

    Player player;
    bool skipDialogue = false;
    public float typeDelay = 0.1f;
    private string currentText = "";
    private string fullText;


    void Start()
    {
        player = FindObjectOfType<Player>();
        player.StopPlayerMovement();
        StartCoroutine(NextDialogue());
    }

    void Update()
    {
        if (CrossPlatformInputManager.GetButtonDown("Fire1")){
            skipDialogue = true;
        }

    }
    IEnumerator NextDialogue() {

        foreach (DialogueNode node in dialogue.GetNodes()){
            skipDialogue = false;
            SpeakerText.text = node.GetSpeaker();
            fullText = node.GetText();
            StartCoroutine(ShowText());
            while (skipDialogue == false) {
                yield return null;
            }
        }
        player.AllowPlayerMovement();
        gameObject.SetActive(false);
        Destroy(gameObject, 1);
    }

    IEnumerator ShowText() {
        for(int i = 0; i < fullText.Length + 1; i++) {
            currentText = fullText.Substring(0,i);
            DialogueText.text = currentText;
            yield return new WaitForSeconds(typeDelay);
        }

    }
}

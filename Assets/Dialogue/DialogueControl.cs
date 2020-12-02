using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.UI;


public class DialogueTest1 : MonoBehaviour
{

    [SerializeField] Dialogue dialogue;
    [SerializeField] Text SpeakerText, DialogueText;

    Player player;
    bool skipDialogue = false;


    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();
        player.StopPlayerMovement();
        StartCoroutine(NextDialogue());

        
    }

    // Update is called once per frame
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
            DialogueText.text = node.GetText();
            while (skipDialogue == false) {
                
                yield return null;
            }
        }
        player.AllowPlayerMovement();
        gameObject.SetActive(false);
        Destroy(gameObject, 1);

        
    }
}

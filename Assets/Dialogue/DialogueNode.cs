using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//namespace PIG.Dialogue

    [System.Serializable]
    public class DialogueNode 
    {
        //public string uniqueID;
        public string speaker;
        public string text;
        //public string[] children;



        public string GetSpeaker() {
            return speaker;
        }
        public string GetText() {
            return text;
        }
    }

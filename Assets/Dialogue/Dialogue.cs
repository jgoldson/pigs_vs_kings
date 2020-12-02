using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//namespace PIG.Dialogue

    [CreateAssetMenu(fileName = "New Dialogue", menuName = "Dialogue", order = 0)]
    public class Dialogue : ScriptableObject{

        [SerializeField] DialogueNode[] nodes;

        public DialogueNode[] GetNodes() {
            return nodes;
        }

    }

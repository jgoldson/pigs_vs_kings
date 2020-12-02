﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEditor;
using UnityEditor.Callbacks;

//namespace PIG.Dialogue.Editor

    public class DialogueEditor : EditorWindow
    {
        [MenuItem("Window/Dialogue Editor")]
        public static void ShowEditorWindow()
        {
            GetWindow(typeof(DialogueEditor), false, "Dialogue Editor");
        }

        [OnOpenAssetAttribute(1)]
        public static bool OnOpenAsset(int instanceID, int line) {
            Dialogue dialogue = EditorUtility.InstanceIDToObject(instanceID) as Dialogue;
            if (dialogue != null) {
                ShowEditorWindow();
                return true;
            }
            return false;
        }

        private void OnGUI() {
            EditorGUILayout.LabelField("Hello World");
            EditorGUILayout.LabelField("Apple");
            EditorGUILayout.LabelField("Orange");
            
        }
    }


using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Leg))]
public class LegEditor : Editor
{

    Leg leg;

    void Awake() {
        leg = (target as Leg);
    }

    public override void OnInspectorGUI()
    {

        EditorGUILayout.BeginHorizontal ();
        EditorGUILayout.LabelField ("Frames: ", leg.frames_count.ToString());
        EditorGUILayout.EndHorizontal ();

        EditorGUILayout.BeginHorizontal ();
        EditorGUILayout.LabelField ("Current frame: ", leg.frame.ToString());
        EditorGUILayout.EndHorizontal ();

        EditorGUILayout.BeginHorizontal ();
        EditorGUILayout.PrefixLabel ("Delay");
        leg.delay = EditorGUILayout.Slider(leg.delay, 0, 1);
        EditorGUILayout.EndHorizontal ();

        EditorGUILayout.BeginHorizontal ();
        EditorGUILayout.PrefixLabel ("Parts");
        leg.head = (Transform) EditorGUILayout.ObjectField(leg.head, typeof(Transform), true);
        EditorGUILayout.EndHorizontal ();

        GUI.backgroundColor = new Color(0,0.9f,1f,1);

        EditorGUILayout.BeginHorizontal();
        if(GUILayout.Button("Add Frame")){
            leg.AddFrame();
        }
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.BeginHorizontal();
        if(GUILayout.Button("Save")){
            leg.Save();
        }
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.BeginHorizontal();
        if(GUILayout.Button("Load")){
            leg.Load();
        }
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.BeginHorizontal();
        if(GUILayout.Button("Play/Pause")){
            leg.Play();
        }
        EditorGUILayout.EndHorizontal();
        
    }

}

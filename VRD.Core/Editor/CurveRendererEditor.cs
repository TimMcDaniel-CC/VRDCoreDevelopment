using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEditor;
using UnityEngine;


[CustomEditor(typeof(CurveRenderer))]
public class CurveRendererEditor : Editor
{
    CurveRenderer rend;
    SerializedObject so;
    SerializedProperty pointSamples;
    SerializedProperty maxDistance;
    SerializedProperty maxHeight;
    SerializedProperty curve;
    SerializedProperty curveWidth;
    SerializedProperty material;
    SerializedProperty colorGradient;

    SerializedObject lineRenderer;

    private void OnEnable()
    {
        rend = (target as CurveRenderer);
        so = serializedObject;
        pointSamples = so.FindProperty("pointSamples");
        maxDistance = so.FindProperty("maxDistance");
        maxHeight = so.FindProperty("maxHeight");
        curve = serializedObject.FindProperty("curve");
        curveWidth = serializedObject.FindProperty("curveWidth");
        
        //colorGradient = serializedObject.FindProperty("colorGradient");

        lineRenderer = new SerializedObject(serializedObject.FindProperty("lineRenderer").serializedObject.targetObject);
        colorGradient = lineRenderer.FindProperty("colorGradient");
        material = lineRenderer.FindProperty("material");

    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        EditorGUILayout.PropertyField(pointSamples);
        EditorGUILayout.PropertyField(maxDistance);
        EditorGUILayout.PropertyField(maxHeight);
        EditorGUILayout.PropertyField(curve);
        EditorGUILayout.PropertyField(curveWidth);
        EditorGUILayout.PropertyField(material);
        EditorGUILayout.PropertyField(colorGradient, new GUIContent("Color (Line Renderer)"));
        //EditorGUILayout.PropertyField(lineColorGradient);


        lineRenderer.ApplyModifiedProperties();
        serializedObject.ApplyModifiedProperties();
        
    }
    private void OnDestroy()
    {
        if (Application.isPlaying)
        {


            if (target == null && this.rend != null)
            {
                Destroy(rend.gameObject.GetComponent<LineRenderer>());
            }
        }
    }
}

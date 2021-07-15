using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptableObjectInstancesContainer : MonoBehaviour
{
    [SerializeField] private MaterialsScriptableObject materials;
    [SerializeField] private PrefabsScriptableObject prefabs;
    private static ScriptableObjectInstancesContainer _instance;
    
    public MaterialsScriptableObject Materials => materials;
    public PrefabsScriptableObject Prefabs => prefabs;
    public static ScriptableObjectInstancesContainer Instance => _instance;
    
    private void Awake()
    {
        _instance = this;
    }
}

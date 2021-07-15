using UnityEngine;

[CreateAssetMenu(fileName = "_Materials", menuName = "ScriptableObjects/MaterialsScriptableObject", order = 1)]
public class MaterialsScriptableObject : ScriptableObject
{
    [SerializeField] private Material grass;
    public Material Grass => grass;
    
    [SerializeField] private Material sand;
    public Material Sand => sand;
    
    [SerializeField] private Material snow;
    public Material Snow => snow;
    
    [SerializeField] private Material swamp;
    public Material Swamp => swamp;
}

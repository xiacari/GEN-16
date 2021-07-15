using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainTileMonoBehaviour : MonoBehaviour
{
    private static MaterialsScriptableObject materials;
    private Renderer _renderer;
    private Material _material;

    private void OnEnable()
    {
        materials = ScriptableObjectInstancesContainer.Instance.Materials;
        _renderer = GetComponentInChildren<Renderer>();
    }

    public void Construct((int, int) position, int type, float height)
    {
        SetPosition(position);
        SetMaterial(type);
        SetHeight(height);
    }

    private void SetMaterial(int type)
    {
        _material = type switch
        {
            0 => materials.Grass,
            1 => materials.Sand,
            2 => materials.Snow,
            3 => materials.Swamp,
            _ => _material
        };
        _renderer.material = _material;
    }

    private void SetPosition((int x, int y) pos)
    {
        var t = transform;
        t.position = new Vector3(pos.x, t.position.y, pos.y);
    }

    private void SetHeight(float f)
    {
        var t = transform;
        var s = t.localScale;
        var p = t.position;
        t.localScale = new Vector3(s.x, f, s.z);
        t.position = new Vector3(p.x, f / 2, p.z);
    }
}

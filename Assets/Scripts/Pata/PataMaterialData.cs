
using UnityEngine;

[CreateAssetMenu(fileName ="MaterialData",menuName ="MyScriptable/MaterialData")]
public class PataMaterialData : ScriptableObject
{

    [SerializeField]
    private Material pataColorMaterial;

    public Material PataColorMaterial() { return pataColorMaterial; }

}

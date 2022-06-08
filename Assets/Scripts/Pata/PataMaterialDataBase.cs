using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MaterialDataBase", menuName = "MyScriptable/MaterialDataBase")]
public class PataMaterialDataBase : ScriptableObject
{
    [SerializeField]
    private List<PataMaterialData> pataMaterialList = new List<PataMaterialData>(); 
    public List<PataMaterialData> PataMaterialList() { return pataMaterialList; }
}

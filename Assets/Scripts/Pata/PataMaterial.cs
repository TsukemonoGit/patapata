using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PataMaterial : MonoBehaviour
{
    [SerializeField]
    private Material[] colorMaterials;
    private new MeshRenderer renderer;
    private Animator anim;
    [SerializeField]
    private int index=0;
    private PataPataController controller;
    private Vector2Int myPosition; 
    private void Start()
    {
        renderer = GetComponentInChildren<MeshRenderer>();
        anim = GetComponent<Animator>();
        controller = GameObject.FindGameObjectWithTag("GameController").GetComponent<PataPataController>();
    }
    
    //初期化
    public void Init( int index , Vector2Int myPosition)
    {
        if (renderer == null){
            renderer = GetComponentInChildren<MeshRenderer>();
        }
        this.index = index;
        this.myPosition = myPosition;
        renderer.material = colorMaterials[this.index];
        
        //PataAnimation();
    }
    public Vector2Int GetPosition()
    {
        return myPosition;
    }

    public void PataAnimation()
    {
       anim.Play(name = "Pata");
    }
  public void ChangeMaterial()
    {
        index++;
        if (index >= controller.max_color)
        {
            index = 0;
        }
        renderer.material = colorMaterials[this.index];
        PataAnimation();
    }
    public void ChangeMaterial(int index,bool isAnim=true)
    {
        this.index = index;
        renderer.material = colorMaterials[this.index];
        if (isAnim == true) { PataAnimation(); }
    } 
}

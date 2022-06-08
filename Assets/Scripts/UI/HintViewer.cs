using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HintViewer : MonoBehaviour
{
    private Material material;
    bool nowFade = false;

    float muki = 1f;
    float interval = 0.02f;
    float nowAlpha;
    float length;

    Vector2Int prePosition;
    Vector2Int position;
    private void Start()
    {
        length = 1 / interval * 2;
        material = GetComponent<MeshRenderer>().material;
        material.SetFloat("_Alpha", 0);
        if (material == null)
        {
            Debug.Log("まてりあるないよ");
        }
    }
    public void HintView(Vector2Int position)
    {
        this.position = position;
        material.SetVector("_Position", new Vector4(position.x, position.y, 0, 0));
        nowFade = true;
   }
    private void Update()
    {
        if (nowFade) {
            if (position != prePosition)
            {
                nowAlpha = 0;
            }
            nowAlpha = nowAlpha + interval * muki;

            if (nowAlpha > 1)
            {
                muki = -1;
                nowAlpha = 1;
            }
            if (nowAlpha < 0)
            {
             
                nowFade = false;
                muki = 1;
                nowAlpha = 0;
            }
            material.SetFloat("_Alpha", nowAlpha);


        }
     
        
        prePosition = position;
    }
}

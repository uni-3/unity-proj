using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class BlockProvider : MonoBehaviour
{
    [SerializeField]
    private GameObject BlockPrefab;

    /// <summary>
    /// ブロックの生成処理
    /// </summary>
    /// <returns></returns>
    public Block Create(Transform parent, Vector2 position, Color color)
    {
        var go = Instantiate(this.BlockPrefab, parent) as GameObject;
        var block = go.GetComponent<Block>();
        go.GetComponent<RectTransform>().anchoredPosition = position;
        //go.GetComponent<Renderer>().material.EnableKeyword("_Emission");
        //go.GetComponent<Renderer>().material.SetColor("_EmissionColor", color);
        go.GetComponent<Renderer>().material.color = color;

        return block;
    }
}
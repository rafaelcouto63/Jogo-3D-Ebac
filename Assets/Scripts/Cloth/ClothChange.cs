using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ClothChange : MonoBehaviour
{
    public SkinnedMeshRenderer mesh;
    public Texture2D texture;
    public string shaderName = "_EmissionMap";

   [NaughtyAttributes.Button]
   private void ChangeTexture()
   {
     mesh.materials[0].SetTexture(shaderName, texture);
   }
}

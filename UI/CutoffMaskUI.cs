using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class CutoffMaskUI : Image
{
    public override Material materialForRendering
    {
        get
        {
            Material material = new Material(base.materialForRendering);
            material.SetFloat("_StencilComp", (float)CompareFunction.NotEqual);
            material.SetFloat("_Stencil", 1f);
            material.SetFloat("_StencilWriteMask", 0f);
            material.SetFloat("_StencilReadMask", 1f);
            return material;
        }
    }
}

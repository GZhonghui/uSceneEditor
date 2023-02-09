using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Draw : MonoBehaviour
{
    [UnityEditor.MenuItem("uSceneEditor/Render")]
    public static void Render()
    {
        var renderTarget = GameObject.FindGameObjectWithTag("RenderTarget");
        if (renderTarget == null) return;

        RawImage imageData = renderTarget.GetComponent<RawImage>();

        if (imageData != null)
        {
            int Width = (int)imageData.rectTransform.sizeDelta.x;
            int Height = (int)imageData.rectTransform.sizeDelta.y;

            var targetValue = new Texture2D(Width, Height);
            for (int i = 0; i < Width; i += 1)
            {
                for (int j = 0; j < Height; j += 1)
                {
                    // targetValue.SetPixel(i, j, new Color(1.0f * i / Width, 1.0f * j / Height, 0));

                    float Value = (i / 100 + j / 100) % 2 == 0 ? 1 : 0;
                    targetValue.SetPixel(i, j, new Color(Value, Value, Value));
                }
            }
            targetValue.Apply();

            imageData.texture = targetValue;
        }
    }
}

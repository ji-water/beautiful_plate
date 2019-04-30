using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManage : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SetCameraAsect();

    }

    public void SetCameraAsect()
    {
        Camera mainCam = UnityEngine.Camera.main;
        float targetaspect = 1920.0f / 1080.0f;
        float windowaspect = 0;

#if UNITY_EDITOR
        windowaspect = (float)mainCam.pixelWidth / (float)mainCam.pixelHeight;
#else
            windowaspect = (float)Screen.width / (float)Screen.height;
#endif
        float scaleheight = windowaspect / targetaspect;
        Camera camera = UnityEngine.Camera.main;

        if (scaleheight < 1.0f)
        {
            Rect rect = camera.rect;

            rect.width = 1.0f;
            rect.height = scaleheight;
            rect.x = 0;
            rect.y = (1.0f - scaleheight) / 2.0f;

            camera.rect = rect;
        }
        else
        { // add pillarbox 
            float scalewidth = 1.0f / scaleheight;

            Rect rect = camera.rect;

            rect.width = scalewidth;
            rect.height = 1.0f;
            rect.x = (1.0f - scalewidth) / 2.0f;
            rect.y = 0;

            camera.rect = rect;
        }

    }
}

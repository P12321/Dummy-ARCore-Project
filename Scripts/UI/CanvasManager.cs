using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    [SerializeField]
    private GameObject captureCanvas, imageCanvas;

    [SerializeField]
    private CaptureScreen captureScreen;

    [SerializeField]
    private ImageScreen imageScreen;

    private void Start()
    {
        captureScreen.SwitchToImageCanvas += CaptureToImage;
        imageScreen.SwitchToCaptureCanvas += ImageToCapture;
    }

    private void CaptureToImage(Texture2D texture)
    {
        captureCanvas.SetActive(false);
        imageCanvas.SetActive(true);
        imageScreen.SetImage(texture);
    }

    private void ImageToCapture()
    {
        imageCanvas.SetActive(false);
        captureCanvas.SetActive(true);
    }
}

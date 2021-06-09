using System;
using UnityEngine;
using UnityEngine.UI;

public class ImageScreen : MonoBehaviour
{
    [SerializeField]
    private Image image;

    private AudioManager audioManager;

    public event Action SwitchToCaptureCanvas;

    private void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
    }

    public void SetImage(Texture2D texture)
    {
        image.sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.zero);
    }

    public void OnBackButton()
    {
        audioManager.DeleteAdded();
        SwitchToCaptureCanvas();
    }

    public void OnAudio1Button()
    {
        audioManager.Play("Audio 1");
    }

    public void OnAudio2Button()
    {
        audioManager.Play("Audio 2");
    }

    private void Update()
    {
        if (Application.platform == RuntimePlatform.Android && Input.GetKeyDown(KeyCode.Escape)) OnBackButton();
    }
}

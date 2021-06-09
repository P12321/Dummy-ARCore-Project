using UnityEngine;
using UnityEngine.Android;

public class MicrophoneScript : MonoBehaviour
{
    [SerializeField]
    private int recordingLength;

    private string mic;
    private int minFreq, maxFreq;
    private bool isRecording;

    private AudioClip recording;
    private AudioManager audioManager;

    private void Start()
    {
        isRecording = false;
        audioManager = FindObjectOfType<AudioManager>();
        if (!Permission.HasUserAuthorizedPermission(Permission.Microphone))
            Permission.RequestUserPermission(Permission.Microphone);
        mic = Microphone.devices[0];
        Microphone.GetDeviceCaps(mic, out minFreq, out maxFreq);
    }

    public void OnRecord()
    {
        if (!Permission.HasUserAuthorizedPermission(Permission.Microphone))
        {
            Permission.RequestUserPermission(Permission.Microphone);
            return;
        }

        recording = Microphone.Start(mic, false, recordingLength, (minFreq + maxFreq) / 2);
        if (recording == null) Log.Print("Recording failed to start.");
        else isRecording = true;
    }

    public void OnStopRecord()
    {
        if (Microphone.IsRecording(mic))
        {
            Microphone.End(mic);
            isRecording = false;
        }
    }

    public void OnRecordedPlay()
    {
        audioManager.Play("Recorded Audio");
    }

    private void Update()
    {
        if (isRecording && !Microphone.IsRecording(mic))
        {
            isRecording = false;
            audioManager.Add("Recorded Audio", recording, 1, 1);
        }
    }
}

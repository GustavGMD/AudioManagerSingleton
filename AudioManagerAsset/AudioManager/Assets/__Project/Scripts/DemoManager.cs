using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DemoManager : MonoBehaviour {

    public Button soundEffect1Button;
    public Button soundEffect2Button;
    public Button soundEffect3Button;
    public Button music1Button;
    public Button music2Button;
    public Button muteAllButton;
    public Button muteMusic1Button;
    public Slider soundEffec2Slider;
    public Slider music1Slider;

    private int _soundEffect1id;
    private int _soundEffect2id;
    private int _soundEffect3id;
    private int _music1id = -1;
    private int _music2id = -1;

    private float _soundEffect2VolumeParameter = 1;
    private bool allMuted = false;
    private bool music1Muted = false;

    // Use this for initialization
    void Awake () {
        //before using the AudioManagerSingleton, we must call its Initialize() method
        AudioManagerSingleton.instance.Initialize();

        //example on how to use sound effects
        soundEffect1Button.onClick.AddListener(SoundEffectPlayingExample);
        soundEffect2Button.onClick.AddListener(delegate 
        {
            _soundEffect2id = AudioManagerSingleton.instance.PlaySound(AudioManagerSingleton.AudioClipName.ANOTHER_TEST_SOUND, AudioManagerSingleton.AudioType.SFX, false, _soundEffect2VolumeParameter);
        });
        soundEffect3Button.onClick.AddListener(delegate
        {
            _soundEffect3id = AudioManagerSingleton.instance.PlaySound(AudioManagerSingleton.AudioClipName.ULTIMATE_TEST_SOUND, AudioManagerSingleton.AudioType.SFX);
        });

        //example on how to play and stop playing musics
        music1Button.onClick.AddListener(MusicPlayingAndStoppingExample);
        music2Button.onClick.AddListener(delegate
        {
            if (_music2id == -1)
            {
                _music2id = AudioManagerSingleton.instance.PlaySound(AudioManagerSingleton.AudioClipName.COOL_MUSIC, AudioManagerSingleton.AudioType.MUSIC, true);
            }
            else
            {
                AudioManagerSingleton.instance.StopSound(_music2id);
                _music2id = -1;
            }
        });

        //example on how to change a sound instance's volume, particularly useful for looping sounds
        music1Slider.onValueChanged.AddListener(VolumeChangingExample);

        //here we define the volume for a sound effect
        //the volume parameter passed during PlaySaound() call defines the sound's initial volume(which can be changed during play with the ChangeVolume() method)
        soundEffec2Slider.onValueChanged.AddListener(delegate (float p_value)
        {
            _soundEffect2VolumeParameter = p_value;
        });

        //example of muting/unmuting active sounds
        muteAllButton.onClick.AddListener(delegate
        {
            if (!allMuted)
            {
                AudioManagerSingleton.instance.MuteAll();
                allMuted = true;
            }
            else
            {
                AudioManagerSingleton.instance.UnmuteAll();
                allMuted = false;
            }
        });
        muteMusic1Button.onClick.AddListener(delegate
        {
            if (!music1Muted)
            {
                AudioManagerSingleton.instance.MuteSound(_music1id);
                music1Muted = true;
            }
            else
            {
                AudioManagerSingleton.instance.UnmuteSound(_music1id);
                music1Muted = false;
            }
        });
    }

	
	// Update is called once per frame
	void Update () {
	
	}

    /// <summary>
    /// AudioManagerSingleton usage example: PlaySound() method
    /// </summary>
    public void SoundEffectPlayingExample()
    {
        _soundEffect1id = AudioManagerSingleton.instance.PlaySound(AudioManagerSingleton.AudioClipName.TEST_SOUND, AudioManagerSingleton.AudioType.SFX);
    }

    public void MusicPlayingAndStoppingExample()
    {
        //We usually want background music to loop...
        if (_music1id == -1)
        {
            _music1id = AudioManagerSingleton.instance.PlaySound(AudioManagerSingleton.AudioClipName.TEST_MUSIC, AudioManagerSingleton.AudioType.MUSIC, true);
        }
        else
        {
            AudioManagerSingleton.instance.StopSound(_music1id);
            _music1id = -1;
        }
    }

    public void VolumeChangingExample(float p_value)
    {
        AudioManagerSingleton.instance.ChangeVolume(_music1id, p_value);
    }
}

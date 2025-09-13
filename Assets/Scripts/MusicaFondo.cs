using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicaFondo : MonoBehaviour
{
    public AudioClip musicaNivel1;
    public AudioClip musicaNivel2;

    private AudioSource audioSource;

    public static MusicaFondo instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        audioSource = GetComponent<AudioSource>();

        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        switch (scene.name)
        {
            case "Pizarra":
                CambiarMusica(musicaNivel1);
                break;

            case "Pizarra 2":
                CambiarMusica(musicaNivel2);
                break;
        }
    }

    void CambiarMusica(AudioClip clip)
    {
        if (audioSource.clip == clip) return; 
        audioSource.clip = clip;
        audioSource.loop = true;
        audioSource.Play();
    }

    public void CambiarVolumen(float valor)
    {
        audioSource.volume = valor;
        PlayerPrefs.SetFloat("Volumen", valor);
    }

    void Start()
    {
        if (PlayerPrefs.HasKey("Volumen"))
        {
            float v = PlayerPrefs.GetFloat("Volumen");
            audioSource.volume = v;

            // actualizar el slider si existe
            var slider = FindObjectOfType<UnityEngine.UI.Slider>();
            if (slider != null) slider.value = v;
        }
    }

}


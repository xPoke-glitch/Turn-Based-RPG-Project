using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class MusicManager : Singleton<MusicManager>
{
    [SerializeField] private AudioClip battleMainTheme;

    private AudioSource _audioSource;
    private static GameObject gameObjectInstance = null;

    public void OnEnable()
    {
        EnemyTile.OnInteract += EnemyInteraction;
    }

    public void OnDisable()
    {
        EnemyTile.OnInteract -= EnemyInteraction;
    }

    protected override void Awake()
    {
        base.Awake();
        _audioSource = GetComponent<AudioSource>();
        _audioSource.playOnAwake = false;
        
        DontDestroyOnLoad(this.gameObject);
        if (gameObjectInstance == null)
        {
            gameObjectInstance = gameObject;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        
    }

    private void EnemyInteraction(string enemyName)
    {
        _audioSource.clip = battleMainTheme;
        _audioSource.Play();
    }
}

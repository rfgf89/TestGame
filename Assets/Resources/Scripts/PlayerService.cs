using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Unity.Mathematics;
using UnityEngine;

public class PlayerService : MonoBehaviour, IPlayerService
{
    [SerializeField] private PlayerData _playerData;
    [SerializeField] private float timeToDiff;
    [SerializeField] private float diffScale;
    [SerializeField] private float diffPower;
    [SerializeField] private List<Pair<GameMode, float>> diffs = new List<Pair<GameMode, float>>();
     private Dictionary<GameMode, float> diffsDic = new Dictionary<GameMode, float>();
    private bool IsPlay = false;
    private const string nameSaveFile = "PlayerSave.txt";

    public void Start()
    {
        DontDestroyOnLoad(gameObject);
        if (File.Exists(Application.persistentDataPath + "/" + nameSaveFile))
            PlayerLoad();
        else
            _playerData = new PlayerData();
        
        foreach (var diff in diffs)
            diffsDic.Add(diff.first, diff.last);
    }

    public PlayerData playerData { get => _playerData; set => _playerData = value; }
    
    public void PlayerSave()
    {
        BinaryFormatter bf = new BinaryFormatter ();
        FileStream file = File.Create (Application.persistentDataPath + "/" + nameSaveFile);

        bf.Serialize (file, _playerData);
        file.Close ();
    }

    public void StartPlay()
    {
        _playerData.currentTime = 0f;
        IsPlay = true;
        diffPower = 0f;
        Debug.Log("play");
    }
    public void EndPlay()
    {
        IsPlay = false;
        _playerData.life--;
    }
    private void Update()
    {
        if (IsPlay)
            _playerData.currentTime += Time.deltaTime;

        playerData.speedModify = diffsDic[_playerData.gameMode] + math.floor(diffPower / timeToDiff) * diffScale;
        diffPower += Time.deltaTime;
        Debug.Log(_playerData.currentTime);
    }

    public unsafe void PlayerLoad()
    {

        BinaryFormatter bf = new BinaryFormatter ();
        FileStream file = File.Open (Application.persistentDataPath + "/" + nameSaveFile, FileMode.Open);
        PlayerData data = (PlayerData)bf.Deserialize(file);
        file.Close ();

        _playerData.timeInLastLife = data.timeInLastLife;
        _playerData.life = data.life;
    }

    
}
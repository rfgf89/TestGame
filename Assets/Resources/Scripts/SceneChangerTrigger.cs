using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class SceneChangerTrigger : MonoBehaviour
{
    [SerializeField] private GameScene _scene;
    private SceneChanger _sceneChanger;
    private Dictionary<GameScene, string> scenes = new Dictionary<GameScene, string>();
    
    [Inject]
    private void Construct(SceneChanger sceneChanger)
    {
        _sceneChanger = sceneChanger;
    }

    private void Start()
    {
        scenes.Add(GameScene.MainMenu, "MainMenu");
        scenes.Add(GameScene.Level, "Level");
    }

    public void ChangeScene()
    {
        if(scenes.TryGetValue(_scene, out var name))
            _sceneChanger.ChangeScene(name);
    }
}

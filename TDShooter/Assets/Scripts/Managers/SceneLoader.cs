using System.Collections.Generic;
using UnityEngine.SceneManagement;
using System.IO;

namespace TopDownShooter
{

    //todo удалить класс?
    public class SceneLoader
    {
        private List<string> _sceneNames = new();

        public List<string> SceneNames { get { return _sceneNames; } }

        private void LoadSceneNames()
        {
            int sceneCount = SceneManager.sceneCountInBuildSettings;
            for (int i = 0; i < sceneCount; i++)
            {
                string scenePath = SceneUtility.GetScenePathByBuildIndex(i);
                string sceneName = Path.GetFileNameWithoutExtension(scenePath);
                _sceneNames.Add(sceneName);
            }
        }
    }
}
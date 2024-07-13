using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace TopDownShooter
{
    public class SceneLoader
    {
        public IEnumerator LoadSceneAsync(int sceneId) 
        {
            AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(sceneId);
            asyncOperation.allowSceneActivation = false;
            while (!asyncOperation.isDone) 
            {
                yield return null;
            }
            asyncOperation.allowSceneActivation = true;
        }
    }
}
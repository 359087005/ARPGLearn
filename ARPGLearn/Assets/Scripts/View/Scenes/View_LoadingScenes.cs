using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Control;
using Global;

namespace View
{
    /// <summary>
    /// 场景加载界面
    /// </summary>
    public class View_LoadingScenes : MonoBehaviour
    {
        public Slider _SliLoadingProgress;

        private float _FloProgressValue;
        private AsyncOperation _AsyOper;

        void Start()
        {
            StartCoroutine(LoadingScenesProgress());
        }

        IEnumerator LoadingScenesProgress()
        {
            _AsyOper = SceneManager.LoadSceneAsync(GlobalParamgr.NextScenesName);
            _AsyOper.allowSceneActivation = false;
            yield return _AsyOper;
        }

        void Update()
        {
            _SliLoadingProgress.value = _AsyOper.progress;
            if (_AsyOper.progress >= 0.9f)
            {
                _SliLoadingProgress.value = 1f;
                _AsyOper.allowSceneActivation = true;
            }
        }
    }
}



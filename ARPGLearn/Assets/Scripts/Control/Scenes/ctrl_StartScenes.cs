using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using Global;
using kernal;

/// <summary>
///  控制层
/// </summary>
namespace Control
{
    public class ctrl_StartScenes : BaseControl
    {
        public static ctrl_StartScenes _Instance = null;
        void Awake()
        {
            _Instance = this;
        }

        void Start()
        {
            AudioManager.SetAudioBackgroundVolumns(0.5f);
            AudioManager.SetAudioEffectVolumns(1f);

            AudioManager.PlayBackground(CommonData.AUDIO_STARTSCENES);
        }

        /// <summary>
        /// 点击新游戏
        /// </summary>
        internal void Click_NewGame()
        {
            Debug.Log(GetType() + "/Click_NewGame");
            //场景变暗  
            EnterNextScenes();
        }

        internal void Click_GameContinue()
        {
            Debug.Log(GetType() + "/Click_GameContinue");
        }



        void EnterNextScenes()
        {
            StartCoroutine(IEEnterNextScenes());
        }

        IEnumerator IEEnterNextScenes()
        {
            FadeInAndOut._Instance.SetScreenToAppear();
            yield return new WaitForSeconds(1.2f);
            //加载下一场景
            base.EnterNextScenes(CommonData.SCENES_LOGINSCENES);
        }
    }
}

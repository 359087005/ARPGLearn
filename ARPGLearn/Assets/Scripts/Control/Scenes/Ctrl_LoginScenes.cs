using UnityEngine;
using System.Collections;
using Global;
using kernal;
using UnityEngine.SceneManagement;

namespace Control
{
    /// <summary>
    /// 登录场景   控制脚本
    /// </summary>
    public class Ctrl_LoginScenes : MonoBehaviour
    {
        public static Ctrl_LoginScenes _Instance;

        void Awake()
        {
            _Instance = this;
        }

        public void EnterNextScenes()
        {
            StartCoroutine(IEEnterNextScenes());
        }

         IEnumerator IEEnterNextScenes()
        {
            FadeInAndOut._Instance.SetScreenToAppear();
            yield return new WaitForSeconds(1.2f);
            //加载下一场景
            GlobalParamgr.NextScenesName = CommonData.SCENES_LEVELONE;
            SceneManager.LoadScene(CommonData.SCENES_LOADINGSCENES);
        }
    }
}
    

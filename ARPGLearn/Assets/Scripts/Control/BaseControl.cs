using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using Global;

namespace Control
{
    /// <summary>
    /// 父类控制层
    /// </summary>
    /// 抽象控制层脚本公共的部分
    public class BaseControl : MonoBehaviour
    {
        protected  void EnterNextScenes(string nextScenesName)
        {
            GlobalParamgr.NextScenesName = nextScenesName;
            SceneManager.LoadScene(CommonData.SCENES_LOADINGSCENES);
        }
    }
}

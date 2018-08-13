using UnityEngine;
using System.Collections;
using Control;
/// <summary>
/// 视图层         只负责界面的显示  不负责界面的控制
/// </summary>
/// getType 打印全路径

namespace View
{
    public class View_StartScenes : MonoBehaviour
    {
        public void Click_NewGame()
        {
            Debug.Log(GetType() + "/ClickNewGame");
            ctrl_StartScenes._Instance.Click_NewGame();
        }

        public void Click_GameContinue()
        {
            Debug.Log(GetType() + "/ClickGameContinue");
            ctrl_StartScenes._Instance.Click_GameContinue();
        }
    }
}

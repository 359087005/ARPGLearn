using UnityEngine;
using System.Collections;
using Global;
using Control;
using kernal;
using UnityEngine.UI;

namespace View
{
    public class View_LoginScenes : MonoBehaviour
    {
        public GameObject _SwordHero;
        public GameObject _MagicHero;

        public GameObject _UISwordInfo;
        public GameObject _UIMagicInfo;

        public InputField _UserName;

        private void Start()
        {
            GlobalParamgr.playerType = PlayerType.SwordHero;
        }
        public void ChangeToSword()
        {
            Ctrl_LoginScenes._Instance.PlayAudioEffectBySword();
            _SwordHero.SetActive(true);
            _MagicHero.SetActive(false);

            _UISwordInfo.SetActive(true);
            _UIMagicInfo.SetActive(false);

            GlobalParamgr.playerType = PlayerType.SwordHero;
        }

        public void ChangeToMagic()
        {
            Ctrl_LoginScenes._Instance.PlayAudioEffectBySword();
            _SwordHero.SetActive(false);
            _MagicHero.SetActive(true);

            _UISwordInfo.SetActive(false);
            _UIMagicInfo.SetActive(true);

            GlobalParamgr.playerType = PlayerType.MaigcHero;
        }

        /// <summary>
        /// 提交信息
        /// </summary>
        public void SubmitInfo()
        {
            //获取用户名 //跨场景处理传值
            GlobalParamgr.PlayerNmae = _UserName.text;
            //跳转场景
            //控制层方法
            Ctrl_LoginScenes._Instance.EnterNextScenes();
        }
    }

}

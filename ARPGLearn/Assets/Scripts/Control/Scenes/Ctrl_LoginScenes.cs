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
    public class Ctrl_LoginScenes : BaseControl
    {
        public static Ctrl_LoginScenes _Instance;

        public AudioClip _ACBackGroundMusic;
        void Awake()
        {
            _Instance = this;
        }
        void Start()
        {
            AudioManager.SetAudioBackgroundVolumns(0.5f);
            AudioManager.SetAudioEffectVolumns(1f);

            AudioManager.PlayBackground(_ACBackGroundMusic);
        }

        public void PlayAudioEffectBySword()
        {
            AudioManager.PlayAudioEffectA("1_LightRoar_SwordHero");
        }
        public void PlayAudioEffectByMaig()
        {
            AudioManager.PlayAudioEffectB("2_FireBallEffect_MagicHero");
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
            base.EnterNextScenes(CommonData.SCENES_LEVELONE);
        }
    }
}
    

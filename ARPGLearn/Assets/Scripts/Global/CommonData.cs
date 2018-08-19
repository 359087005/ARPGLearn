using UnityEngine;
using System.Collections;


namespace Global
{
    /// <summary>
    /// 通用数据类
    ///  全局变量 
    ///  全局委托
    ///  ...
    /// </summary>
    public class CommonData
    {
        #region ScenesName
        public const string SCENES_LOADINGSCENES = "LoadingScenes";
        public const string SCENES_STARTSCENES = "1_StartScene";
        public const string SCENES_LOGINSCENES = "2_LoginScenes";
        public const string SCENES_LEVELONE = "3_LevelOne";
        public const string SCENES_SCENE3 = "";
        #endregion

        #region Tags
        public const string TAGS_PLAYER = "Player";
        public const string TAGS_ENEMY = "Enemy";
        #endregion

        #region JoyStick Name
        public const string JOYSTICK_NAME = "HeroJoystick";
        #endregion

        #region 音频名称
        public const string AUDIO_STARTSCENES = "StartScenes";
        #endregion


        #region Key按键名字
        public const string KEY_NORMALATTACK = "NormalAttack";
        public const string KEY_MAGICATTACKA = "MagicAttackA";
        public const string KEY_MAGICATTACKB = "MagicAttackB";
        #endregion
        #region 时间间隔
        public const float INTERVAL_TIME_0_1 = 0.1f;
        public const float INTERVAL_TIME_0_2 = 0.2f;
        public const float INTERVAL_TIME_0_3 = 0.3f;
        public const float INTERVAL_TIME_0_5 = 0.5f;
        public const float INTERVAL_TIME_1 = 1f;
        public const float INTERVAL_TIME_2 = 2f;
        public const float INTERVAL_TIME_3 = 3f;
        public const float INTERVAL_TIME_5 = 5f;
        #endregion
    }

    /// <summary>
    /// 玩家类型
    /// </summary>
    public enum PlayerType
    {
        SwordHero,
        MaigcHero,
        Other
    }
    /// <summary>
    /// 主角动作状态
    /// </summary>
    public enum HeroActionState
    {
        None,
        Idle,
        Run,
        NormalAttack,
        MagicAttackA,
        MagicAttackB,
        Dead
    }

    /// <summary>
    /// 普攻连招
    /// </summary>
    public enum NormalATKCombo
    {
        NormalATK1,
        NormalATK2,
        NormalATK3
    }
}


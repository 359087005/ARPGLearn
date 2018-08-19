using UnityEngine;
using System.Collections;

namespace Global
{
    public static class GlobalParamgr
    {
        public static string NextScenesName;

        public static string PlayerNmae = "";

        public static PlayerType playerType = PlayerType.SwordHero;


    }

    /// <summary>
    /// 主角控制委托
    /// </summary>
    /// <param name="ctrlType">控制类型</param>
    public delegate void del_PlayerCtrlWithStr(string ctrlType);
}


using UnityEngine;
using System.Collections;
using Global;
using kernal;

namespace Control
{
    [RequireComponent(typeof(Ctrl_HeroAttack))]
    /// <summary>
    /// 通过key控制主角攻击
    /// </summary>
    public class Ctrl_HeroAttackByKey : BaseControl
    {
        /// <summary>
        /// 主角控制事件
        /// </summary>
        public static event del_PlayerCtrlWithStr evePlayerCtrl;

        void Update()
        {
            if (Input.GetButton(CommonData.KEY_NORMALATTACK))
            {
                if (evePlayerCtrl != null)
                {
                    evePlayerCtrl(CommonData.KEY_NORMALATTACK);
                }
            }
            else if (Input.GetButtonDown(CommonData.KEY_MAGICATTACKA))
            {
                if (evePlayerCtrl != null)
                {
                    evePlayerCtrl(CommonData.KEY_MAGICATTACKA);
                }
            }
            else if (Input.GetButtonDown(CommonData.KEY_MAGICATTACKB))
            {
                if (evePlayerCtrl != null)
                {
                    evePlayerCtrl(CommonData.KEY_MAGICATTACKB);
                }
            }
        }
    }
}

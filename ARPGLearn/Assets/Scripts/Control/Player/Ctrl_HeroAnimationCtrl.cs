using UnityEngine;
using System.Collections;
using Global;
using kernal;
using System.Collections.Generic;
namespace Control
{
    /// <summary>
    /// 主角动画控制管理
    /// </summary>
    public class Ctrl_HeroAnimationCtrl : BaseControl
    {
        public static Ctrl_HeroAnimationCtrl _Instance;
        void Awake()
        {
            _Instance = this;
        }

        private List<AnimationClip> _HeroAnimList = new List<AnimationClip>();
        private Animation _AnimHandle;
        private HeroActionState _CurActionState = HeroActionState.None;
        public HeroActionState CurActionState
        {
            get
            {
                return _CurActionState;
            }
        }
        public static string _StrCurAnimName = "Idle";
        private bool isOver = true;
        void Start()
        {
            _CurActionState = HeroActionState.Idle;
            _AnimHandle = this.GetComponent<Animation>();

            foreach (AnimationState state in _AnimHandle)
            {
                _HeroAnimList.Add(state.clip);
            }
        }

        /// <summary>
        /// 设置当前动画状态
        /// </summary>
        /// <param name="curActionState"></param>
        public void SetCurrentActionState(HeroActionState curActionState)
        {
            _CurActionState = curActionState;
            CtrlHeroAnimationState(_CurActionState);
        }
        void Update()
        {
            if (_StrCurAnimName.Equals("Attack3-1") || _StrCurAnimName.Equals("Attack3-2") || _StrCurAnimName.Equals("Attack3-3"))
            {
                if (_AnimHandle[_StrCurAnimName].normalizedTime > 0.9f)
                {
                    isOver = true;
                }
            }
            else
            {
                isOver = true;
            }
        }

        private NormalATKCombo curNorATKCombo = NormalATKCombo.NormalATK1;


        public void CtrlHeroAnimationState(HeroActionState temp)
        {
            //if (!isOver) return;
            //isOver = false;
            switch (temp)
            {
                case HeroActionState.None:
                    break;
                case HeroActionState.Idle:
                    _AnimHandle.Play(_HeroAnimList[GetAnimByString("Idle")].name );
                    _StrCurAnimName = "Idle";
                    break;
                case HeroActionState.Run:
                    _AnimHandle.Play(_HeroAnimList[GetAnimByString("Run")].name);
                    _StrCurAnimName = "Run";
                    break;
                case HeroActionState.NormalAttack:

                    if (!isOver) return;
                    isOver = false;
                    switch (curNorATKCombo)
                    {
                        case NormalATKCombo.NormalATK1:
                            _AnimHandle.CrossFade(_HeroAnimList[GetAnimByString("Attack3-1")].name);
                            _StrCurAnimName = "Attack3-1";
                            curNorATKCombo = NormalATKCombo.NormalATK2;
                            break;
                        case NormalATKCombo.NormalATK2:
                            _AnimHandle.CrossFade(_HeroAnimList[GetAnimByString("Attack3-3")].name);
                            _StrCurAnimName = "Attack3-3";
                            curNorATKCombo = NormalATKCombo.NormalATK3;
                            break;
                        case NormalATKCombo.NormalATK3:
                            _AnimHandle.CrossFade(_HeroAnimList[GetAnimByString("Attack3-2")].name);
                            _StrCurAnimName = "Attack3-2";
                            curNorATKCombo = NormalATKCombo.NormalATK1;
                            break;
                    }
                    break;
                case HeroActionState.MagicAttackA:
                    _AnimHandle.CrossFade(_HeroAnimList[GetAnimByString("Attack1")].name);
                    _StrCurAnimName = "Attack1";
                    break;
                case HeroActionState.MagicAttackB:
                    _AnimHandle.CrossFade(_HeroAnimList[GetAnimByString("Attack4")].name);
                    _StrCurAnimName = "Attack4";
                    break;
                case HeroActionState.Dead:
                    _AnimHandle.CrossFade(_HeroAnimList[GetAnimByString("Dead")].name);
                    _StrCurAnimName = "Dead";
                    break;
                default:
                    break;
            }
        }

         int GetAnimByString(string name)
        {
            for (int i = 0; i < _HeroAnimList.Count; i++)
            {
                if (name == _HeroAnimList[i].name)
                    return i;
            }
            return -1;
        }
    }
}


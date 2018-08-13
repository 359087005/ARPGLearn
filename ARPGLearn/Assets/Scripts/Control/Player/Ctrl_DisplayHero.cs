using UnityEngine;
using System.Collections;
using Global;
using kernal;

namespace Control
{
    /// <summary>
    /// 选择人物时候  英雄展示
    /// </summary>
    public class Ctrl_DisplayHero : MonoBehaviour
    {
        public AnimationClip _Anim_Idle;
        public AnimationClip _Anim_Running;
        public AnimationClip _Anim_Attack;
        
        private Animation _AnimCurrentAnimation;

        private float _IntervalTimes = 3f;
        private int _intRandomPlayNum;
        void Start()
        {
            _AnimCurrentAnimation = this.GetComponent<Animation>();
        }

        void Update()
        {
            _IntervalTimes -= Time.deltaTime;
            if (_IntervalTimes <= 0)
            {
                _intRandomPlayNum = Random.Range(1,4);
                _IntervalTimes = 3f;
                DisPlayHeroPlaying(_intRandomPlayNum);
            }
        }

        void DisPlayHeroPlaying(int num)
        {
            switch (num)
            {
                case 1:
                    DisplayAnim(_Anim_Idle.name);break;
                case 2:
                    DisplayAnim(_Anim_Running.name);break;
                case 3:
                    DisplayAnim(_Anim_Attack.name);break;
                default:
                    break;
            }
        }

        internal void DisplayAnim(string name)
        {
            if(_AnimCurrentAnimation)
            {
                _AnimCurrentAnimation.CrossFade(name);
            }
        }
    }
}


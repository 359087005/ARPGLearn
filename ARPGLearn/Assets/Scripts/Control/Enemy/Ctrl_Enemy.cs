using UnityEngine;
using System.Collections;
using Global;

namespace Control
{
    public class Ctrl_Enemy : MonoBehaviour
    {
        private bool _isAlive = true;
        public bool IsAlive
        {
            get
            {
                return _isAlive;
            }
            private set
            {
                _isAlive = value;
            }
        }
        public int _MaxHealth = 20;             //敌人最大生命值
        private float _CurHealth = 0f;

       

        void Start()
        {
            _CurHealth = _MaxHealth;
            //判断生命 没意义啊！？为什么不受伤的时候判定
           // CheckEnemyLife();
        }

        //public void CheckEnemyLife()
        //{
        //    StartCoroutine(IECheckEnemyLife());
        //}
        //IEnumerator IECheckEnemyLife()
        //{
        //    yield return new WaitForSeconds(CommonData.INTERVAL_TIME_2);
        //    if (_CurHealth <= _MaxHealth * 0.05)
        //    {
        //        IsAlive = false;
        //    }
        //}

        public void OnHurt(int hurtValue)
        {
            _CurHealth -= hurtValue;
            if (_CurHealth <= _MaxHealth * 0.05)
            {
                IsAlive = false;
            }
        }

    }

}
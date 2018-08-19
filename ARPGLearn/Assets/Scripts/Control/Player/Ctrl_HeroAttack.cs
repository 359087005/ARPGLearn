using UnityEngine;
using System.Collections;
using Global;
using kernal;
using System.Collections.Generic;

namespace Control
{
    /// <summary>
    /// 主角攻击
    /// </summary>
    /// 吧附近的敌人放入数组
    ///     敌人放入数组   
    ///     找到最近的
    /// 一定范围内，注视最近的敌人。
    /// 响应输入攻击新号  对于主角正面敌人 给予 伤害处理
    public class Ctrl_HeroAttack : BaseControl
    {
        void Awake()
        {
            //事件注册
            Ctrl_HeroAttackByKey.evePlayerCtrl += ResponseEvent;
        }

        public float _HeroRotationSpeed = 1f; //主角旋转速度

        private List<GameObject> _EnemysList = new List<GameObject>();//附近敌人的集合
        private Transform _TranNearestEnemy; //距离最近的敌人的transform
        private float _MaxDistance = 10;        //敌我最大距离
        private float _minAttackDistance = 5;   //最小攻击距离

        void Start()
        {
            RecordNearEnemysAndGetEnemy();
            HeroRotationToEnemy();
        }

        /// <summary>
        /// 主角朝向敌人
        /// </summary>
        void HeroRotationToEnemy()
        {
            StartCoroutine(IEHeroRotationToEnemy());
        }

        IEnumerator IEHeroRotationToEnemy()
        {
            while (true)
            {
                yield return new WaitForSeconds(CommonData.INTERVAL_TIME_0_5);
                if (_TranNearestEnemy && Ctrl_HeroAnimationCtrl._Instance.CurActionState == HeroActionState.Idle)
                { 
                    float tempDis = Vector3.Distance(transform.position, _TranNearestEnemy.position);
                    if (tempDis < _minAttackDistance)
                    {
                        transform.rotation =
                            Quaternion.Slerp(
                                transform.rotation,
                            Quaternion.LookRotation(new Vector3(_TranNearestEnemy.position.x, 0, _TranNearestEnemy.position.z)
                            - new Vector3(this.transform.position.x, 0, this.transform.position.z)),
                            1f);
                    }
                }
            }
        }

        /// <summary>
        /// 记录最近的敌人并返还
        /// </summary>
        void RecordNearEnemysAndGetEnemy()
        {
            StartCoroutine(IERecordNearEnemysAndGetEnemy());
        }
        IEnumerator IERecordNearEnemysAndGetEnemy()
        {
            while (true)
            {
                yield return new WaitForSeconds(CommonData.INTERVAL_TIME_2);
                RecordNearEnemys();
                GetNearestEnemys();
            }
        }

        /// <summary>
        /// 附近的敌人放入集合
        /// </summary>
        private void RecordNearEnemys()
        {
            GameObject[] enemys = GameObject.FindGameObjectsWithTag("Enemy");
            for (int i = 0; i < enemys.Length; i++)
            {
                //TODO 敌人死亡刷新
                Ctrl_Enemy enemy = enemys[i].GetComponent<Ctrl_Enemy>();
                if (enemy && enemy.IsAlive)
                {
                    _EnemysList.Add(enemys[i]);
                }
                else
                {
                    _EnemysList.Remove(enemys[i]);
                }
            }
        }
        /// <summary>
        /// 获取最近的敌人
        /// </summary>
        private void GetNearestEnemys()
        {
            if (_EnemysList != null && _EnemysList.Count >= 1)
            {
                for (int i = 0; i < _EnemysList.Count; i++)
                {
                    float dis = Vector3.Distance(transform.position, _EnemysList[i].transform.position);
                    if (dis < _MaxDistance)
                    {
                        _MaxDistance = dis;
                        _TranNearestEnemy = _EnemysList[i].transform;
                    }
                }
            }
        }

        #region 事件响应
        public void ResponseEvent(string controlType)
        {
            switch (controlType)
            {
                case CommonData.KEY_NORMALATTACK:
                    ResponseNormalAttack();
                    break;
                case CommonData.KEY_MAGICATTACKA:
                    ResponseMagicAttackA();
                    break;
                case CommonData.KEY_MAGICATTACKB:
                    ResponseMagicAttackB();
                    break;
                default:
                    break;
            }
        }


        /// <summary>
        /// 普攻
        /// </summary>
        /// <param name="controlType"></param>
        public void ResponseNormalAttack()
        {
            //播放攻击动画
            Ctrl_HeroAnimationCtrl._Instance.SetCurrentActionState(HeroActionState.NormalAttack);
            //敌人受伤
        }

        public void ResponseMagicAttackA()
        {
            //播放动画
            Ctrl_HeroAnimationCtrl._Instance.SetCurrentActionState(HeroActionState.MagicAttackA);
        }

        public void ResponseMagicAttackB()
        {
            //播放动画
            Ctrl_HeroAnimationCtrl._Instance.SetCurrentActionState(HeroActionState.MagicAttackB);
        }
        #endregion


    }
}


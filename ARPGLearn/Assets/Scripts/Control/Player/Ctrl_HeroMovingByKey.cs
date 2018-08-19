using UnityEngine;
using System.Collections;


namespace Control
{
    /// <summary>
    /// 通过key控制主角移动
    /// </summary>
    public class Ctrl_HeroMovingByKey : BaseControl
    {

        public float _HeroMoveSpeed = 5f;

        CharacterController _HeroCC;
        float _PlayerGravity = 1f;
        void Start()
        {
            _HeroCC = GetComponent<CharacterController>();
        }

        void Update()
        {
            Move();
        }

        void Move()
        {
            float h = Input.GetAxis("Horizontal");
            float v = Input.GetAxis("Vertical");

            if (h != 0 || v != 0)
            {
                transform.LookAt(new Vector3(transform.position.x - h, transform.position.y, transform.position.z - v));

                Vector3 movement = transform.forward * Time.deltaTime * _HeroMoveSpeed;
                movement.y -= _PlayerGravity;
                _HeroCC.Move(movement);
                Ctrl_HeroAnimationCtrl._Instance.SetCurrentActionState(Global.HeroActionState.Run);
            }
            else
            {
                Ctrl_HeroAnimationCtrl._Instance.SetCurrentActionState(Global.HeroActionState.Idle);
            }
        }
    }

}
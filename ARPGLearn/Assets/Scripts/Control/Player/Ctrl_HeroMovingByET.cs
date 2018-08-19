using UnityEngine;
using System.Collections;
using Global;
using kernal;

namespace Control
{
    /// <summary>
    /// 通过easyjoystick 控制玩家移动
    /// </summary>
    public class Ctrl_HeroMovingByET : BaseControl
    {
        public float _HeroMoveSpeed = 5f;

        CharacterController _HeroCC;
        float _PlayerGravity = 1f;
        void Start()
        {
            _HeroCC = GetComponent<CharacterController>();
        }
        void OnEnable()
        {
            EasyJoystick.On_JoystickMove += OnJoystickMove;
            EasyJoystick.On_JoystickMoveEnd += OnJoystickMoveEnd;
        }
        void OnDisable()
        {
            EasyJoystick.On_JoystickMove -= OnJoystickMove;
            EasyJoystick.On_JoystickMoveEnd -= OnJoystickMoveEnd;
        }

        void OnDestroy()
        {
            OnDisable();
        }

        void OnJoystickMove(MovingJoystick move)
        {
            if (move.joystickName != CommonData.JOYSTICK_NAME)
            {
                return;
            }

            //获取摇杆中心偏移的坐标
            float joyPositonX = move.joystickAxis.x;
            float joyPositionY = move.joystickAxis.y;

            if (joyPositonX != 0 || joyPositionY != 0)
            {
                //设置玩家 朝向
                transform.LookAt(new Vector3(transform.position.x - joyPositonX,transform.position.y,transform.position.z - joyPositionY));
                //transform.Translate(Vector3.forward * Time.deltaTime * 5);

                //角色控制移动
                Vector3 movement = transform.forward * Time.deltaTime * _HeroMoveSpeed;
                _HeroCC.Move(movement);

                movement.y -= _PlayerGravity;
                Ctrl_HeroAnimationCtrl._Instance.SetCurrentActionState(HeroActionState.Run);
            }
        }

        void OnJoystickMoveEnd(MovingJoystick move)
        {
            if (move.joystickName != CommonData.JOYSTICK_NAME)
            {
                return;
            }
            Ctrl_HeroAnimationCtrl._Instance.SetCurrentActionState(HeroActionState.Idle);
        }
        
        //public float CheckAngle(float value)
        //{
        //   return value = value > 180 ? value - 360 : value;
        //}
    }
}


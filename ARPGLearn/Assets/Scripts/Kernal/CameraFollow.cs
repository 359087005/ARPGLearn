/***
 * 
 *  �������ű� 
 * 
 * �̶��Ƕ�
 * 
 * 
 * 
 * 
 */
using UnityEngine;
using System.Collections;

namespace kernal
{
    public class CameraFollow : MonoBehaviour
    {
        // The target we are following
        public Transform target = null;
        // The distance in the x-z plane to the target
        public float distance = 6.0f;  
        // the height we want the camera to be above the target
        public float height = 8.0f;
        // How much we 
        public float heightDamping = 4.0f;
        public float rotationDamping = 0.0f;

        
        void Start()
        {
            target = GameObject.FindGameObjectWithTag("Player").transform;
        }

        float a = 2.0f;
        // Update is called once per frame
        void Update()
        {
            a -= Time.deltaTime;
            if (a <= 0)
            {
                target = GameObject.FindGameObjectWithTag("Player").transform;
                a = 2.0f;
            }
        }

        void LateUpdate()
        {
            if (!target)
                return;
            var wantedRotationAngle = target.eulerAngles.y; //��ת��Ŀ��Ƕ�
            var wantedHeight = target.position.y + height;//Ŀ��߶�
            var currentRotationAngle = transform.eulerAngles.y; //��ǰ�Ƕ�
            var currentHeight = transform.position.y;//��ǰ�߶�
            // Damp the rotation around the y-axis      ��ֵ�����ǰ��ת�Ƕ�
            currentRotationAngle = Mathf.LerpAngle(currentRotationAngle, wantedRotationAngle, rotationDamping * Time.deltaTime);
            // Damp the height          ��ֵ�����ǰ�߶�
            currentHeight = Mathf.Lerp(currentHeight, wantedHeight, heightDamping * Time.deltaTime);

            // Convert the angle into a rotation
            Quaternion currentRotation = Quaternion.Euler(0, currentRotationAngle, 0);
            // Set the position of the camera on the x-z plane to:
            // distance meters behind the target
            transform.position = target.position;       //��ȡ��Ŀ���λ��
            transform.position -= currentRotation * Vector3.forward * distance;//���������Ŀ���λ��
            // Set the height of the camera
            //transform.position.y = currentHeight;       
            transform.position = new Vector3(transform.position.x, currentHeight, transform.position.z);//������ĸ߶�
            // Always look at the target
            transform.LookAt(target);
            // Use this for initialization
        }
    }//class_end
}
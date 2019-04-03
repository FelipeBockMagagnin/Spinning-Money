using System;
using UnityEngine;

namespace Assets.SimpleAndroidNotifications
{
    public class NotificationExample : MonoBehaviour
    {
        private void Start()
        {
            CancelAll();
        }

        public void ScheduleNormal()
        {
            NotificationManager.SendWithAppIcon(TimeSpan.FromHours(4), "Spinning Money", "Time to collect your money :)", new Color(0, 0.6f, 1), NotificationIcon.Bell);
        }

        public void CancelAll()
        {
            NotificationManager.CancelAll();
        }

        private void OnApplicationPause(bool pause)
        {
            if (pause)
            {
                ScheduleNormal();
            }
            else
            {
                CancelAll();
            }
        }
    }
}
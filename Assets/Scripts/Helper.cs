using System;
using System.Collections;
using UnityEngine;

namespace Demo.PlayerProfile
{
    public static class Helper
    {
        public static void StartAnimation(this MonoBehaviour coroutineRunner,
            int repeat,
            float duration,
            float delay,
            AnimationCurve curve,
            bool yoyoMode,
            Action<float> action)
        {
            coroutineRunner.StartCoroutine(Animation(repeat, duration, delay, curve, yoyoMode,action));
        }

        public static IEnumerator Animation(int repeat,
            float duration,
            float delay,
            AnimationCurve curve,
            bool yoyoMode,
            Action<float> action)
        {
            bool isInfinite = repeat < 0;
            var waiter = new WaitForSeconds(delay); 

            while (isInfinite || repeat >= 0)
            {
                if (!isInfinite)
                    repeat--;
                
                yield return Animation(duration, curve, action);
                yield return waiter;
                
                if (!yoyoMode)
                    continue;
                    
                Action<float> invert = (t) => { action?.Invoke(1 - t); };
                yield return Animation(duration, curve, invert);
            }
        }

        public static IEnumerator Animation(float duration, AnimationCurve curve, Action<float> action)
        {
            var lostTime = 0f;

            while (lostTime < 1)
            {
                lostTime += Time.deltaTime / duration;
                action?.Invoke(curve.Evaluate(lostTime));
                yield return null;
            }
        }
    }
}
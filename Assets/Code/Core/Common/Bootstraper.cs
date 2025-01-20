using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Code.Core.Common
{
    public sealed class Bootstraper : MonoBehaviour
    {
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSplashScreen)]
        public static void Initialize()
        {
            SceneManager.LoadScene("Bootstrap", LoadSceneMode.Single);
        }

        private IEnumerator Start()
        {
            yield return new WaitForSeconds(2);
            SceneManager.LoadScene("Main", LoadSceneMode.Single);
        }
    }
}

using UnityEngine;
using System.Collections;

namespace Floater
{
    public class BaseMover : MonoBehaviour
    {
        private bool alive = false;

        private void Awake()
        {
            toggleAlive();
            StartCoroutine(startStop());
        }

        private Vector2 RandDirection()
        {
            return new Vector2(Random.Range(-1, 2), Random.Range(-1, 2));
        }

        private IEnumerator startStop()
        {
            while (alive)
            {
                Vector2 tmp = RandDirection();
                transform.Translate(tmp[0], tmp[1], 0.0f);
                yield return new WaitForSeconds(.05f);
            }
        }

        public void toggleAlive()
        {
            alive = !alive;           
        }
    }
}

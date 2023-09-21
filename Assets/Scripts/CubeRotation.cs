using UnityEngine;

public class CubeRotation : MonoBehaviour
{
    private GameObject target;

    private Vector2 _fPressPos;
    private Vector2 _sPressPos;
    private Vector2 _curPressPos;

    private Vector3 _dragPrevPos;
    private Vector3 _dragDeltaPos;

    private const float SPEED = 200f;

    private void Start()
    {
        target = new GameObject("target")
        {
            transform =
            {
                position = new Vector3(0, 0, 0),
                rotation = new Quaternion(0, 0, 0, 0)
            }
        };
    }

    private void Update()
    {
        Swipe();
        Drag();
    }

    private void Drag()
    {
        if (Input.GetMouseButton(1))
        {
            _dragDeltaPos = Input.mousePosition - _dragPrevPos;
            _dragDeltaPos *= 0.1f;
            transform.rotation = Quaternion.Euler(_dragDeltaPos.y, -_dragDeltaPos.x, 0) * transform.rotation;
        }
        else
        {
            if (transform.rotation == target.transform.rotation) return;
            var step = SPEED * Time.deltaTime;
            transform.rotation = Quaternion.RotateTowards(transform.rotation, target.transform.rotation, step);
        }

        _dragPrevPos = Input.mousePosition;
    }

    private void Swipe()
    {
        if (Input.GetMouseButtonDown(1))
        {
            _fPressPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        }

        if (!Input.GetMouseButtonUp(1)) return;
        _sPressPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        _curPressPos = new Vector2(_sPressPos.x - _fPressPos.x, _sPressPos.y - _fPressPos.y);

        _curPressPos.Normalize();

        if (LeftSwipe())
        {
            target.transform.Rotate(0, 90, 0, Space.World);
        }
        else if (RightSwipe())
        {
            target.transform.Rotate(0, -90, 0, Space.World);
        }

        else if (UpLeftSwipe())
        {
            target.transform.Rotate(90, 0, 0, Space.World);
        }
        else if (UpRightSwipe())
        {
            target.transform.Rotate(0, 0, 90, Space.World);
        }

        else if (DownLeftSwipe())
        {
            target.transform.Rotate(-90, 0, 0, Space.World);
        }
        else if (DownRightSwipe())
        {
            target.transform.Rotate(0, 0, -90, Space.World);
        }
    }

    private bool RightSwipe()
    {
        return _curPressPos.x > 0 && _curPressPos.y > -0.5f && _curPressPos.y < 0.5f;
    }

    private bool UpRightSwipe()
    {
        return _curPressPos.x < 0 && _curPressPos.y > 0f;
    }

    private bool DownRightSwipe()
    {
        return _curPressPos.x > 0f && _curPressPos.y < 0f;
    }

    private bool LeftSwipe()
    {
        return _curPressPos.x < 0 && _curPressPos.y > -0.5f && _curPressPos.y < 0.5f;
    }

    private bool UpLeftSwipe()
    {
        return _curPressPos.x > 0f && _curPressPos.y > 0f;
    }

    private bool DownLeftSwipe()
    {
        return _curPressPos.x < 0f && _curPressPos.y < 0f;
    }
}
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField]
    private Transform _playerTransform;
    [Range(0f, 0.01f)]
    [SerializeField]
    private float smoothness;
    [SerializeField]
    private Vector2 _followBounds;

    private Vector3 _oldPos;
    private Vector3 offset;
    
    void Start()
    {
        offset = new Vector3(0, _playerTransform.position.y - transform.position.y,_playerTransform.position.z - transform.position.z); 
        _oldPos = _playerTransform.position;
    }

    private void LateUpdate()
    {
        if (Helpers.Vector2InBounds(_playerTransform.position,transform.position, _followBounds))
        {
            
            transform.position = Vector3.Lerp(transform.position, _playerTransform.position - offset, smoothness);
            _oldPos = _playerTransform.position;
        }
        else
        {
            transform.position = Vector3.Lerp(transform.position, _oldPos - offset, smoothness);
        }
        
    }
}
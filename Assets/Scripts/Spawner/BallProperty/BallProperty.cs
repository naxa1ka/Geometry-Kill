    using System;
    using System.Collections.Generic;
    using UnityEngine;

    [Serializable]
    public class MinMax
    {
        [SerializeField] private float _min;
        [SerializeField] private float _max;

        public float Random()
        {
            var normalizedRandomValue = UnityEngine.Random.Range(0f, 1f);
            return Mathf.Lerp(_min, _max, normalizedRandomValue);
        }
    }
    
    [CreateAssetMenu(fileName = "BallProperty", menuName = "Settings/BallProperty", order = 1)]
    public class BallProperty : ScriptableObject
    {
        [SerializeField] private MinMax _health;
        [SerializeField] private MinMax _angle;
        [SerializeField] private MinMax _speed;
        [SerializeField] private MinMax _scoreOnDie;
        [SerializeField] private MinMax _damageOnDie;
        [SerializeField] private List<Color> _colors;

        public float Health => _health.Random();
        public float Speed => _speed.Random();
        public int ScoreOnDie => Mathf.CeilToInt(_scoreOnDie.Random());
        public int DamageOnDie => Mathf.CeilToInt(_damageOnDie.Random());
        public Vector3 Angle => new Vector3(0, 0, _angle.Random());
        public Color Color => _colors.RandomItem();
    }

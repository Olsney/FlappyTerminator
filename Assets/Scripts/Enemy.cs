namespace DefaultNamespace
{
    public class Enemy : PoolableObject<Enemy>
    {
        private ScoreModel _scoreModel;

        protected override void OnTouched(IInteractable obj)
        {
            OnFaced(this);

            if (obj is Bullet)
                _scoreModel.Increase();
        }
        
        public void Init(ScoreModel scoreModel)
        {
            _scoreModel = scoreModel;
        }
    }
}
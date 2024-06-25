namespace TopDownShooter
{
    public abstract class FSMStateBase
    {
        protected FSM _fsm;

        public FSMStateBase(FSM fsm)
        {
            _fsm = fsm;
        }

        public virtual void Enter() { }

        public virtual void Exit() { }

        public virtual void Update() { }
    }
}

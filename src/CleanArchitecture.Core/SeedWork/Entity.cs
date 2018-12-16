namespace CleanArchitecture.Core.SeedWork
{
    public abstract class Entity
    {
        private int _id;
        public virtual int Id
        {
            get
            {
                return _id;
            }
            protected set
            {
                _id = value;
            }
        }
    }
}

using System.ComponentModel;

namespace NodeStrategy
{
    abstract class Command
    {
        public virtual string errorMessage { get; protected set; }
        public virtual string startMessage { get; protected set;  }
        public virtual string successMessage { get; protected set;  }
        public virtual bool finishedExectuing { get; protected set; } 
        public virtual int executerId { get; protected set; }

        public virtual string Name { get; protected set; }

        public abstract void OnStart();
        public abstract void Execute();
        public abstract void OnFinish();
        public abstract bool IsValid();
    }
}

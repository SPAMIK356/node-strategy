
using System.ComponentModel;

namespace NodeStrategy
{
    public abstract class Command
    {
        public Command(int executerId)
        {
            this.executerId = executerId;
        }
        public virtual string errorMessage { get; init; }
        public virtual string startMessage { get; init;  }
        public virtual string successMessage { get; init;  }
        public virtual bool finishedExectuing { get; protected set; } 
        public virtual int executerId { get; protected set; }
        public virtual string description { get; protected set; }
        public virtual string Name { get; protected set; }

        public abstract void OnStart();
        public abstract void Execute();
        public abstract void OnFinish();
        public abstract bool IsValid();
    }
}

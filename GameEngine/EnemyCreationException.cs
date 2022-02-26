using System.Runtime.Serialization;

namespace GameEngine
{
    [Serializable]
    public class EnemyCreationException : Exception
    {
        public EnemyCreationException()
        {
        }

        public EnemyCreationException(string? message) : base(message)
        {
        }

        public EnemyCreationException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected EnemyCreationException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
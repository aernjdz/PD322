using System;

namespace Homework_10
{
    public interface IDisk
    {
        string GetName();
        void Insert();
        void Reject();
        string Read();
        void Write(string text);
    }
}

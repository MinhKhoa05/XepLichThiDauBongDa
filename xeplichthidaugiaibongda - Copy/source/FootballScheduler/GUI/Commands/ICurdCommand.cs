namespace GUI.Commands
{
    public interface ICurdCommand
    {
        void Load();
        void Insert();
        void Update();
        void Delete();
        void Export();
        void Undo();

        bool CanUpdate { get; }
        bool CanDelete { get; }
    }
}

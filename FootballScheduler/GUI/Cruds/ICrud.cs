namespace GUI.Cruds
{
    public interface ICrud
    {
        void LoadData();
        void Insert();
        void Update();
        void Delete();
        void Export();
    }
}

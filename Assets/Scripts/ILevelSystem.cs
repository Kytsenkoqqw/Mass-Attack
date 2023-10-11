namespace DefaultNamespace
{
    public interface ILevelSystem
    {
        int Level { get; }
        int Experience { get; }
        void AddExperience(int experience);
        void IncreaseLevel();
    }
}
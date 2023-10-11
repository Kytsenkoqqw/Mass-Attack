namespace DefaultNamespace
{
    public interface ILevelSystem
    {
        int CurrentLevel { get; }
        int CurrentExperience { get; }
        void AddExperience(int experience);
        void IncreaseLevel();
    }
}